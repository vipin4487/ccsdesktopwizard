namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Workflow.ComponentModel.Compiler;

    internal sealed class ProactiveButtonValidator : ActivityValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors = base.Validate(manager, obj);
            ProactiveButton button = (ProactiveButton) obj;
            if (button == null)
            {
                throw new ArgumentException("obj");
            }
            if (button.Parent != null)
            {
                if (button.InputParameters == null)
                {
                }
                if (button.OutputParameters == null)
                {
                }
            }
            return errors;
        }
    }
}

