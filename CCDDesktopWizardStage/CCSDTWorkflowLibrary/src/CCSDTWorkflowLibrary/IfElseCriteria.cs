namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Collections;
    using System.Text;
    using System.Workflow.ComponentModel;

    [Serializable]
    public class IfElseCriteria
    {
        private string activityName;
        private ConditionalType conditional;
        private string testValue;
        private OperatorType testOperator;

        public IfElseCriteria()
        {
        }

        public IfElseCriteria(string ActivityName)
        {
            this.activityName = ActivityName;
        }

        public static string GetString(CustomCCSDTWorkflowBase workflow, ArrayList criteriaList)
        {
            string str2;
            if (ReferenceEquals(criteriaList, null))
            {
                str2 = null;
            }
            else
            {
                string str = null;
                foreach (IfElseCriteria criteria in criteriaList)
                {
                    if (str != null)
                    {
                        str = str + "|";
                    }
                    str = str + criteria.GetStringValue(workflow);
                }
                str2 = str;
            }
            return str2;
        }

        public string GetStringValue(CustomCCSDTWorkflowBase workflow)
        {
            int num = 0;
            string activityName = this.ActivityName;
            Activity activityByName = workflow.GetActivityByName(this.ActivityName);
            if ((activityByName == null) && this.ActivityName.Contains("_"))
            {
                string activityQualifiedName = this.ActivityName.Substring(0, this.ActivityName.LastIndexOf("_"));
                activityByName = workflow.GetActivityByName(activityQualifiedName);
                if ((activityByName != null) && (activityByName is ValidateButton))
                {
                    activityName = activityQualifiedName + "_parameter" + this.ActivityName.Substring(this.ActivityName.LastIndexOf("_"));
                }
            }
            if ((activityByName != null) && workflow._elementTypeMap.ContainsKey(activityByName.GetType()))
            {
                num = workflow._elementTypeMap[activityByName.GetType()];
            }
            StringBuilder builder = new StringBuilder();
            builder.Append(activityName);
            builder.Append(",");
            builder.Append(num.ToString());
            builder.Append(",");
            builder.Append(((int) this.Conditional).ToString());
            builder.Append(",");
            builder.Append(this.ValueToTest);
            builder.Append(",");
            builder.Append(((int) this.Operator).ToString());
            return builder.ToString();
        }

        public string ActivityName
        {
            get => 
                this.activityName;
            set => 
                this.activityName = value;
        }

        public ConditionalType Conditional
        {
            get => 
                this.conditional;
            set => 
                this.conditional = value;
        }

        public string ValueToTest
        {
            get => 
                this.testValue;
            set => 
                this.testValue = value;
        }

        public OperatorType Operator
        {
            get => 
                this.testOperator;
            set => 
                this.testOperator = value;
        }
    }
}

