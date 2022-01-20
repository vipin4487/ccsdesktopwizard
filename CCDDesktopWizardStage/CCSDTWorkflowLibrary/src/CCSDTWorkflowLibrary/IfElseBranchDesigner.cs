namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Collections.ObjectModel;
    using System.Workflow.ComponentModel.Design;

    internal sealed class IfElseBranchDesigner : SequentialActivityDesigner
    {
        public override bool CanBeParentedTo(CompositeActivityDesigner parentActivityDesigner)
        {
            if (ReferenceEquals(parentActivityDesigner, null))
            {
                throw new ArgumentNullException("parentActivity");
            }
            return ((parentActivityDesigner.Activity is IfElseTest) ? base.CanBeParentedTo(parentActivityDesigner) : false);
        }

        public override ReadOnlyCollection<DesignerView> Views
        {
            get
            {
                DesignerView[] list = new DesignerView[] { base.Views[0] };
                return new ReadOnlyCollection<DesignerView>(list);
            }
        }

        protected override string HelpText =>
            "Drop Controls Here";
    }
}

