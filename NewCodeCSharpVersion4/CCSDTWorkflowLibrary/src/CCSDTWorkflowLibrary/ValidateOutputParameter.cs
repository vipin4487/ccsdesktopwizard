namespace CCSDTWorkflowLibrary
{
    using System;

    [Serializable]
    public class ValidateOutputParameter
    {
        private string parameterName;
        private string destinationControl;
        private string initValue;

        public string ParameterName
        {
            get
            {
                return this.parameterName;
            }
            set
            {
                this.parameterName = value;
            }
        }

        public string DestinationControl
        {
            get
            {
                return this.destinationControl;
            }
            set
            {
                this.destinationControl = value;
            }
        }

        public string InitialValue
        {
            get
            {
                return this.initValue;
            }
            set
            {
                this.initValue = value;
            }
        }
    }
}

