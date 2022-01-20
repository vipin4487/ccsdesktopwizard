namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Workflow.ComponentModel.Design;

    public class CustomWorkflowDesigner : SequentialWorkflowRootDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            int count = properties.Count;
        }

        protected override void PreFilterEvents(IDictionary events)
        {
            int count = events.Count;
            events.Remove("Initialized");
            events.Remove("Completed");
        }

        protected override void PreFilterProperties(IDictionary properties)
        {
            int count = properties.Count;
            properties.Remove("BaseActivityType");
        }

        public override ReadOnlyCollection<DesignerView> Views
        {
            get
            {
                DesignerView[] list = new DesignerView[] { base.Views[0] };
                return new ReadOnlyCollection<DesignerView>(list);
            }
        }

        protected override SequentialWorkflowHeaderFooter Header
        {
            get
            {
                SequentialWorkflowHeaderFooter header = base.Header;
                header.Text = !(base.Activity is AuxCodePopWorkflow) ? (!(base.Activity is ScreenPopWorkflow) ? (!(base.Activity is SmartRedirectWorkflow) ? "VCC Desktop Workflow" : "Smart Redirect Workflow") : "Screen Pop Workflow") : "Aux Code Pop Workflow";
                return header;
            }
        }

        protected override string HelpText =>
            "Drop Controls Here";
    }
}

