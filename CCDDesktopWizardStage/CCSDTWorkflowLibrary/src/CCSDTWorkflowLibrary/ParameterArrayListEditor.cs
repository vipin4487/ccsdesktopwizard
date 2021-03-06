namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    public class ParameterArrayListEditor : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            try
            {
                IWindowsFormsEditorService service = null;
                if (((context != null) && (provider != null)) && (context.Instance != null))
                {
                    service = (IWindowsFormsEditorService) provider.GetService(typeof(IWindowsFormsEditorService));
                }
                if (service != null)
                {
                    IDesignerHost host = provider.GetService(typeof(IDesignerHost)) as IDesignerHost;
                    if (!string.IsNullOrEmpty(host.RootComponentClassName))
                    {
                        bool outputParameters = context.PropertyDescriptor.Name.StartsWith("Output");
                        ParameterEditorDlg dlg = new ParameterEditorDlg((CustomCCSDTWorkflowBase) host.RootComponent, outputParameters) {
                            ParameterList = (ArrayList) value
                        };
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            value = dlg.ParameterList;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception exception1)
            {
                MessageBox.Show(exception1.ToString());
            }
            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) => 
            UITypeEditorEditStyle.Modal;
    }
}

