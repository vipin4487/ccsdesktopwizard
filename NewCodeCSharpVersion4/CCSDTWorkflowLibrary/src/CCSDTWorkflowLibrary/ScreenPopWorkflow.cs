namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Text;
    using System.Workflow.ComponentModel;

    [Designer(typeof(CustomWorkflowDesigner), typeof(IRootDesigner)), Description("Allows selection of controls displayed on a screen pop.")]
    public class ScreenPopWorkflow : CustomCCSDTWorkflowBase
    {
        private Size _defaultSize;
        private ArrayList _closeCriteria = null;
        private ArrayList _closeCriteria2 = null;
        private ArrayList _closeCriteria3 = null;
        private string _errorMessage = null;
        private string _errorMessage2 = null;
        private string _errorMessage3 = null;

        protected override string GetHiddenInputFields()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(base.GetHiddenInputFields());
            builder.Append("    <input id=\"FormValidatedForClose\"");
            builder.Append(" type=\"hidden\" value=\"\"");
            builder.AppendLine(" />");
            if ((this.ErrorMessage != null) && (this.ErrorMessage.Length > 0))
            {
                builder.Append("    <input id=\"ErrorMessageOnClose\"");
                builder.Append(" type=\"hidden\" value=\"" + this.ErrorMessage + "\"");
                builder.AppendLine(" />");
            }
            else
            {
                builder.Append("    <input id=\"ErrorMessageOnClose\"");
                builder.Append(" type=\"hidden\" value=\"\"");
                builder.AppendLine(" />");
            }
            return builder.ToString();
        }

        protected override string GetHtmlJavaScript()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(base.GetHtmlJavaScript());
            builder.AppendLine("");
            builder.AppendLine("function testClosingCriteria() {");
            builder.AppendLine("    var errorString = \"\";");
            builder.AppendLine("    document.getElementById(\"FormValidatedForClose\").value = \"1\";");
            if ((this.Criteria != null) && (this.Criteria.Count > 0))
            {
                builder.AppendLine("    if (!testCrieriaList('" + IfElseCriteria.GetString(this, this.Criteria) + "'))");
                builder.AppendLine("    {");
                builder.AppendLine("       document.getElementById(\"FormValidatedForClose\").value = \"0\";");
                if ((this.ErrorMessage != null) && (this.ErrorMessage.Length > 0))
                {
                    builder.AppendLine("       errorString = \"" + this.ErrorMessage + "\";");
                }
                builder.AppendLine("    }");
            }
            if ((this.Criteria2 != null) && (this.Criteria2.Count > 0))
            {
                builder.AppendLine("    if (!testCrieriaList('" + IfElseCriteria.GetString(this, this.Criteria2) + "'))");
                builder.AppendLine("    {");
                builder.AppendLine("       document.getElementById(\"FormValidatedForClose\").value = \"0\";");
                if ((this.ErrorMessage2 != null) && (this.ErrorMessage2.Length > 0))
                {
                    builder.AppendLine("       if (errorString.length == 0)");
                    builder.AppendLine("          errorString = \"" + this.ErrorMessage2 + "\";");
                }
                builder.AppendLine("    }");
            }
            if ((this.Criteria3 != null) && (this.Criteria3.Count > 0))
            {
                builder.AppendLine("    if (!testCrieriaList('" + IfElseCriteria.GetString(this, this.Criteria3) + "'))");
                builder.AppendLine("    {");
                builder.AppendLine("       document.getElementById(\"FormValidatedForClose\").value = \"0\";");
                if ((this.ErrorMessage3 != null) && (this.ErrorMessage3.Length > 0))
                {
                    builder.AppendLine("       if (errorString.length == 0)");
                    builder.AppendLine("          errorString = \"" + this.ErrorMessage3 + "\";");
                }
                builder.AppendLine("    }");
            }
            builder.AppendLine("    if (errorString.length > 0)");
            builder.AppendLine("       document.getElementById(\"ErrorMessageOnClose\").value = errorString;");
            builder.AppendLine("}");
            return builder.ToString();
        }

        private void UpdateClosingCriteraFromChangedProperty(string propertyName, ArrayList existingCriteriaList)
        {
            if ((existingCriteriaList != null) && (existingCriteriaList.Count != 0))
            {
                ArrayList newValue = new ArrayList();
                bool flag = false;
                foreach (IfElseCriteria criteria in existingCriteriaList)
                {
                    IfElseCriteria criteria2 = criteria;
                    if (base.changedControl.GetType() == typeof(ValidateButton))
                    {
                        char[] separator = new char[] { '_' };
                        string[] strArray = criteria.ActivityName.Split(separator);
                        if (strArray.Length > 1)
                        {
                            string str2 = strArray[0];
                            string str3 = strArray[1];
                            if (str2 == base.changedControl.Name)
                            {
                                ArrayList outputParameters = ((ValidateButton) base.changedControl).OutputParameters;
                                if ((outputParameters == null) || (outputParameters.Count == 0))
                                {
                                    criteria2 = null;
                                    flag = true;
                                }
                                else
                                {
                                    bool flag7 = false;
                                    foreach (ValidateOutputParameter parameter in outputParameters)
                                    {
                                        if (parameter.ParameterName == str3)
                                        {
                                            flag7 = true;
                                        }
                                    }
                                    if (!flag7)
                                    {
                                        criteria2 = null;
                                        flag = true;
                                    }
                                }
                            }
                        }
                    }
                    if (criteria2 > null)
                    {
                        newValue.Add(criteria2);
                    }
                }
                if (flag)
                {
                    base.UpdatePropertyForDesigner(this, propertyName, existingCriteriaList, newValue);
                }
            }
        }

        private void UpdateClosingCriteriaWithNewReferencedName(string propertyName, ArrayList existingCriteriaList)
        {
            if ((existingCriteriaList != null) && (existingCriteriaList.Count != 0))
            {
                ArrayList newValue = new ArrayList();
                bool flag = false;
                foreach (IfElseCriteria criteria in existingCriteriaList)
                {
                    string activityName = criteria.ActivityName;
                    string newNameOfControl = base.newNameOfControl;
                    if (base.changedControl.GetType() == typeof(ValidateButton))
                    {
                        char[] separator = new char[] { '_' };
                        string[] strArray = criteria.ActivityName.Split(separator);
                        if (strArray.Length > 1)
                        {
                            activityName = strArray[0];
                            for (int i = 1; i < strArray.Length; i++)
                            {
                                newNameOfControl = newNameOfControl + "_" + strArray[i];
                            }
                        }
                    }
                    if (activityName == base.oldNameOfControl)
                    {
                        if ((base.newNameOfControl != null) && (base.newNameOfControl.Length > 0))
                        {
                            IfElseCriteria criteria2 = new IfElseCriteria {
                                ActivityName = newNameOfControl,
                                Conditional = criteria.Conditional,
                                Operator = criteria.Operator,
                                ValueToTest = criteria.ValueToTest
                            };
                            newValue.Add(criteria2);
                        }
                        flag = true;
                    }
                    else
                    {
                        newValue.Add(criteria);
                    }
                }
                if (flag)
                {
                    base.UpdatePropertyForDesigner(this, propertyName, existingCriteriaList, newValue);
                }
            }
        }

        protected override void UpdateReferencesToControl(ActivityCollection childActivites)
        {
            base.UpdateReferencesToControl(childActivites);
            if (base.changedMember == null)
            {
                this.UpdateClosingCriteriaWithNewReferencedName("Criteria", this.Criteria);
                this.UpdateClosingCriteriaWithNewReferencedName("Criteria2", this.Criteria2);
                this.UpdateClosingCriteriaWithNewReferencedName("Criteria3", this.Criteria3);
            }
            else
            {
                this.UpdateClosingCriteraFromChangedProperty("Criteria", this.Criteria);
                this.UpdateClosingCriteraFromChangedProperty("Criteria2", this.Criteria2);
                this.UpdateClosingCriteraFromChangedProperty("Criteria3", this.Criteria3);
            }
        }

        [Browsable(true), Category("Appearance"), Description("Size of the screen pop window when first displayed.")]
        public Size DefaultSize
        {
            get
            {
                return this._defaultSize;
            }
            set
            {
                this._defaultSize = value;
            }
        }

        [Editor(typeof(CriteriaArrayListEditor), typeof(UITypeEditor)), Category("Criteria to close"), Description("Please specify the Criteria for this branch."), DefaultValue((string) null), RefreshProperties(RefreshProperties.Repaint)]
        public ArrayList Criteria
        {
            get
            {
                return this._closeCriteria;
            }
            set
            {
                this._closeCriteria = value;
            }
        }

        [Editor(typeof(CriteriaArrayListEditor), typeof(UITypeEditor)), Category("Criteria to close"), Description("Please specify the Criteria2 to close this form."), DefaultValue((string) null), RefreshProperties(RefreshProperties.Repaint)]
        public ArrayList Criteria2
        {
            get
            {
                return this._closeCriteria2;
            }
            set
            {
                this._closeCriteria2 = value;
            }
        }

        [Editor(typeof(CriteriaArrayListEditor), typeof(UITypeEditor)), Category("Criteria to close"), Description("Please specify the Criteria3 to close this form."), DefaultValue((string) null), RefreshProperties(RefreshProperties.Repaint)]
        public ArrayList Criteria3
        {
            get
            {
                return this._closeCriteria3;
            }
            set
            {
                this._closeCriteria3 = value;
            }
        }

        [Browsable(true), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("Criteria to close"), Description("Error message displayed to user when the Criteria2 is not met."), DefaultValue((string) null)]
        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                this._errorMessage = value;
            }
        }

        [Browsable(true), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("Criteria to close"), Description("Error message displayed to user when the Criteria2 is not met."), DefaultValue((string) null)]
        public string ErrorMessage2
        {
            get
            {
                return this._errorMessage2;
            }
            set
            {
                this._errorMessage2 = value;
            }
        }

        [Browsable(true), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Category("Criteria to close"), Description("Error message displayed to user when the Criteria3 is not met."), DefaultValue((string) null)]
        public string ErrorMessage3
        {
            get
            {
                return this._errorMessage3;
            }
            set
            {
                this._errorMessage3 = value;
            }
        }
    }
}

