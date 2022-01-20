namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing.Design;
    using System.Workflow.Activities;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Compiler;

    [Designer(typeof(IfElseBranchDesigner), typeof(IDesigner)), ActivityValidator(typeof(IfElseBranchValidator)), ToolboxItem(false), Category("Standard")]
    public sealed class IfElseBranch : SequenceActivity
    {
        public static readonly DependencyProperty CriteriaProperty = DependencyProperty.Register("Criteria", typeof(ArrayList), typeof(IfElseBranch), new PropertyMetadata(DependencyPropertyOptions.Metadata));

        public IfElseBranch()
        {
        }

        public IfElseBranch(string name) : base(name)
        {
        }

        [Browsable(true), Category("General"), Description("Name of the control.")]
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

        [Editor(typeof(CriteriaArrayListEditor), typeof(UITypeEditor)), Category("Criteria to test"), Description("Please specify the Criteria for this branch."), DefaultValue((string) null), RefreshProperties(RefreshProperties.Repaint)]
        public ArrayList Criteria
        {
            get => 
                base.GetValue(CriteriaProperty) as ArrayList;
            set => 
                base.SetValue(CriteriaProperty, value);
        }
    }
}

