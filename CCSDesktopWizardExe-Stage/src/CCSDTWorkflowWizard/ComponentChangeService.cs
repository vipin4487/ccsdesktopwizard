namespace CCSDTWorkflowWizard
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;

    internal class ComponentChangeService : IComponentChangeService
    {
        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event ComponentEventHandler ComponentAdded;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event ComponentEventHandler ComponentAdding;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event ComponentChangedEventHandler ComponentChanged;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event ComponentChangingEventHandler ComponentChanging;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event ComponentEventHandler ComponentRemoved;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event ComponentEventHandler ComponentRemoving;

        [field: CompilerGenerated, DebuggerBrowsable(0)]
        public event ComponentRenameEventHandler ComponentRename;

        public void OnComponentChanged(object component, MemberDescriptor member, object oldValue, object newValue)
        {
            if (this.ComponentChanged > null)
            {
                this.ComponentChanged(this, new ComponentChangedEventArgs(component, member, oldValue, newValue));
            }
        }

        public void OnComponentChanging(object component, MemberDescriptor member)
        {
            if (this.ComponentChanging > null)
            {
                this.ComponentChanging(this, new ComponentChangingEventArgs(component, member));
            }
        }

        internal void OnComponentRename(object component, string oldName, string newName)
        {
            if (this.ComponentRename > null)
            {
                this.ComponentRename(this, new ComponentRenameEventArgs(component, oldName, newName));
            }
        }
    }
}

