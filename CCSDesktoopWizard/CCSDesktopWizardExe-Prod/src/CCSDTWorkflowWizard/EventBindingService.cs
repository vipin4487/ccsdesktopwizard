namespace CCSDTWorkflowWizard
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;

    internal class EventBindingService : IEventBindingService
    {
        public string CreateUniqueMethodName(IComponent component, EventDescriptor e) => 
            e.DisplayName;

        public ICollection GetCompatibleMethods(EventDescriptor e) => 
            new ArrayList();

        public EventDescriptor GetEvent(PropertyDescriptor property) => 
            (property is EventPropertyDescriptor) ? ((EventPropertyDescriptor) property).EventDescriptor : null;

        public PropertyDescriptorCollection GetEventProperties(EventDescriptorCollection events) => 
            new PropertyDescriptorCollection(new PropertyDescriptor[0], true);

        public PropertyDescriptor GetEventProperty(EventDescriptor e) => 
            new EventPropertyDescriptor(e);

        public bool ShowCode() => 
            false;

        public bool ShowCode(int lineNumber) => 
            false;

        public bool ShowCode(IComponent component, EventDescriptor e) => 
            false;

        private class EventPropertyDescriptor : PropertyDescriptor
        {
            private System.ComponentModel.EventDescriptor eventDescriptor;

            public EventPropertyDescriptor(System.ComponentModel.EventDescriptor eventDescriptor) : base(eventDescriptor, null)
            {
                this.eventDescriptor = eventDescriptor;
            }

            public override bool CanResetValue(object component) => 
                false;

            public override object GetValue(object component) => 
                null;

            public override void ResetValue(object component)
            {
            }

            public override void SetValue(object component, object value)
            {
            }

            public override bool ShouldSerializeValue(object component) => 
                false;

            public System.ComponentModel.EventDescriptor EventDescriptor =>
                this.eventDescriptor;

            public override Type ComponentType =>
                this.eventDescriptor.ComponentType;

            public override Type PropertyType =>
                this.eventDescriptor.EventType;

            public override bool IsReadOnly =>
                true;
        }
    }
}

