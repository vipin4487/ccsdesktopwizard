namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing.Design;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Compiler;

    [ActivityValidator(typeof(EmailButtonValidator))]
    public class EmailButton : ButtonBase
    {
        public static readonly DependencyProperty ToAddressesProperty = DependencyProperty.Register("ToAddresses", typeof(string), typeof(EmailButton), new PropertyMetadata(DependencyPropertyOptions.Metadata));
        private string ccAddress;
        private string subject;
        private string bodyText;
        private bool attachLogs;
        private bool screenShot;
        private bool autoSend;

        [Browsable(true), Category("General"), Description("Name of the control."), ReadOnly(true)]
        public string Name
        {
            get => 
                base.Name;
            set => 
                base.Name = value;
        }

        [Browsable(true), Category("Parameters"), Description("List of 'To' email addresses, use a semicolon for a separator.")]
        public string ToAddresses
        {
            get => 
                base.GetValue(ToAddressesProperty) as string;
            set => 
                base.SetValue(ToAddressesProperty, value);
        }

        [Browsable(true), Category("Parameters"), Description("List of 'CC' email addresses, use a semicolon for a separator.")]
        public string CCAddresses
        {
            get => 
                this.ccAddress;
            set => 
                this.ccAddress = value;
        }

        [Browsable(true), Category("Parameters"), Description("Subject for the email.")]
        public string Subject
        {
            get => 
                this.subject;
            set => 
                this.subject = value;
        }

        [Browsable(true), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("Parameters"), Description(@"Body of the email.  Will be inserted within <HTML><BODY> <\BODY><\HTML> tags.")]
        public string HTMLBodyText
        {
            get => 
                this.bodyText;
            set => 
                this.bodyText = value;
        }

        [Browsable(true), DefaultValue(false), Description("Attach CCSDT log files to the email.")]
        public bool AttachLogFiles
        {
            get => 
                this.attachLogs;
            set => 
                this.attachLogs = value;
        }

        [Browsable(true), DefaultValue(false), Description("Attach screen shot to the email.")]
        public bool AttachScreenShot
        {
            get => 
                this.screenShot;
            set => 
                this.screenShot = value;
        }

        [Browsable(true), DefaultValue(false), Description("Send email without allowing user changes.")]
        public bool AutoSend
        {
            get => 
                this.autoSend;
            set => 
                this.autoSend = value;
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
                ArrayList values = new ArrayList();
                foreach (object obj2 in context.Container.Components)
                {
                    if (obj2 is CustomCCSDTWorkflowBase)
                    {
                        values = new ArrayList(((CustomCCSDTWorkflowBase) obj2).CallVariableList);
                    }
                }
                values.Insert(0, "{none}");
                return new TypeConverter.StandardValuesCollection(values);
            }

            public override bool GetStandardValuesSupported(ITypeDescriptorContext context) => 
                true;
        }
    }
}

