namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Workflow.ComponentModel.Compiler;

    internal sealed class IfElseBranchValidator : CompositeActivityValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors = base.Validate(manager, obj);
            IfElseBranch item = (IfElseBranch) obj;
            IfElseTest parent = item.Parent as IfElseTest;
            if (parent != null)
            {
                int index = parent.Activities.IndexOf(item);
                if (((parent.Activities.Count <= 1) || (index < (parent.Activities.Count - 1))) && (item.Criteria == null))
                {
                    errors.Add(ValidationError.GetNotSetValidationError("Criteria"));
                }
            }
            return errors;
        }
    }
}

