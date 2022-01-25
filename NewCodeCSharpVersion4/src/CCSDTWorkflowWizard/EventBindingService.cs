namespace CCSDTWorkflowWizard
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;

    internal class EventBindingService : IEventBindingService
    {
        public string CreateUniqueMethodName(IComponent component, EventDescriptor e)
        {
            return e.DisplayName;
        }

        public ICollection GetCompatibleMethods(EventDescriptor e)
        {
            return new ArrayList();
        }

        public EventDescriptor GetEvent(PropertyDescriptor property)
        {
            return ((property is EventPropertyDescriptor) ? ((EventPropertyDescriptor) property).EventDescriptor : null);
        }

        public PropertyDescriptorCollection GetEventProperties(EventDescriptorCollection events)
        {
            return new PropertyDescriptorCollection(new PropertyDescriptor[0], true);
        }

        public PropertyDescriptor GetEventProperty(EventDescriptor e)
        {
            return new EventPropertyDescriptor(e);
        }

        public bool ShowCode()
        {
            return false;
        }

        public bool ShowCode(int lineNumber)
        {
            return false;
        }

        public bool ShowCode(IComponent component, EventDescriptor e)
        {
            return false;
        }

        private class EventPropertyDescriptor : PropertyDescriptor
        {
            private System.ComponentModel.EventDescriptor eventDescriptor;

            public EventPropertyDescriptor(System.ComponentModel.EventDescriptor eventDescriptor) : base(eventDescriptor, null)
            {
                this.eventDescriptor = eventDescriptor;
            }

            public override bool CanResetValue(object component)
            {
                return false;
            }

            public override object GetValue(object component)
            {
                return null;
            }

            public override void ResetValue(object component)
            {
            }

            public override void SetValue(object component, object value)
            {
            }

            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }

            public System.ComponentModel.EventDescriptor EventDescriptor
            {
                get
                {
                    return this.eventDescriptor;
                }
            }

            public override Type ComponentType
            {
                get
                {
                    return this.eventDescriptor.ComponentType;
                }
            }

            public override Type PropertyType
            {
                get
                {
                    return this.eventDescriptor.EventType;
                }
            }

            public override bool IsReadOnly
            {
                get
                {
                    return true;
                }
            }
        }
    }
}

