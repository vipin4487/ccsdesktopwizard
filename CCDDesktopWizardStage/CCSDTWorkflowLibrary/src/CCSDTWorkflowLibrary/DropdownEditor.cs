namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing.Design;

    public class DropdownEditor : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) => 
            base.EditValue(context, provider, value);

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) => 
            base.GetEditStyle(context);
    }
}

