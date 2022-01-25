namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Compiler;

    [ActivityValidator(typeof(ValidateButtonValidator))]
    public class ValidateButton : ButtonBase
    {
        public static readonly DependencyProperty InputParametersProperty = DependencyProperty.Register("InputParameters", typeof(ArrayList), typeof(ValidateButton), new PropertyMetadata(DependencyPropertyOptions.Metadata));
        public static readonly DependencyProperty OutputParametersProperty = DependencyProperty.Register("OutputParameters", typeof(ArrayList), typeof(ValidateButton), new PropertyMetadata(DependencyPropertyOptions.Metadata));
        private string dataConnection;

        [Browsable(true), Category("General"), Description("Name of the control."), ReadOnly(true)]
        public string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }

        [TypeConverter(typeof(StringListConverter)), DefaultValue("{none}"), Category("Connections"), Description("The name of the data connection to use.  This is a required field.")]
        public string DataConnection
        {
            get
            {
                return this.dataConnection;
            }
            set
            {
                this.dataConnection = value;
            }
        }

        [Editor(typeof(ParameterArrayListEditor), typeof(UITypeEditor)), Category("Parameters"), Description("Please the input parameters to validate."), DefaultValue((string) null), RefreshProperties(RefreshProperties.Repaint)]
        public ArrayList InputParameters
        {
            get
            {
                return (base.GetValue(InputParametersProperty) as ArrayList);
            }
            set
            {
                base.SetValue(InputParametersProperty, value);
            }
        }

        [Editor(typeof(ParameterArrayListEditor), typeof(UITypeEditor)), Category("Parameters"), Description("Please the output parameters from validate."), DefaultValue((string) null), RefreshProperties(RefreshProperties.Repaint)]
        public ArrayList OutputParameters
        {
            get
            {
                return (base.GetValue(OutputParametersProperty) as ArrayList);
            }
            set
            {
                base.SetValue(OutputParametersProperty, value);
            }
        }

        [Browsable(false), Description("Number to dial if not using routing services (VDN).")]
        public string NumberToDial
        {
            get
            {
                return base.NumberToDial;
            }
            set
            {
                base.NumberToDial = value;
            }
        }

        public class StringListConverter : TypeConverter
        {
            public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                ArrayList values = new ArrayList();
                foreach (object obj2 in context.Container.Components)
                {
                    if (obj2 is CustomCCSDTWorkflowBase)
                    {
                        values = new ArrayList(((CustomCCSDTWorkflowBase) obj2).CallVariableNames);
                    }
                }
                values.Insert(0, "{none}");
                return new TypeConverter.StandardValuesCollection(values);
            }

            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }
        }
    }
}

