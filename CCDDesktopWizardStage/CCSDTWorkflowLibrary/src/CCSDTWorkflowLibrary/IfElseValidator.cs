namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Compiler;

    internal sealed class IfElseValidator : CompositeActivityValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors2;
            ValidationErrorCollection errors = base.Validate(manager, obj);
            IfElseTest objA = obj as IfElseTest;
            if (ReferenceEquals(objA, null))
            {
                throw new ArgumentException("obj");
            }
            if (!ReferenceEquals(objA.Parent, null))
            {
                if (objA.EnabledActivities.Count < 1)
                {
                    errors.Add(new ValidationError("A IfElseTest activity must have at least one child of type IfElseBranch.", 0x50c));
                }
                using (IEnumerator<Activity> enumerator = objA.EnabledActivities.GetEnumerator())
                {
                    while (true)
                    {
                        if (!enumerator.MoveNext())
                        {
                            break;
                        }
                        Activity current = enumerator.Current;
                        if (!(current is IfElseBranch))
                        {
                            errors.Add(new ValidationError("All children must be of type IfElseBranch.", 0x50d));
                            return errors;
                        }
                    }
                }
                errors2 = errors;
            }
            else
            {
                errors2 = errors;
            }
            return errors2;
        }

        public override ValidationError ValidateActivityChange(Activity activity, ActivityChangeAction action)
        {
            if (ReferenceEquals(activity, null))
            {
                throw new ArgumentNullException("activity");
            }
            if (ReferenceEquals(action, null))
            {
                throw new ArgumentNullException("action");
            }
            return (((activity.ExecutionStatus == ActivityExecutionStatus.Initialized) || (activity.ExecutionStatus == ActivityExecutionStatus.Closed)) ? null : new ValidationError($"CompositeActivity '{activity.QualifiedName}' status is currently '{activity.ExecutionStatus.ToString()}'. Dynamic modifications are allowed only when the activity status is 'Enabled' or 'Suspended'.", 260));
        }
    }
}

