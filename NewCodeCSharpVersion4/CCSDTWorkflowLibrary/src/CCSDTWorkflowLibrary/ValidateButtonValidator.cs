namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Workflow.ComponentModel.Compiler;

    internal sealed class ValidateButtonValidator : ActivityValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors = base.Validate(manager, obj);
            ValidateButton button = (ValidateButton) obj;
            if (button == null)
            {
                throw new ArgumentException("obj");
            }
            if (button.Parent != null)
            {
                if (button.InputParameters == null)
                {
                    errors.Add(ValidationError.GetNotSetValidationError("InputParameters"));
                }
                if (button.OutputParameters == null)
                {
                    errors.Add(ValidationError.GetNotSetValidationError("OutputParameters"));
                }
            }
            return errors;
        }
    }
}

