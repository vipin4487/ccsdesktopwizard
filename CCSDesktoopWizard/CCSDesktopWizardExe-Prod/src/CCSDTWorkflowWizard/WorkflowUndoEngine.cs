namespace CCSDTWorkflowWizard
{
    using CCSDTWorkflowLibrary;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.ComponentModel.Design.Serialization;
    using System.Windows.Forms;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Design;

    internal class WorkflowUndoEngine : UndoEngine
    {
        private IServiceProvider _provider;
        private Stack<WorkflowUndoUnit> undoUnits;
        private Stack<WorkflowUndoUnit> redoUnits;

        public WorkflowUndoEngine(IServiceProvider provider) : base(provider)
        {
            this.undoUnits = null;
            this.redoUnits = null;
            this.undoUnits = new Stack<WorkflowUndoUnit>();
            this.redoUnits = new Stack<WorkflowUndoUnit>();
            this._provider = provider;
        }

        protected override void AddUndoUnit(UndoEngine.UndoUnit unit)
        {
            if (base.Enabled)
            {
                this.redoUnits.Clear();
                this.undoUnits.Push(unit as WorkflowUndoUnit);
            }
        }

        protected override UndoEngine.UndoUnit CreateUndoUnit(string name, bool primary)
        {
            if (name.Contains("Move Activity"))
            {
                IDesignerHost requiredService = this.GetRequiredService(typeof(IDesignerHost)) as IDesignerHost;
            }
            return new WorkflowUndoUnit(this, name);
        }

        protected override void DiscardUndoUnit(UndoEngine.UndoUnit unit)
        {
            base.DiscardUndoUnit(unit);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.undoUnits.Clear();
            this.redoUnits.Clear();
        }

        public void DoRedo()
        {
            if (this.CanRedo)
            {
                WorkflowUndoUnit item = this.redoUnits.Pop();
                item.Undo();
                this.undoUnits.Push(item);
            }
        }

        public void DoUndo()
        {
            if (this.CanUndo)
            {
                WorkflowUndoUnit item = this.undoUnits.Pop();
                item.Undo();
                this.redoUnits.Push(item);
            }
        }

        protected object GetRequiredService(Type serviceType)
        {
            object service = this.GetService(serviceType);
            if (service == null)
            {
                throw new NotSupportedException("Service '" + serviceType.Name + "' missing");
            }
            return service;
        }

        protected object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType");
            }
            if (this._provider > null)
            {
                return this._provider.GetService(serviceType);
            }
            return null;
        }

        public void OnRedo(object sender, EventArgs e)
        {
            this.DoRedo();
        }

        public void OnUndo(object sender, EventArgs e)
        {
            this.DoUndo();
        }

        protected override void OnUndoing(EventArgs e)
        {
            base.Enabled = false;
            base.OnUndoing(e);
        }

        protected override void OnUndone(EventArgs e)
        {
            base.Enabled = true;
            base.OnUndone(e);
        }

        public bool CanUndo =>
            this.undoUnits.Count != 0;

        public bool CanRedo =>
            this.redoUnits.Count != 0;

        public string UndoText =>
            this.CanUndo ? this.undoUnits.Peek().Name : string.Empty;

        public string RedoText =>
            this.CanRedo ? this.redoUnits.Peek().Name : string.Empty;

        protected class WorkflowUndoUnit : UndoEngine.UndoUnit
        {
            private WorkflowUndoEngine _engine;
            private string _name;
            private bool _closed;
            private List<Action> _actions;
            private List<string> _childActivites;
            private CompositeActivity _parentActivity;

            public WorkflowUndoUnit(UndoEngine parent, string desc) : base(parent, desc)
            {
                this._engine = (WorkflowUndoEngine) parent;
                this._name = desc;
                this._actions = new List<Action>();
            }

            public override void Close()
            {
                Console.WriteLine("UndoUnot.Close (" + this._name + ")");
                this._closed = true;
            }

            public override void ComponentAdded(ComponentEventArgs e)
            {
                if (!this._closed)
                {
                    Console.WriteLine("New Action: Component*Add*RemoveAction (" + e.Component.Site.Name + ")");
                    this._actions.Add(new ComponentAddRemoveAction(this._engine, this, e.Component, true));
                }
            }

            public override void ComponentAdding(ComponentEventArgs e)
            {
            }

            public override void ComponentChanged(ComponentChangedEventArgs e)
            {
                if (!this._closed)
                {
                    ComponentChangeAction action = null;
                    for (int i = 0; i < this._actions.Count; i++)
                    {
                        action = this._actions[i] as ComponentChangeAction;
                        if ((((action != null) && !action.IsComplete) && (action.Component == e.Component)) && action.Member.Equals(e.Member))
                        {
                            action.SetModifiedState(this._engine, (IComponent) e.Component, e.Member);
                            break;
                        }
                    }
                    if ((((action == null) && (e.Component is CompositeActivity)) && ((this._parentActivity == e.Component) && (this._childActivites > null))) && (this._parentActivity.Activities.Count < this._childActivites.Count))
                    {
                        IDesignerHost requiredService = (IDesignerHost) this._engine.GetRequiredService(typeof(IDesignerHost));
                        for (int j = this._childActivites.Count - 1; j >= 0; j--)
                        {
                            string activityQualifiedName = this._childActivites[j];
                            Activity activityByName = this._parentActivity.GetActivityByName(activityQualifiedName);
                            if ((requiredService.RootComponent.Site.Container.Components[activityQualifiedName] != null) && (activityByName == null))
                            {
                                this._actions.Add(new ComponentMoveAction(activityQualifiedName, this._parentActivity.Name, j));
                            }
                        }
                    }
                }
            }

            public override void ComponentChanging(ComponentChangingEventArgs e)
            {
                if (!this._closed)
                {
                    Console.WriteLine("New Action: ComponentChangeAction (" + ((IComponent) e.Component).Site.Name + ")");
                    if (e.Member > null)
                    {
                        ComponentChangeAction item = new ComponentChangeAction();
                        item.SetOriginalState(this._engine, (IComponent) e.Component, e.Member);
                        this._actions.Add(item);
                    }
                    else if (e.Component is CompositeActivity)
                    {
                        this._parentActivity = (CompositeActivity) e.Component;
                        if (this._childActivites == null)
                        {
                            this._childActivites = new List<string>();
                        }
                        else
                        {
                            this._childActivites.Clear();
                        }
                        foreach (Activity activity in this._parentActivity.Activities)
                        {
                            this._childActivites.Add(activity.Name);
                        }
                    }
                }
            }

            public override void ComponentRemoved(ComponentEventArgs e)
            {
            }

            public override void ComponentRemoving(ComponentEventArgs e)
            {
                if (!this._closed)
                {
                    Console.WriteLine("New Action: ComponentAdd*Remove*Action (" + e.Component.Site.Name + ")");
                    this._actions.Add(new ComponentAddRemoveAction(this._engine, this, e.Component, false));
                }
            }

            public override void ComponentRename(ComponentRenameEventArgs e)
            {
                if (!this._closed)
                {
                    Console.WriteLine("New Action: ComponentRenameAction (" + ((IComponent) e.Component).Site.Name + ")");
                    this._actions.Add(new ComponentRenameAction(e.NewName, e.OldName));
                }
            }

            public int IndexInParent(string childName)
            {
                if (this._childActivites != null)
                {
                    for (int i = 0; i < this._childActivites.Count; i++)
                    {
                        if (this._childActivites[i] == childName)
                        {
                            return i;
                        }
                    }
                }
                return -1;
            }

            public void Undo()
            {
                this._engine.OnUndoing(EventArgs.Empty);
                this.UndoCore();
                this._engine.OnUndone(EventArgs.Empty);
            }

            protected override void UndoCore()
            {
                for (int i = this._actions.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine("Undoing action type: " + this._actions[i].GetType().Name);
                    this._actions[i].Undo(this._engine);
                }
                this._actions.Reverse();
            }

            public override bool IsEmpty =>
                this._actions.Count == 0;

            public virtual string Name =>
                this._name;

            public string ParentName
            {
                get
                {
                    if (this._parentActivity > null)
                    {
                        return this._parentActivity.Name;
                    }
                    return null;
                }
            }

            private class Action
            {
                public virtual void Undo(UndoEngine engine)
                {
                }
            }

            private class ComponentAddRemoveAction : WorkflowUndoEngine.WorkflowUndoUnit.Action
            {
                private string _componentName;
                private string _parentName;
                private int _currentIndex;
                private Type _serializedType;
                private SerializationStore _serializedComponent;
                private bool _added;

                public ComponentAddRemoveAction(UndoEngine engine, WorkflowUndoEngine.WorkflowUndoUnit parent, IComponent component, bool added)
                {
                    if (component == null)
                    {
                        throw new ArgumentNullException("component");
                    }
                    if (component.GetType() != typeof(PropertyGrid))
                    {
                        ComponentSerializationService requiredService = ((WorkflowUndoEngine) engine).GetRequiredService(typeof(ComponentSerializationService)) as ComponentSerializationService;
                        this._serializedComponent = requiredService.CreateStore();
                        requiredService.Serialize(this._serializedComponent, component);
                        this._serializedComponent.Close();
                        this._added = added;
                        this._componentName = component.Site.Name;
                        this._serializedType = component.GetType();
                        this._parentName = parent.ParentName;
                        this._currentIndex = parent.IndexInParent(this._componentName);
                    }
                }

                public override void Undo(UndoEngine engine)
                {
                    IDesignerHost requiredService = ((WorkflowUndoEngine) engine).GetRequiredService(typeof(IDesignerHost)) as IDesignerHost;
                    if (this._added)
                    {
                        Console.WriteLine("Component*Add*RemoveAction.Undo (" + this._componentName + ")");
                        IComponent component = requiredService.Container.Components[this._componentName];
                        if (component > null)
                        {
                            Activity activityByName = ((CustomCCSDTWorkflowBase) requiredService.RootComponent).GetActivityByName(this._componentName);
                            if ((activityByName != null) && (activityByName.Parent > null))
                            {
                                activityByName.Parent.Activities.Remove(activityByName);
                            }
                            requiredService.DestroyComponent(component);
                            IRootDesigner designer = requiredService.GetDesigner(requiredService.RootComponent) as IRootDesigner;
                            WorkflowView view = designer.GetView(ViewTechnology.Default) as WorkflowView;
                            view.PerformLayout(true);
                            view.Update();
                        }
                        this._added = false;
                    }
                    else
                    {
                        Console.WriteLine("ComponentAdd*Remove*Action.Undo (" + this._componentName + ")");
                        ComponentSerializationService service = ((WorkflowUndoEngine) engine).GetRequiredService(typeof(ComponentSerializationService)) as ComponentSerializationService;
                        Activity component = (Activity) this._serializedType.GetConstructor(new Type[0]).Invoke(new object[0]);
                        component.Name = this._componentName;
                        requiredService.RootComponent.Site.Container.Add(component);
                        service.DeserializeTo(this._serializedComponent, requiredService.RootComponent.Site.Container);
                        component.Site.Name = this._componentName;
                        CustomCCSDTWorkflowBase rootComponent = (CustomCCSDTWorkflowBase) requiredService.RootComponent;
                        rootComponent.Activities.Insert(0, component);
                        IRootDesigner designer = requiredService.GetDesigner(requiredService.RootComponent) as IRootDesigner;
                        WorkflowView view = designer.GetView(ViewTechnology.Default) as WorkflowView;
                        view.PerformLayout(true);
                        view.Update();
                        this._added = true;
                    }
                }
            }

            private class ComponentChangeAction : WorkflowUndoEngine.WorkflowUndoUnit.Action
            {
                private string _componentName;
                private MemberDescriptor _member;
                private IComponent _component;
                private SerializationStore _afterChange;
                private SerializationStore _beforeChange;

                public void SetModifiedState(UndoEngine engine, IComponent component, MemberDescriptor member)
                {
                    Console.WriteLine("ComponentChangeAction.SetModifiedState (" + ((this._componentName != null) ? (this._componentName + ".") : "") + member.Name + "): " + ((((PropertyDescriptor) member).GetValue(component) == null) ? "null" : ((PropertyDescriptor) member).GetValue(component).ToString()));
                    ComponentSerializationService requiredService = ((WorkflowUndoEngine) engine).GetRequiredService(typeof(ComponentSerializationService)) as ComponentSerializationService;
                    this._afterChange = requiredService.CreateStore();
                    requiredService.SerializeMemberAbsolute(this._afterChange, component, member);
                    this._afterChange.Close();
                }

                public void SetOriginalState(UndoEngine engine, IComponent component, MemberDescriptor member)
                {
                    this._member = member;
                    this._component = component;
                    this._componentName = component.Site?.Name;
                    Console.WriteLine("ComponentChangeAction.SetOriginalState (" + ((this._componentName != null) ? (this._componentName + ".") : "") + member.Name + "): " + ((((PropertyDescriptor) member).GetValue(component) == null) ? "null" : ((PropertyDescriptor) member).GetValue(component).ToString()));
                    ComponentSerializationService requiredService = ((WorkflowUndoEngine) engine).GetRequiredService(typeof(ComponentSerializationService)) as ComponentSerializationService;
                    this._beforeChange = requiredService.CreateStore();
                    requiredService.SerializeMemberAbsolute(this._beforeChange, component, member);
                    this._beforeChange.Close();
                }

                public override void Undo(UndoEngine engine)
                {
                    if (this._beforeChange == null)
                    {
                        Console.WriteLine("ComponentChangeAction.Undo: ERROR: UndoUnit is not complete.");
                    }
                    else
                    {
                        IDesignerHost requiredService = (IDesignerHost) ((WorkflowUndoEngine) engine).GetRequiredService(typeof(IDesignerHost));
                        this._component = requiredService.Container.Components[this._componentName];
                        (((WorkflowUndoEngine) engine).GetRequiredService(typeof(ComponentSerializationService)) as ComponentSerializationService).DeserializeTo(this._beforeChange, requiredService.Container);
                        SerializationStore store = this._beforeChange;
                        this._beforeChange = this._afterChange;
                        this._afterChange = store;
                    }
                }

                public bool IsComplete =>
                    (this._beforeChange != null) && (this._afterChange > null);

                public string ComponentName =>
                    this._componentName;

                public IComponent Component =>
                    this._component;

                public MemberDescriptor Member =>
                    this._member;
            }

            private class ComponentMoveAction : WorkflowUndoEngine.WorkflowUndoUnit.Action
            {
                private string _componentName;
                private string _parentName;
                private int _indexInParent;

                public ComponentMoveAction(string childName, string parentName, int index)
                {
                    this._componentName = childName;
                    this._parentName = parentName;
                    this._indexInParent = index;
                }

                public override void Undo(UndoEngine engine)
                {
                    Console.WriteLine("ComponentMoveAction.Undo (" + this._parentName + "." + this._componentName + ":" + this._indexInParent.ToString() + ")");
                    IDesignerHost requiredService = (IDesignerHost) ((WorkflowUndoEngine) engine).GetRequiredService(typeof(IDesignerHost));
                    CustomCCSDTWorkflowBase rootComponent = (CustomCCSDTWorkflowBase) requiredService.RootComponent;
                    Activity activityByName = rootComponent.GetActivityByName(this._componentName);
                    CompositeActivity activity2 = rootComponent.GetActivityByName(this._parentName) as CompositeActivity;
                    if (((activityByName != null) && (activityByName.Parent != null)) && (activity2 > null))
                    {
                        CompositeActivity parent = activityByName.Parent;
                        int index = parent.Activities.IndexOf(activityByName);
                        parent.Activities.Remove(activityByName);
                        activity2.Activities.Insert(this._indexInParent, activityByName);
                        this._parentName = parent.Name;
                        this._indexInParent = index;
                    }
                    IRootDesigner designer = requiredService.GetDesigner(requiredService.RootComponent) as IRootDesigner;
                    WorkflowView view = designer.GetView(ViewTechnology.Default) as WorkflowView;
                    view.PerformLayout(true);
                    view.Update();
                }

                public string ComponentName =>
                    this._componentName;
            }

            private class ComponentRenameAction : WorkflowUndoEngine.WorkflowUndoUnit.Action
            {
                private string _oldName;
                private string _currentName;

                public ComponentRenameAction(string currentName, string oldName)
                {
                    Console.WriteLine("ComponentRenameAction (" + oldName + "): " + currentName);
                    this._currentName = currentName;
                    this._oldName = oldName;
                }

                public override void Undo(UndoEngine engine)
                {
                    Console.WriteLine("ComponentRenameAction.Undo (" + this._currentName + "): " + this._oldName);
                    IDesignerHost requiredService = ((WorkflowUndoEngine) engine).GetRequiredService(typeof(IDesignerHost)) as IDesignerHost;
                    IComponent component = requiredService.Container.Components[this._currentName];
                    CustomCCSDTWorkflowBase rootComponent = (CustomCCSDTWorkflowBase) requiredService.RootComponent;
                    component.Site.Name = this._oldName;
                    string str = this._currentName;
                    this._currentName = this._oldName;
                    this._oldName = str;
                    TypeDescriptor.GetProperties((Activity) component)["Name"].SetValue((Activity) component, this._currentName);
                }
            }
        }
    }
}

