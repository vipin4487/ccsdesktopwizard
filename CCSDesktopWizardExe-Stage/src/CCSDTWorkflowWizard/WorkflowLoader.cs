namespace CCSDTWorkflowWizard
{
    using CCSDTWorkflowLibrary;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.ComponentModel.Design.Serialization;
    using System.Drawing.Design;
    using System.IO;
    using System.Windows.Forms;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Compiler;
    using System.Workflow.ComponentModel.Design;
    using System.Workflow.ComponentModel.Serialization;
    using System.Xml;

    internal sealed class WorkflowLoader : WorkflowDesignerLoader
    {
        public PropertyGrid propGridToUpdate;
        private string xoml = string.Empty;
        private Type workflowType = null;
        private string xomlFile = string.Empty;

        internal WorkflowLoader(PropertyGrid propertyGrid)
        {
            this.propGridToUpdate = propertyGrid;
        }

        private static void AddObjectGraphToDesignerHost(IDesignerHost designerHost, Activity activity)
        {
            Guid guid = new Guid("3FA84B23-B15B-4161-8EB8-37A54EFEEFC7");
            if (designerHost == null)
            {
                throw new ArgumentNullException("designerHost");
            }
            if (activity == null)
            {
                throw new ArgumentNullException("activity");
            }
            string qualifiedName = activity.QualifiedName;
            if (activity.Parent == null)
            {
                string fullName = activity.UserData[guid] as string;
                if (fullName == null)
                {
                    fullName = activity.GetType().FullName;
                }
                qualifiedName = (fullName.LastIndexOf('.') != -1) ? fullName.Substring(fullName.LastIndexOf('.') + 1) : fullName;
                designerHost.Container.Add(activity, qualifiedName);
            }
            else
            {
                designerHost.Container.Add(activity, activity.QualifiedName);
            }
            if (activity is CompositeActivity)
            {
                foreach (Activity activity2 in GetNestedActivities(activity as CompositeActivity))
                {
                    designerHost.Container.Add(activity2, activity2.QualifiedName);
                }
            }
        }

        internal static void DestroyObjectGraphFromDesignerHost(IDesignerHost designerHost, Activity activity)
        {
            if (designerHost == null)
            {
                throw new ArgumentNullException("designerHost");
            }
            if (activity == null)
            {
                throw new ArgumentNullException("activity");
            }
            WorkflowUndoEngine service = (WorkflowUndoEngine) designerHost.GetService(typeof(UndoEngine));
            if (service > null)
            {
                service.Enabled = false;
            }
            designerHost.DestroyComponent(activity);
            if (activity is CompositeActivity)
            {
                foreach (Activity activity2 in GetNestedActivities(activity as CompositeActivity))
                {
                    designerHost.DestroyComponent(activity2);
                }
            }
        }

        public override void Dispose()
        {
            IDesignerLoaderHost loaderHost = base.LoaderHost;
            if (loaderHost > null)
            {
                loaderHost.RemoveService(typeof(IIdentifierCreationService));
                loaderHost.RemoveService(typeof(IMenuCommandService));
                loaderHost.RemoveService(typeof(IToolboxService));
                loaderHost.RemoveService(typeof(ITypeProvider), true);
                loaderHost.RemoveService(typeof(IEventBindingService));
                loaderHost.RemoveService(typeof(IPropertyValueUIService));
                loaderHost.RemoveService(typeof(UndoEngine));
            }
            base.Dispose();
        }

        public override void ForceReload()
        {
        }

        public override TextReader GetFileReader(string filePath) => 
            new StreamReader(new FileStream(filePath, FileMode.OpenOrCreate));

        public override TextWriter GetFileWriter(string filePath) => 
            new StreamWriter(new FileStream(filePath, FileMode.OpenOrCreate));

        private static Activity[] GetNestedActivities(CompositeActivity compositeActivity)
        {
            if (compositeActivity == null)
            {
                throw new ArgumentNullException("compositeActivity");
            }
            IList<Activity> activities = null;
            ArrayList list2 = new ArrayList();
            Queue queue = new Queue();
            queue.Enqueue(compositeActivity);
            while (queue.Count > 0)
            {
                CompositeActivity activity = (CompositeActivity) queue.Dequeue();
                activities = activity.Activities;
                foreach (Activity activity2 in activities)
                {
                    list2.Add(activity2);
                    if (activity2 is CompositeActivity)
                    {
                        queue.Enqueue(activity2);
                    }
                }
            }
            return (Activity[]) list2.ToArray(typeof(Activity));
        }

        protected override void Initialize()
        {
            base.Initialize();
            IDesignerLoaderHost loaderHost = base.LoaderHost;
            if (loaderHost > null)
            {
                loaderHost.RemoveService(typeof(IIdentifierCreationService));
                loaderHost.AddService(typeof(IIdentifierCreationService), new IdentifierCreationService(loaderHost));
                loaderHost.AddService(typeof(IMenuCommandService), new WorkflowMenuCommandService(loaderHost, this));
                loaderHost.AddService(typeof(IToolboxService), new Toolbox(loaderHost));
                TypeProvider serviceInstance = new TypeProvider(loaderHost);
                serviceInstance.AddAssemblyReference(typeof(string).Assembly.Location);
                serviceInstance.AddAssemblyReference(typeof(IfElseTest).Assembly.Location);
                loaderHost.AddService(typeof(ITypeProvider), serviceInstance, true);
                loaderHost.AddService(typeof(IEventBindingService), new EventBindingService());
                loaderHost.AddService(typeof(IPropertyValueUIService), new PropertyValueUIService());
            }
        }

        public void PerformFlush()
        {
            IDesignerHost service = (IDesignerHost) base.GetService(typeof(IDesignerHost));
            if ((service != null) && (service.RootComponent > null))
            {
                Activity rootComponent = service.RootComponent as Activity;
                if (rootComponent > null)
                {
                    using (XmlWriter writer = XmlWriter.Create(this.xomlFile))
                    {
                        new WorkflowMarkupSerializer().Serialize(writer, rootComponent);
                    }
                }
            }
        }

        protected override void PerformFlush(IDesignerSerializationManager manager)
        {
        }

        protected override void PerformLoad(IDesignerSerializationManager serializationManager)
        {
            IDesignerHost service = (IDesignerHost) base.GetService(typeof(IDesignerHost));
            Activity activity = null;
            if (this.WorkflowType != null)
            {
                activity = (Activity) Activator.CreateInstance(this.WorkflowType);
            }
            else
            {
                TextReader input = new StringReader(this.xoml);
                try
                {
                    using (XmlReader reader2 = XmlReader.Create(input))
                    {
                        WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();
                        activity = serializer.Deserialize(reader2) as Activity;
                    }
                }
                finally
                {
                    input.Close();
                }
            }
            if ((activity != null) && (service > null))
            {
                AddObjectGraphToDesignerHost(service, activity);
            }
        }

        public string DefaultNamespace =>
            "SampleNamespace";

        public string Xoml
        {
            get => 
                this.xoml;
            set => 
                this.xoml = value;
        }

        public Type WorkflowType
        {
            get => 
                this.workflowType;
            set => 
                this.workflowType = value;
        }

        public string XomlFile
        {
            get => 
                this.xomlFile;
            set => 
                this.xomlFile = value;
        }

        public override string FileName =>
            string.Empty;
    }
}

