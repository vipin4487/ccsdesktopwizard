namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Compiler;

    [ActivityValidator(typeof(IfElseValidator)), Designer(typeof(IfElseDesigner), typeof(IDesigner)), ToolboxItem(typeof(IfElseToolboxItem)), ToolboxBitmap(typeof(Calendar), "Images.StopLightYellowRedAmberGreen.png"), Category("Standard"), Description("Displays contained controls based on criteria specified.")]
    public sealed class IfElseTest : CompositeActivity, IActivityEventListener<ActivityExecutionStatusChangedEventArgs>
    {
        public IfElseTest()
        {
        }

        public IfElseTest(string name) : base(name)
        {
        }

        protected override ActivityExecutionStatus Cancel(ActivityExecutionContext executionContext)
        {
            ActivityExecutionStatus closed = ActivityExecutionStatus.Closed;
            foreach (IfElseBranch branch in base.EnabledActivities)
            {
                if (branch.ExecutionStatus == ActivityExecutionStatus.Executing)
                {
                    closed = ActivityExecutionStatus.Canceling;
                    executionContext.CancelActivity(branch);
                    return closed;
                }
                if ((branch.ExecutionStatus == ActivityExecutionStatus.Canceling) || (branch.ExecutionStatus == ActivityExecutionStatus.Faulting))
                {
                    return ActivityExecutionStatus.Canceling;
                }
            }
            return closed;
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            ActivityExecutionStatus closed = ActivityExecutionStatus.Closed;
            if (executionContext == null)
            {
                throw new ArgumentNullException("executionContext");
            }
            foreach (IfElseBranch branch in base.EnabledActivities)
            {
                if (branch.Criteria == null)
                {
                    closed = ActivityExecutionStatus.Executing;
                    branch.RegisterForStatusChange(Activity.ClosedEvent, this);
                    executionContext.ExecuteActivity(branch);
                    return closed;
                }
            }
            return closed;
        }

        public void OnEvent(object sender, ActivityExecutionStatusChangedEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException("sender");
            }
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }
            ActivityExecutionContext context = sender as ActivityExecutionContext;
            if (context == null)
            {
                throw new ArgumentException("The sender parameter must be of type ActivityExecutionContext.");
            }
            context.CloseActivity();
        }

        [Browsable(true), Category("General"), Description("Name of the control.")]
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

