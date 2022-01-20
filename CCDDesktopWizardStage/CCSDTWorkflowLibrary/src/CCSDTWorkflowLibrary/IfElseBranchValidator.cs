namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Workflow.ComponentModel.Compiler;

    internal sealed class IfElseBranchValidator : CompositeActivityValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors2;
            ValidationErrorCollection errors = base.Validate(manager, obj);
            IfElseBranch item = (IfElseBranch) obj;
            IfElseTest parent = item.Parent as IfElseTest;
            if (ReferenceEquals(parent, null))
            {
                errors2 = errors;
            }
            else
            {
                int index = parent.Activities.IndexOf(item);
                if (((parent.Activities.Count <= 1) || (index < (parent.Activities.Count - 1))) ? ReferenceEquals(item.Criteria, null) : false)
                {
                    errors.Add(ValidationError.GetNotSetValidationError("Criteria"));
                }
                errors2 = errors;
            }
            return errors2;
        }
    }
}

