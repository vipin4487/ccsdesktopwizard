namespace CCSDTWorkflowWizard
{
    using System;
    using System.Collections;
    using System.ComponentModel.Design.Serialization;
    using System.Windows.Forms;

    internal class DesignerSerializationService : IDesignerSerializationService
    {
        private IServiceProvider serviceProvider;

        public DesignerSerializationService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICollection Deserialize(object serializationData)
        {
            SerializationStore store = serializationData as SerializationStore;
            if (store > null)
            {
                ComponentSerializationService service = this.serviceProvider.GetService(typeof(ComponentSerializationService)) as ComponentSerializationService;
                return service.Deserialize(store);
            }
            return new object[0];
        }

        public object Serialize(ICollection objects)
        {
            ComponentSerializationService service = this.serviceProvider.GetService(typeof(ComponentSerializationService)) as ComponentSerializationService;
            using (SerializationStore store2 = service.CreateStore())
            {
                foreach (object obj2 in objects)
                {
                    if (obj2 is Control)
                    {
                        service.Serialize(store2, obj2);
                    }
                }
                return store2;
            }
        }
    }
}

