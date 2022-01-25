namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;

    public class StandardDialButton : ButtonBase
    {
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

        [Browsable(true), Category("General"), Description("Description for internal use.")]
        public string Description
        {
            get
            {
                return base.Description;
            }
            set
            {
                base.Description = value;
            }
        }

        [Browsable(true), Category("General"), Description("Enable/disable the control.")]
        public bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
            }
        }
    }
}

