namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Compiler;

    internal sealed class IfElseValidator : CompositeActivityValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors = base.Validate(manager, obj);
            IfElseTest test = obj as IfElseTest;
            if (test == null)
            {
                throw new ArgumentException("obj");
            }
            if (test.Parent != null)
            {
                if (test.EnabledActivities.Count < 1)
                {
                    errors.Add(new ValidationError("A IfElseTest activity must have at least one child of type IfElseBranch.", 0x50c));
                }
                foreach (Activity activity in test.EnabledActivities)
                {
                    if (!(activity is IfElseBranch))
                    {
                        errors.Add(new ValidationError("All children must be of type IfElseBranch.", 0x50d));
                        return errors;
                    }
                }
            }
            return errors;
        }

        public override ValidationError ValidateActivityChange(Activity activity, ActivityChangeAction action)
        {
            if (activity == null)
            {
                throw new ArgumentNullException("activity");
            }
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            if ((activity.ExecutionStatus != ActivityExecutionStatus.Initialized) && (activity.ExecutionStatus != ActivityExecutionStatus.Closed))
            {
                return new ValidationError(string.Format("CompositeActivity '{0}' status is currently '{1}'. Dynamic modifications are allowed only when the activity status is 'Enabled' or 'Suspended'.", activity.QualifiedName, activity.ExecutionStatus.ToString()), 260);
            }
            return null;
        }
    }
}

