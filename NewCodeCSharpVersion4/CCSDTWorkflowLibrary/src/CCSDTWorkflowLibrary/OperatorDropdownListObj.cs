namespace CCSDTWorkflowLibrary
{
    using System;

    public class OperatorDropdownListObj
    {
        private OperatorType intValue;
        private string text;

        public OperatorDropdownListObj(OperatorType numericValue, string displayedText)
        {
            this.intValue = numericValue;
            this.text = displayedText;
        }

        public override string ToString()
        {
            return (this.intValue.ToString() + " - " + this.text);
        }

        public OperatorType NumericValue
        {
            get
            {
                return this.intValue;
            }
        }

        public string DisplayedText
        {
            get
            {
                return this.text;
            }
        }
    }
}

