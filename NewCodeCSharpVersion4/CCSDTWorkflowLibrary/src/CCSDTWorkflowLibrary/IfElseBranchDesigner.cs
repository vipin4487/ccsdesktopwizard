namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Collections.ObjectModel;
    using System.Workflow.ComponentModel.Design;

    internal sealed class IfElseBranchDesigner : SequentialActivityDesigner
    {
        public override bool CanBeParentedTo(CompositeActivityDesigner parentActivityDesigner)
        {
            if (parentActivityDesigner == null)
            {
                throw new ArgumentNullException("parentActivity");
            }
            return ((parentActivityDesigner.Activity is IfElseTest) && base.CanBeParentedTo(parentActivityDesigner));
        }

        public override ReadOnlyCollection<DesignerView> Views
        {
            get
            {
                return new ReadOnlyCollection<DesignerView>(new DesignerView[] { base.Views[0] });
            }
        }

        protected override string HelpText
        {
            get
            {
                return "Drop Controls Here";
            }
        }
    }
}

