namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;

    public class ColdTransferButton : ButtonBase
    {
        [Browsable(true), Category("General"), Description("Name of the control."), ReadOnly(true)]
        public string Name
        {
            get => 
                base.Name;
            set => 
                base.Name = value;
        }

        [Browsable(true), Category("General"), Description("Description for internal use.")]
        public string Description
        {
            get => 
                base.Description;
            set => 
                base.Description = value;
        }

        [Browsable(true), Category("General"), Description("Enable/disable the control.")]
        public bool Enabled
        {
            get => 
                base.Enabled;
            set => 
                base.Enabled = value;
        }
    }
}

