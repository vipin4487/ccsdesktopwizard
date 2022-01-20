namespace CCSDTWorkflowLibrary
{
    using System;

    public class DropdownListObj
    {
        private int intValue;
        private string text;

        public DropdownListObj(int numericValue, string displayedText)
        {
            this.intValue = numericValue;
            this.text = displayedText;
        }

        public override string ToString() => 
            this.intValue.ToString() + " - " + this.text;

        public int NumericValue =>
            this.intValue;

        public string DisplayedText =>
            this.text;
    }
}

