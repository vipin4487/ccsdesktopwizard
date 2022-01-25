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
                return new ReadOnlyCollection<DesignerView>(new DesignerView[] { base.Views[0] });
            }
        }

        protected override SequentialWorkflowHeaderFooter Header
        {
            get
            {
                SequentialWorkflowHeaderFooter header = base.Header;
                if (base.Activity is AuxCodePopWorkflow)
                {
                    header.Text = "Aux Code Pop Workflow";
                    return header;
                }
                if (base.Activity is ScreenPopWorkflow)
                {
                    header.Text = "Screen Pop Workflow";
                    return header;
                }
                if (base.Activity is SmartRedirectWorkflow)
                {
                    header.Text = "Smart Redirect Workflow";
                    return header;
                }
                header.Text = "VCC Desktop Workflow";
                return header;
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

