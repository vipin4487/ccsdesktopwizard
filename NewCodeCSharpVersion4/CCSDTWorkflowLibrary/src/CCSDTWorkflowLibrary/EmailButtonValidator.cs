namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Net.Mail;
    using System.Workflow.ComponentModel.Compiler;

    internal sealed class EmailButtonValidator : ActivityValidator
    {
        public override ValidationErrorCollection Validate(ValidationManager manager, object obj)
        {
            ValidationErrorCollection errors = base.Validate(manager, obj);
            EmailButton button = (EmailButton) obj;
            if (button == null)
            {
                throw new ArgumentException("obj");
            }
            if (button.Parent != null)
            {
                if ((button.ToAddresses == null) || (button.ToAddresses.Length == 0))
                {
                    errors.Add(ValidationError.GetNotSetValidationError("ToAddresses"));
                }
                else
                {
                    try
                    {
                        char[] separator = new char[] { ';' };
                        string[] strArray = button.ToAddresses.Split(separator);
                        foreach (string str in strArray)
                        {
                            new MailAddress(str);
                        }
                    }
                    catch
                    {
                        ValidationError item = new ValidationError("Invalid email address '" + button.ToAddresses + "'.", 1, false, "ToAddresses");
                        errors.Add(item);
                    }
                }
                if ((button.CCAddresses != null) && (button.CCAddresses.Length > 0))
                {
                    try
                    {
                        char[] separator = new char[] { ';' };
                        string[] strArray3 = button.CCAddresses.Split(separator);
                        foreach (string str2 in strArray3)
                        {
                            new MailAddress(str2);
                        }
                    }
                    catch
                    {
                        ValidationError item = new ValidationError("Invalid email address '" + button.CCAddresses + "'.", 1, false, "CCAddresses");
                        errors.Add(item);
                    }
                }
            }
            return errors;
        }
    }
}

