namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Workflow.ComponentModel.Compiler;

    internal sealed class ProactiveButtonValidator : ActivityValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors2;
            ValidationErrorCollection errors = base.Validate(manager, obj);
            ProactiveButton objA = (ProactiveButton) obj;
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
                }
                if (ReferenceEquals(objA.OutputParameters, null))
                {
                }
                errors2 = errors;
            }
            return errors2;
        }
    }
}

