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
            EmailButton objA = (EmailButton) obj;
            if (ReferenceEquals(objA, null))
            {
                throw new ArgumentException("obj");
            }
            if (!ReferenceEquals(objA.Parent, null))
            {
                if ((objA.ToAddresses == null) || (objA.ToAddresses.Length == 0))
                {
                    errors.Add(ValidationError.GetNotSetValidationError("ToAddresses"));
                }
                else
                {
                    try
                    {
                        char[] separator = new char[] { ';' };
                        foreach (string str in objA.ToAddresses.Split(separator))
                        {
                            MailAddress address1 = new MailAddress(str);
                        }
                    }
                    catch
                    {
                        errors.Add(new ValidationError("Invalid email address '" + objA.ToAddresses + "'.", 1, false, "ToAddresses"));
                    }
                }
            }
            else
            {
                return errors;
            }
            if ((objA.CCAddresses != null) && (objA.CCAddresses.Length > 0))
            {
                try
                {
                    char[] separator = new char[] { ';' };
                    foreach (string str2 in objA.CCAddresses.Split(separator))
                    {
                        MailAddress address2 = new MailAddress(str2);
                    }
                }
                catch
                {
                    errors.Add(new ValidationError("Invalid email address '" + objA.CCAddresses + "'.", 1, false, "CCAddresses"));
                }
            }
            return errors;
        }
    }
}

