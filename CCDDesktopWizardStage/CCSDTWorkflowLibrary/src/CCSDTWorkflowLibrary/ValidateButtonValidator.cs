namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Workflow.ComponentModel.Compiler;

    internal sealed class ValidateButtonValidator : ActivityValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors2;
            ValidationErrorCollection errors = base.Validate(manager, obj);
            ValidateButton objA = (ValidateButton) obj;
            if (ReferenceEquals(objA, null))
            {
                throw new ArgumentException("obj");
            }
            if (ReferenceEquals(objA.Parent, null))
            {
                errors2 = errors;
            }
            else
            {
                if (ReferenceEquals(objA.InputParameters, null))
                {
                    errors.Add(ValidationError.GetNotSetValidationError("InputParameters"));
                }
                if (ReferenceEquals(objA.OutputParameters, null))
                {
                    errors.Add(ValidationError.GetNotSetValidationError("OutputParameters"));
                }
                errors2 = errors;
            }
            return errors2;
        }
    }
}

