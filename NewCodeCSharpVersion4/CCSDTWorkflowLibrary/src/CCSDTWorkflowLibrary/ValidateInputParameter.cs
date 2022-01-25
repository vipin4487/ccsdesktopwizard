namespace CCSDTWorkflowLibrary
{
    using System;

    [Serializable]
    public class ValidateInputParameter
    {
        private string parameterName;
        private string activityName;
        private string staticValue;
        private bool isAConstant;

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

        public string ActivityName
        {
            get
            {
                return this.activityName;
            }
            set
            {
                this.activityName = value;
                if (((this.activityName != null) && (this.activityName.Length > 0)) && (this.activityName != "{Static}"))
                {
                    this.isAConstant = false;
                }
            }
        }

        public string StaticValue
        {
            get
            {
                return this.staticValue;
            }
            set
            {
                this.staticValue = value;
                if ((this.staticValue != null) && (this.staticValue.Length > 0))
                {
                    this.isAConstant = true;
                    this.activityName = "{Static}";
                }
            }
        }

        public bool IsAStaticValue
        {
            get
            {
                return this.isAConstant;
            }
            set
            {
                this.isAConstant = value;
            }
        }
    }
}

