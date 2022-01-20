namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Compiler;

    [ActivityValidator(typeof(ProactiveButtonValidator))]
    public class ProactiveButton : ButtonBase
    {
        public static readonly DependencyProperty InputParametersProperty = DependencyProperty.Register("InputParameters", typeof(ArrayList), typeof(ProactiveButton), new PropertyMetadata(DependencyPropertyOptions.Metadata));
        public static readonly DependencyProperty OutputParametersProperty = DependencyProperty.Register("OutputParameters", typeof(ArrayList), typeof(ProactiveButton), new PropertyMetadata(DependencyPropertyOptions.Metadata));
        private string commandName;

        [Browsable(true), Category("General"), Description("Name of the control."), ReadOnly(true)]
        public string Name
        {
            get => 
                base.Name;
            set => 
                base.Name = value;
        }

        [TypeConverter(typeof(StringListConverter)), DefaultValue("{none}"), Category("Proactive"), Description("The name of the Proactive command to run.  This is a required field.")]
        public string CommandToRun
        {
            get => 
                this.commandName;
            set => 
                this.commandName = value;
        }

        [Editor(typeof(ParameterArrayListEditor), typeof(UITypeEditor)), Category("Parameters"), Description("Enter the input parameters for the command."), DefaultValue((string) null), RefreshProperties(RefreshProperties.Repaint)]
        public ArrayList InputParameters
        {
            get => 
                base.GetValue(InputParametersProperty) as ArrayList;
            set => 
                base.SetValue(InputParametersProperty, value);
        }

        [Editor(typeof(ParameterArrayListEditor), typeof(UITypeEditor)), Category("Parameters"), Description("Enter the output parameters from the command."), DefaultValue((string) null), RefreshProperties(RefreshProperties.Repaint)]
        public ArrayList OutputParameters
        {
            get => 
                base.GetValue(OutputParametersProperty) as ArrayList;
            set => 
                base.SetValue(OutputParametersProperty, value);
        }

        [Browsable(false), Description("Number to dial if not using routing services (VDN).")]
        public string NumberToDial
        {
            get => 
                base.NumberToDial;
            set => 
                base.NumberToDial = value;
        }

        public class StringListConverter : TypeConverter
        {
            public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                ArrayList values = new ArrayList { 
                    "AttachJob",
                    "AvailWork",
                    "ConnHeadset",
                    "DetachJob",
                    "DialDigit",
                    "DisconnHeadset",
                    "DoNotCall",
                    "FinishedItem",
                    "HangupCall",
                    "HoldCall",
                    "ListCallbackFmt",
                    "ListDataFields",
                    "ListKeys",
                    "ListState",
                    "ListJobs",
                    "ListTenants",
                    "Login",
                    "Logoff",
                    "ManagedCall",
                    "ManualCall",
                    "NoFurtherWork",
                    "ReadField",
                    "ReadyNextItem",
                    "ReleaseLine",
                    "SetCallback",
                    "SetDataField",
                    "SetPassword",
                    "SetTenant",
                    "TransferCall",
                    "UnholdCall",
                    "UpdateField"
                };
                values.Insert(0, "{none}");
                return new TypeConverter.StandardValuesCollection(values);
            }

            public override bool GetStandardValuesSupported(ITypeDescriptorContext context) => 
                true;
        }
    }
}

