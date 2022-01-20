namespace CCSDTWorkflowLibrary
{
    using System;

    public class ConditionalDropdownListObj
    {
        private ConditionalType intValue;
        private string text;

        public ConditionalDropdownListObj(ConditionalType numericValue, string displayedText)
        {
            this.intValue = numericValue;
            this.text = displayedText;
        }

        public override string ToString() => 
            this.intValue.ToString() + " - " + this.text;

        public ConditionalType NumericValue =>
            this.intValue;

        public string DisplayedText =>
            this.text;
    }
}

