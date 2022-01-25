namespace CCSDTWorkflowWizard
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing.Design;

    internal class PropertyValueUIService : IPropertyValueUIService
    {
        private PropertyValueUIHandler _handler;
        private EventHandler _notifyHandler;
        private ArrayList _itemList;

        public event EventHandler PropertyUIValueItemsChanged;

        public void AddPropertyValueUIHandler(PropertyValueUIHandler newHandler)
        {
            if (newHandler == null)
            {
                throw new ArgumentNullException("newHandler");
            }
            this._handler = (PropertyValueUIHandler) Delegate.Combine(this._handler, newHandler);
        }

        public PropertyValueUIItem[] GetPropertyUIValueItems(ITypeDescriptorContext context, PropertyDescriptor propDesc)
        {
            if (propDesc == null)
            {
                throw new ArgumentNullException("propDesc");
            }
            if (this._handler == null)
            {
                return new PropertyValueUIItem[0];
            }
            PropertyValueUIService service = this;
            lock (service)
            {
                if (this._itemList == null)
                {
                    this._itemList = new ArrayList();
                }
                this._handler(context, propDesc, this._itemList);
                int count = this._itemList.Count;
                if (count > 0)
                {
                    PropertyValueUIItem[] array = new PropertyValueUIItem[count];
                    this._itemList.CopyTo(array, 0);
                    this._itemList.Clear();
                    return array;
                }
            }
            return null;
        }

        public void NotifyPropertyValueUIItemsChanged()
        {
            if (this._notifyHandler > null)
            {
                this._notifyHandler(this, EventArgs.Empty);
            }
        }

        public void RemovePropertyValueUIHandler(PropertyValueUIHandler newHandler)
        {
            if (newHandler == null)
            {
                throw new ArgumentNullException("newHandler");
            }
            this._handler = (PropertyValueUIHandler) Delegate.Remove(this._handler, newHandler);
        }
    }
}

