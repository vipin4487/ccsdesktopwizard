namespace CCSDTWorkflowLibrary
{
    using CCSDTWorkflowLibrary.Properties;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Text;
    using System.Workflow.Activities;
    using System.Workflow.ComponentModel;

    [Designer(typeof(CustomWorkflowDesigner), typeof(IRootDesigner)), Description("Allows selection of controls displayed on a screen pop.")]
    public abstract class CustomCCSDTWorkflowBase : SequentialWorkflowActivity
    {
        private Hashtable _callVarMap = null;
        private List<string> _callVarNames = null;
        private List<string> _callVarList = null;
        private ArrayList _datServerList = null;
        private Size _col1Size = new Size(300, 50);
        private Size _col2Size = new Size(400, 50);
        private string _copyButton16by16 = null;
        private string _copyButton24by24 = null;
        private string _copyButton32by32 = null;
        public Dictionary<Type, int> _elementTypeMap;
        private StringBuilder workingString;
        private IComponentChangeService designerCcs;
        protected Activity changedControl;
        protected MemberDescriptor changedMember;
        protected string oldNameOfControl;
        protected string newNameOfControl;

        public CustomCCSDTWorkflowBase()
        {
            Dictionary<Type, int> dictionary = new Dictionary<Type, int> {
                { 
                    typeof(DropDown),
                    1
                },
                { 
                    typeof(ReadOnlyText),
                    2
                },
                { 
                    typeof(RadioButton),
                    3
                },
                { 
                    typeof(TextBox),
                    4
                },
                { 
                    typeof(TextArea),
                    5
                },
                { 
                    typeof(HiddenTextBox),
                    6
                },
                { 
                    typeof(Calendar),
                    7
                }
            };
            this._elementTypeMap = dictionary;
            this.designerCcs = null;
            try
            {
                Image image = Resources.CopyIcon16;
                this._copyButton16by16 = this.ImageToPngBase64(image);
                image = Resources.CopyIcon24;
                this._copyButton24by24 = this.ImageToPngBase64(image);
                image = Resources.CopyIcon32;
                this._copyButton32by32 = this.ImageToPngBase64(image);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private string BuildJavaScriptButtonCallback(ButtonBase button)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("function " + button.Name + "_Callback(param) {");
            ArrayList outputParameters = null;
            if (button is ValidateButton)
            {
                outputParameters = ((ValidateButton) button).OutputParameters;
            }
            else if (button is ProactiveButton)
            {
                outputParameters = ((ProactiveButton) button).OutputParameters;
            }
            if (outputParameters > null)
            {
                builder.AppendLine("    var curSourceControl;");
                builder.AppendLine("    var nextOutputControl;");
                builder.AppendLine("    var monthOutputControl;");
                builder.AppendLine("    var dayOutputControl;");
                builder.AppendLine("    var yearOutputControl;");
                foreach (ValidateOutputParameter parameter in outputParameters)
                {
                    if (((parameter.ParameterName != null) && (parameter.ParameterName.Length > 0)) && ((parameter.DestinationControl != null) && (parameter.DestinationControl.Length > 0)))
                    {
                        Activity activityByName = base.GetActivityByName(parameter.DestinationControl);
                        if (activityByName > null)
                        {
                            if (activityByName is Calendar)
                            {
                                builder.AppendLine("    curSourceControl = document.getElementById(\"" + button.Name + "_parameter_" + parameter.ParameterName + "\");");
                                builder.AppendLine("    monthOutputControl = document.getElementById(\"" + activityByName.Name + "_month\");");
                                builder.AppendLine("    dayOutputControl = document.getElementById(\"" + activityByName.Name + "_day\");");
                                builder.AppendLine("    yearOutputControl = document.getElementById(\"" + activityByName.Name + "_year\");");
                                builder.AppendLine("    if (curSourceControl && monthOutputControl && dayOutputControl && yearOutputControl && curSourceControl.value.length > 7) {");
                                builder.AppendLine("        monthOutputControl.value = curSourceControl.value.substring(0, 2);");
                                builder.AppendLine("        dayOutputControl.value = curSourceControl.value.substring(2, 4);");
                                builder.AppendLine("        yearOutputControl.value = curSourceControl.value.substring(4, 8);");
                                builder.AppendLine("    }");
                            }
                            else if (!(activityByName is ValidateButton))
                            {
                                if (activityByName is ButtonBase)
                                {
                                    builder.AppendLine("    curSourceControl = document.getElementById(\"" + button.Name + "_parameter_" + parameter.ParameterName + "\");");
                                    builder.AppendLine("    nextOutputControl = document.getElementById(\"" + activityByName.Name + "_NumberToDial\");");
                                    builder.AppendLine("    if (curSourceControl && nextOutputControl) {");
                                    builder.AppendLine("        nextOutputControl.value = curSourceControl.value;");
                                    builder.AppendLine("    }");
                                }
                                else
                                {
                                    builder.AppendLine("    curSourceControl = document.getElementById(\"" + button.Name + "_parameter_" + parameter.ParameterName + "\");");
                                    builder.AppendLine("    nextOutputControl = document.getElementById(\"" + activityByName.Name + "\");");
                                    builder.AppendLine("    if (curSourceControl && nextOutputControl) {");
                                    if (activityByName is ReadOnlyText)
                                    {
                                        builder.AppendLine("        nextOutputControl.innerHTML = curSourceControl.value;");
                                    }
                                    else if (activityByName is DropDown)
                                    {
                                        builder.AppendLine("        if (!updateDropdownItems(curSourceControl, nextOutputControl))");
                                        builder.AppendLine("            nextOutputControl.value = curSourceControl.value;");
                                    }
                                    else if (activityByName is RadioButton)
                                    {
                                        builder.AppendLine("        if (!updateRadioButtonItems(curSourceControl, nextOutputControl))");
                                        builder.AppendLine("            nextOutputControl.value = curSourceControl.value;");
                                    }
                                    else
                                    {
                                        builder.AppendLine("        nextOutputControl.value = curSourceControl.value;");
                                    }
                                    builder.AppendLine("    }");
                                }
                            }
                        }
                    }
                }
            }
            builder.AppendLine("    stateMachine(param);");
            builder.AppendLine("}");
            return builder.ToString();
        }

        private string BuildJavaScriptForControls(ActivityCollection childActivites)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Activity activity in childActivites)
            {
                if (activity.GetType() == typeof(ValidateButton))
                {
                    ValidateButton button = (ValidateButton) activity;
                    builder.Append(this.BuildJavaScriptGetInputParameters(button));
                    builder.Append(this.BuildJavaScriptButtonCallback(button));
                }
                else if (activity.GetType() == typeof(ProactiveButton))
                {
                    ProactiveButton button = (ProactiveButton) activity;
                    builder.Append(this.BuildJavaScriptGetInputParameters(button));
                    builder.Append(this.BuildJavaScriptButtonCallback(button));
                }
                else if (activity.GetType() == typeof(IfElseTest))
                {
                    IfElseTest test = (IfElseTest) activity;
                    builder.Append(this.BuildJavaScriptForControls(test.Activities));
                }
                else if (activity.GetType() == typeof(IfElseBranch))
                {
                    IfElseBranch branch = (IfElseBranch) activity;
                    builder.Append(this.BuildJavaScriptForControls(branch.Activities));
                }
            }
            return builder.ToString();
        }

        private string BuildJavaScriptForReplay(ActivityCollection childActivites)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Activity activity in childActivites)
            {
                if (activity is GUIElement)
                {
                    builder.Append(this.GetJavaScriptToInitControl((GUIElement) activity));
                }
                else if (activity.GetType() == typeof(IfElseTest))
                {
                    IfElseTest test = (IfElseTest) activity;
                    builder.Append(this.BuildJavaScriptForReplay(test.Activities));
                }
                else if (activity.GetType() == typeof(IfElseBranch))
                {
                    IfElseBranch branch = (IfElseBranch) activity;
                    builder.Append(this.BuildJavaScriptForReplay(branch.Activities));
                }
            }
            return builder.ToString();
        }

        private string BuildJavaScriptGetInputParameters(ButtonBase button)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("function " + button.Name + "_GetInputParameters() {");
            builder.AppendLine("    xmldoc.loadXML(\"<root><parameters></parameters></root>\");");
            ArrayList inputParameters = null;
            if (button is ValidateButton)
            {
                inputParameters = ((ValidateButton) button).InputParameters;
            }
            else if (button is ProactiveButton)
            {
                inputParameters = ((ProactiveButton) button).InputParameters;
            }
            if (inputParameters > null)
            {
                builder.AppendLine("    var node; ");
                builder.AppendLine("");
                foreach (ValidateInputParameter parameter in inputParameters)
                {
                    if ((parameter.ParameterName != null) && (parameter.ParameterName.Length > 0))
                    {
                        builder.AppendLine("    node = xmldoc.selectSingleNode(\"//parameters\");");
                        builder.AppendLine("    if (node) {");
                        builder.AppendLine("        var nextParamElement = xmldoc.createElement(\"" + parameter.ParameterName + "\");");
                        if (parameter.IsAStaticValue)
                        {
                            builder.AppendLine("        nextParamElement.appendChild(xmldoc.createTextNode(\"" + parameter.StaticValue + "\"));");
                        }
                        else
                        {
                            Activity activityByName = base.GetActivityByName(parameter.ActivityName);
                            if ((activityByName != null) && (activityByName is GUIElement))
                            {
                                builder.Append("        nextParamElement.appendChild(xmldoc.createTextNode(");
                                builder.AppendLine(((GUIElement) activityByName).GetJavaScriptForValue(null) + "));");
                            }
                        }
                        builder.AppendLine("        node.appendChild(nextParamElement);");
                        builder.AppendLine("    };");
                    }
                }
            }
            builder.AppendLine("");
            builder.AppendLine("    document.getElementById(\"" + button.Name + "_InputParametersXml\").value = xmldoc.xml;");
            ArrayList outputParameters = null;
            if (button is ValidateButton)
            {
                outputParameters = ((ValidateButton) button).OutputParameters;
            }
            else if (button is ProactiveButton)
            {
                outputParameters = ((ProactiveButton) button).OutputParameters;
            }
            if (outputParameters > null)
            {
                builder.AppendLine("");
                foreach (ValidateOutputParameter parameter2 in outputParameters)
                {
                    if ((parameter2.ParameterName != null) && (parameter2.ParameterName.Length > 0))
                    {
                        builder.AppendLine("    document.getElementById(\"" + button.Name + "_parameter_" + parameter2.ParameterName + "\").value = \"" + parameter2.InitialValue + "\";");
                        if ((parameter2.DestinationControl != null) && (parameter2.DestinationControl.Length > 0))
                        {
                            Activity activityByName = base.GetActivityByName(parameter2.DestinationControl);
                            if (activityByName > null)
                            {
                                if (activityByName is Calendar)
                                {
                                    builder.AppendLine("    curSourceControl = document.getElementById(\"" + button.Name + "_parameter_" + parameter2.ParameterName + "\");");
                                    builder.AppendLine("    monthOutputControl = document.getElementById(\"" + activityByName.Name + "_month\");");
                                    builder.AppendLine("    dayOutputControl = document.getElementById(\"" + activityByName.Name + "_day\");");
                                    builder.AppendLine("    yearOutputControl = document.getElementById(\"" + activityByName.Name + "_year\");");
                                    builder.AppendLine("    if (curSourceControl && monthOutputControl && dayOutputControl && yearOutputControl && curSourceControl.value.length > 7) {");
                                    builder.AppendLine("        monthOutputControl.value = curSourceControl.value.substring(0, 2);");
                                    builder.AppendLine("        dayOutputControl.value = curSourceControl.value.substring(2, 4);");
                                    builder.AppendLine("        yearOutputControl.value = curSourceControl.value.substring(4, 8);");
                                    builder.AppendLine("    }");
                                }
                                else
                                {
                                    builder.AppendLine("    curSourceControl = document.getElementById(\"" + button.Name + "_parameter_" + parameter2.ParameterName + "\");");
                                    if (activityByName is WarmConferenceButton)
                                    {
                                        builder.AppendLine("    nextOutputControl = document.getElementById(\"" + activityByName.Name + "_NumberToDial\");");
                                    }
                                    else
                                    {
                                        builder.AppendLine("    nextOutputControl = document.getElementById(\"" + activityByName.Name + "\");");
                                    }
                                    builder.AppendLine("    if (curSourceControl && nextOutputControl) {");
                                    if (activityByName is ReadOnlyText)
                                    {
                                        builder.AppendLine("        nextOutputControl.innerHTML = curSourceControl.value;");
                                    }
                                    else if (activityByName is DropDown)
                                    {
                                        builder.AppendLine("        if (!updateDropdownItems(curSourceControl, nextOutputControl))");
                                        builder.AppendLine("            nextOutputControl.value = curSourceControl.value;");
                                    }
                                    else if (!(activityByName is RadioButton))
                                    {
                                        builder.AppendLine("        nextOutputControl.value = curSourceControl.value;");
                                    }
                                    builder.AppendLine("    }");
                                }
                            }
                        }
                    }
                }
                builder.AppendLine("");
                builder.AppendLine("    stateMachine('" + button.Name + "');");
            }
            builder.AppendLine("}");
            return builder.ToString();
        }

        private string BuildStateMachineBody(ActivityCollection childActivites)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Activity activity in childActivites)
            {
                if (activity.GetType() == typeof(IfElseTest))
                {
                    IfElseTest test = (IfElseTest) activity;
                    ArrayList listOfLists = new ArrayList();
                    for (int i = 0; i < test.Activities.Count; i++)
                    {
                        IfElseBranch branch = (IfElseBranch) test.Activities[i];
                        listOfLists.Add(this.GetListOfChildren(branch.Activities));
                    }
                    for (int j = 0; j < test.Activities.Count; j++)
                    {
                        IfElseBranch currentBranch = (IfElseBranch) test.Activities[j];
                        if (j == (test.Activities.Count - 1))
                        {
                            if (currentBranch.Criteria > null)
                            {
                                builder.AppendLine("else if (testCrieriaList('" + IfElseCriteria.GetString(this, currentBranch.Criteria) + "'))");
                                builder.AppendLine("{");
                                builder.Append(this.BuildStateMachineBody(currentBranch.Activities));
                                builder.Append(this.GetJavaScriptToShowHideRows(currentBranch, listOfLists, j));
                                builder.AppendLine("}");
                                builder.AppendLine("else ");
                                builder.AppendLine("{");
                                builder.Append(this.GetJavaScriptToShowHideRows(null, listOfLists, -1));
                                builder.AppendLine("}");
                            }
                            else
                            {
                                builder.AppendLine("else ");
                                builder.AppendLine("{");
                                builder.Append(this.BuildStateMachineBody(currentBranch.Activities));
                                builder.Append(this.GetJavaScriptToShowHideRows(currentBranch, listOfLists, j));
                                builder.AppendLine("}");
                            }
                        }
                        else
                        {
                            if (j == 0)
                            {
                                builder.AppendLine("if (testCrieriaList('" + IfElseCriteria.GetString(this, currentBranch.Criteria) + "'))");
                            }
                            else
                            {
                                builder.AppendLine("else if (testCrieriaList('" + IfElseCriteria.GetString(this, currentBranch.Criteria) + "'))");
                            }
                            builder.AppendLine("{");
                            builder.Append(this.BuildStateMachineBody(currentBranch.Activities));
                            builder.Append(this.GetJavaScriptToShowHideRows(currentBranch, listOfLists, j));
                            builder.AppendLine("}");
                        }
                    }
                }
                else
                {
                    builder.AppendLine("if (!containsElement(visitedControls, '" + activity.Name + "')) {");
                    builder.AppendLine("     visitedControls[visitedControls.length] = '" + activity.Name + "'");
                    builder.AppendLine("}");
                }
            }
            return builder.ToString();
        }

        private string BuildUpdateCallDataXml(ActivityCollection childActivites)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Activity activity in childActivites)
            {
                if (activity is GUIElement)
                {
                    builder.Append(this.GetXmlForDestinationCallVar((GUIElement) activity));
                }
                else if (activity.GetType() == typeof(IfElseTest))
                {
                    IfElseTest test = (IfElseTest) activity;
                    builder.Append(this.BuildUpdateCallDataXml(test.Activities));
                }
                else if (activity.GetType() == typeof(IfElseBranch))
                {
                    IfElseBranch branch = (IfElseBranch) activity;
                    builder.Append(this.BuildUpdateCallDataXml(branch.Activities));
                }
            }
            return builder.ToString();
        }

        public void ControlNameChanged(IComponentChangeService ccs, Activity control, string oldName, string newName)
        {
            this.designerCcs = ccs;
            this.changedControl = control;
            this.oldNameOfControl = oldName;
            this.newNameOfControl = newName;
            this.changedMember = null;
            this.UpdateReferencesToControl(base.Activities);
        }

        public void ControlPropertyChanged(IComponentChangeService ccs, Activity control, MemberDescriptor member, object oldValue, object newValue)
        {
            if ((control.GetType() == typeof(ValidateButton)) && (member.Name == "OutputParameters"))
            {
                this.designerCcs = ccs;
                this.changedControl = control;
                this.oldNameOfControl = control.Name;
                this.newNameOfControl = "";
                this.changedMember = member;
                this.UpdateReferencesToControl(base.Activities);
            }
        }

        public void ControlRemoved(IComponentChangeService ccs, Activity control)
        {
            this.designerCcs = ccs;
            this.changedControl = control;
            this.oldNameOfControl = control.Name;
            this.newNameOfControl = "";
            this.changedMember = null;
            this.UpdateReferencesToControl(base.Activities);
        }

        private bool ControlsExistWithExtraButtons(ActivityCollection childActivites)
        {
            foreach (Activity activity in childActivites)
            {
                if (activity is GUIElement)
                {
                    GUIElement element = (GUIElement) activity;
                    if (element.ButtonsForControl > ButtonsType.None)
                    {
                        return true;
                    }
                }
                else if (activity.GetType() == typeof(IfElseTest))
                {
                    IfElseTest test = (IfElseTest) activity;
                    if (this.ControlsExistWithExtraButtons(test.Activities))
                    {
                        return true;
                    }
                }
                else if (activity.GetType() == typeof(IfElseBranch))
                {
                    IfElseBranch branch = (IfElseBranch) activity;
                    if (this.ControlsExistWithExtraButtons(branch.Activities))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private string GetDefaultXmlForDestinationCallVar(GUIElement outputElement, string callVar)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("    node = xmldoc.selectSingleNode(\"//root\");");
            builder.AppendLine("    if (node && containsElement(visitedControls, '" + outputElement.Name + "')) {");
            builder.AppendLine("        var callVarElement = xmldoc.createElement(\"callvar\");");
            builder.AppendLine("        var typeElement = xmldoc.createElement(\"type\");");
            builder.AppendLine("        typeElement.appendChild(xmldoc.createTextNode(\"vccvar\"));");
            builder.AppendLine("        callVarElement.appendChild(typeElement);");
            builder.AppendLine("        var nameElement = xmldoc.createElement(\"name\");");
            builder.AppendLine("        nameElement.appendChild(xmldoc.createTextNode(\"" + outputElement.Name + "\"));");
            builder.AppendLine("        callVarElement.appendChild(nameElement);");
            builder.AppendLine("        var valueElement = xmldoc.createElement(\"value\");");
            builder.Append("        valueElement.appendChild(xmldoc.createTextNode(");
            builder.AppendLine(outputElement.GetJavaScriptForValue(callVar) + "));");
            builder.AppendLine("        callVarElement.appendChild(valueElement);");
            builder.AppendLine("        node.appendChild(callVarElement);");
            builder.AppendLine("    };");
            return builder.ToString();
        }

        private void GetHiddenFieldsForControls(ActivityCollection childActivites)
        {
            foreach (Activity activity in childActivites)
            {
                if (!(activity is GUIElement))
                {
                    if (activity is ValidateButton)
                    {
                        ValidateButton button = activity as ValidateButton;
                        if (button > null)
                        {
                            if (button.OutputParameters > null)
                            {
                                foreach (ValidateOutputParameter parameter in button.OutputParameters)
                                {
                                    if ((parameter.ParameterName != null) && (parameter.ParameterName.Length > 0))
                                    {
                                        this.workingString.Append("    <input id=\"");
                                        this.workingString.Append(activity.Name + "_parameter_" + parameter.ParameterName);
                                        this.workingString.Append("\" type=\"hidden\" value=\"");
                                        this.workingString.Append(parameter.InitialValue);
                                        this.workingString.AppendLine("\" />");
                                    }
                                }
                            }
                            if ((button.DataConnection != null) && (button.DataConnection.Length > 0))
                            {
                            }
                            this.workingString.Append("    <input id=\"");
                            this.workingString.Append(activity.Name + "_InputParametersXml");
                            this.workingString.Append("\" type=\"hidden\" value=\"\" />");
                            if (button.AutoFire)
                            {
                                this.workingString.Append("    <input id=\"");
                                this.workingString.Append(activity.Name + "_Clicked");
                                this.workingString.Append("\" type=\"hidden\" value=\"\" />");
                            }
                            if (button.AutoClose)
                            {
                                this.workingString.Append("    <input id=\"");
                                this.workingString.Append(activity.Name + "_AutoClose");
                                this.workingString.Append("\" type=\"hidden\" value=\"1\" />");
                            }
                        }
                    }
                    else if (activity is EmailButton)
                    {
                        EmailButton button2 = activity as EmailButton;
                        if (button2 > null)
                        {
                            if (button2.ToAddresses > null)
                            {
                                this.workingString.Append("    <input id=\"");
                                this.workingString.Append(activity.Name + "_ToAddresses");
                                this.workingString.Append("\" type=\"hidden\" value=\"");
                                this.workingString.Append(button2.ToAddresses);
                                this.workingString.AppendLine("\" />");
                            }
                            if (button2.CCAddresses > null)
                            {
                                this.workingString.Append("    <input id=\"");
                                this.workingString.Append(activity.Name + "_CCAddresses");
                                this.workingString.Append("\" type=\"hidden\" value=\"");
                                this.workingString.Append(button2.CCAddresses);
                                this.workingString.AppendLine("\" />");
                            }
                            if (button2.Subject > null)
                            {
                                this.workingString.Append("    <input id=\"");
                                this.workingString.Append(activity.Name + "_Subject");
                                this.workingString.Append("\" type=\"hidden\" value=\"");
                                this.workingString.Append(button2.Subject);
                                this.workingString.AppendLine("\" />");
                            }
                            if (button2.HTMLBodyText > null)
                            {
                                this.workingString.Append("    <input id=\"");
                                this.workingString.Append(activity.Name + "_HTMLBodyText");
                                this.workingString.Append("\" type=\"hidden\" value=\"");
                                string str = button2.HTMLBodyText.Replace("\r\n", "<br>").Replace("\"", "'");
                                this.workingString.Append(str);
                                this.workingString.AppendLine("\" />");
                            }
                            if (button2.AutoFire)
                            {
                                this.workingString.Append("    <input id=\"");
                                this.workingString.Append(activity.Name + "_Clicked");
                                this.workingString.Append("\" type=\"hidden\" value=\"\" />");
                            }
                            if (button2.AutoClose)
                            {
                                this.workingString.Append("    <input id=\"");
                                this.workingString.Append(activity.Name + "_AutoClose");
                                this.workingString.Append("\" type=\"hidden\" value=\"1\" />");
                            }
                            if (button2.AttachLogFiles)
                            {
                                this.workingString.Append("    <input id=\"");
                                this.workingString.Append(activity.Name + "_AttachLogFiles");
                                this.workingString.Append("\" type=\"hidden\" value=\"1\" />");
                            }
                            if (button2.AttachScreenShot)
                            {
                                this.workingString.Append("    <input id=\"");
                                this.workingString.Append(activity.Name + "_AttachScreenShot");
                                this.workingString.Append("\" type=\"hidden\" value=\"1\" />");
                            }
                            if (button2.AutoSend)
                            {
                                this.workingString.Append("    <input id=\"");
                                this.workingString.Append(activity.Name + "_AutoSend");
                                this.workingString.Append("\" type=\"hidden\" value=\"1\" />");
                            }
                        }
                    }
                    else if (activity is ProactiveButton)
                    {
                        ProactiveButton button3 = activity as ProactiveButton;
                        if (button3 > null)
                        {
                            if (button3.OutputParameters > null)
                            {
                                foreach (ValidateOutputParameter parameter2 in button3.OutputParameters)
                                {
                                    if ((parameter2.ParameterName != null) && (parameter2.ParameterName.Length > 0))
                                    {
                                        this.workingString.Append("    <input id=\"");
                                        this.workingString.Append(activity.Name + "_parameter_" + parameter2.ParameterName);
                                        this.workingString.Append("\" type=\"hidden\" value=\"");
                                        this.workingString.Append(parameter2.InitialValue);
                                        this.workingString.AppendLine("\" />");
                                    }
                                }
                            }
                            if ((button3.CommandToRun != null) && (button3.CommandToRun.Length > 0))
                            {
                                this.workingString.Append("    <input id=\"");
                                this.workingString.Append(activity.Name + "_CommandToRun");
                                this.workingString.Append("\" type=\"hidden\" value=\"");
                                this.workingString.Append(button3.CommandToRun);
                                this.workingString.AppendLine("\" />");
                            }
                            this.workingString.Append("    <input id=\"");
                            this.workingString.Append(activity.Name + "_InputParametersXml");
                            this.workingString.Append("\" type=\"hidden\" value=\"\" />");
                            if (button3.AutoFire)
                            {
                                this.workingString.Append("    <input id=\"");
                                this.workingString.Append(activity.Name + "_Clicked");
                                this.workingString.Append("\" type=\"hidden\" value=\"\" />");
                            }
                            if (button3.AutoClose)
                            {
                                this.workingString.Append("    <input id=\"");
                                this.workingString.Append(activity.Name + "_AutoClose");
                                this.workingString.Append("\" type=\"hidden\" value=\"1\" />");
                            }
                        }
                    }
                    else if (activity is ButtonBase)
                    {
                        ButtonBase base2 = activity as ButtonBase;
                        if ((base2.NumberToDial != null) && (base2.NumberToDial.Length > 0))
                        {
                            this.workingString.Append("    <input id=\"");
                            this.workingString.Append(activity.Name + "_NumberToDial");
                            this.workingString.Append("\" type=\"hidden\" value=\"");
                            this.workingString.Append(base2.NumberToDial);
                            this.workingString.AppendLine("\" />");
                        }
                        if (base2.AutoFire)
                        {
                            this.workingString.Append("    <input id=\"");
                            this.workingString.Append(activity.Name + "_Clicked");
                            this.workingString.Append("\" type=\"hidden\" value=\"\" />");
                        }
                        if (base2.AutoClose)
                        {
                            this.workingString.Append("    <input id=\"");
                            this.workingString.Append(activity.Name + "_AutoClose");
                            this.workingString.Append("\" type=\"hidden\" value=\"1\" />");
                        }
                    }
                }
                if (activity.GetType() == typeof(IfElseTest))
                {
                    IfElseTest test = (IfElseTest) activity;
                    this.GetHiddenFieldsForControls(test.Activities);
                }
                else if (activity.GetType() == typeof(IfElseBranch))
                {
                    IfElseBranch branch = (IfElseBranch) activity;
                    this.GetHiddenFieldsForControls(branch.Activities);
                }
            }
        }

        protected virtual string GetHiddenInputFields()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("</table> ");
            this.workingString = new StringBuilder();
            this.GetHiddenFieldsForControls(base.Activities);
            builder.Append(this.workingString);
            builder.Append("    <input id=\"CallDataToChange\"");
            builder.Append(" type=\"hidden\" value=\"\"");
            builder.AppendLine(" />");
            return builder.ToString();
        }

        protected virtual string GetHtmlBodyTag()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<body style=\"font-size:16px; font-family: Arial;\"  >");
            builder.AppendLine("<table>");
            return builder.ToString();
        }

        protected virtual string GetHtmlClosingTags()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<div class='copyButtonImage'>&nbsp</div><br> ");
            builder.AppendLine("<div class='copyButtonImage'>&nbsp</div><br> ");
            builder.AppendLine("</body> ");
            builder.AppendLine("</html> ");
            return builder.ToString();
        }

        protected virtual string GetHtmlForControls()
        {
            this.workingString = new StringBuilder();
            this.GetHtmlForControls(base.Activities);
            return this.workingString.ToString();
        }

        private void GetHtmlForControls(ActivityCollection childActivites)
        {
            foreach (Activity activity in childActivites)
            {
                if (activity is GUIElement)
                {
                    this.workingString.Append(((GUIElement) activity).GetHtml);
                }
                else if (activity is ValidateButton)
                {
                    ValidateButton button = activity as ValidateButton;
                    this.workingString.Append(button.GetHtml);
                }
                else if (activity is ButtonBase)
                {
                    this.workingString.Append(((ButtonBase) activity).GetHtml);
                }
                if (activity.GetType() == typeof(IfElseTest))
                {
                    IfElseTest test = (IfElseTest) activity;
                    this.GetHtmlForControls(test.Activities);
                }
                else if (activity.GetType() == typeof(IfElseBranch))
                {
                    IfElseBranch branch = (IfElseBranch) activity;
                    this.GetHtmlForControls(branch.Activities);
                }
            }
        }

        protected virtual string GetHtmlHeadingTag()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            builder.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
            builder.AppendLine("<head>");
            builder.AppendLine("    <meta http-equiv=\"MSThemeCompatible\" content=\"yes\" /> ");
            builder.AppendLine("    <title>WWE Screen Pop</title>");
            builder.AppendLine("<style type=\"text/css\">          ");
            builder.AppendLine("    .col1Style           ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          width: " + this._col1Size.Width.ToString() + "px;  ");
            builder.AppendLine("          font-family: Arial;");
            builder.AppendLine("          font-size: 16px;");
            builder.AppendLine("          font-weight: bold;");
            builder.AppendLine("          vertical-align:top;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .col2Style           ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          width: " + this._col2Size.Width.ToString() + "px;  ");
            builder.AppendLine("          font-family: Arial;");
            builder.AppendLine("          font-size: 16px;");
            builder.AppendLine("          font-weight: bold;");
            builder.AppendLine("          vertical-align:top;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .col2SpanStyle       ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          font-family: Arial;");
            builder.AppendLine("          font-size: 16px;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .colInstructionStyle ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          font-family: Arial;");
            builder.AppendLine("          font-size: 14px;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .rowNormalStyle ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .rowUpperlineStyle ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          border-top:1px solid #000000;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .rowUnderlineStyle ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          border-bottom:1px solid #000000;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .rowHeightDefault ");
            builder.AppendLine("          {              ");
            if (this._col1Size.Height > this._col2Size.Height)
            {
                builder.AppendLine("          height: " + this._col1Size.Height.ToString() + "px;  ");
            }
            else
            {
                builder.AppendLine("          height: " + this._col2Size.Height.ToString() + "px;  ");
            }
            builder.AppendLine("          }              ");
            builder.AppendLine("    .rowHeightOther      ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          height: 30px;  ");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .rowHeight5px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          height:5px;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .rowHeight10px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          height:10px;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .rowHeight15px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          height:15px;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .rowHeight20px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          height:20px;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .rowHeight25px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          height:25px;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .rowHeight30px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          height:30px;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .rowHeight35px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          height:35px;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .rowHeight40px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          height:40px;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .rowHeight45px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          height:45px;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .rowHeight50px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          height:50px;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .cellAlignLeft ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          text-align: left;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .cellAlignRight ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          text-align: right;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .cellAlignCenter ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          text-align: center;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .cellFontArial12px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          font-family: Arial;");
            builder.AppendLine("          font-size: 12px;");
            builder.AppendLine("          font-weight: normal;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .cellFontArial14px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          font-family: Arial;");
            builder.AppendLine("          font-size: 14px;");
            builder.AppendLine("          font-weight: normal;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .cellFontArial16px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          font-family: Arial;");
            builder.AppendLine("          font-size: 16px;");
            builder.AppendLine("          font-weight: normal;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .cellFontArial20px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          font-family: Arial;");
            builder.AppendLine("          font-size: 20px;");
            builder.AppendLine("          font-weight: normal;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .cellFontArial24px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          font-family: Arial;");
            builder.AppendLine("          font-size: 24px;");
            builder.AppendLine("          font-weight: normal;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .cellFontArial30px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          font-family: Arial;");
            builder.AppendLine("          font-size: 30px;");
            builder.AppendLine("          font-weight: normal;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .cellFontArialBold12px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          font-family: Arial;");
            builder.AppendLine("          font-size: 12px;");
            builder.AppendLine("          font-weight: bold;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .cellFontArialBold14px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          font-family: Arial;");
            builder.AppendLine("          font-size: 14px;");
            builder.AppendLine("          font-weight: bold;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .cellFontArialBold16px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          font-family: Arial;");
            builder.AppendLine("          font-size: 16px;");
            builder.AppendLine("          font-weight: bold;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .cellFontArialBold20px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          font-family: Arial;");
            builder.AppendLine("          font-size: 20px;");
            builder.AppendLine("          font-weight: bold;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .cellFontArialBold24px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          font-family: Arial;");
            builder.AppendLine("          font-size: 24px;");
            builder.AppendLine("          font-weight: bold;");
            builder.AppendLine("          }              ");
            builder.AppendLine("    .cellFontArialBold30px ");
            builder.AppendLine("          {              ");
            builder.AppendLine("          font-family: Arial;");
            builder.AppendLine("          font-size: 30px;");
            builder.AppendLine("          font-weight: bold;");
            builder.AppendLine("          }              ");
            if (this.ControlsExistWithExtraButtons(base.Activities))
            {
                builder.AppendLine("    .copyButtonImageSmall ");
                builder.AppendLine("          {              ");
                builder.AppendLine("          width:16px;");
                builder.AppendLine("          height:16px;");
                builder.AppendLine("          float:left;");
                if (this._copyButton16by16 > null)
                {
                    builder.Append("          background: transparent url(data:image/png;base64,");
                    builder.Append(this._copyButton16by16);
                    builder.AppendLine(") no-repeat center center;");
                }
                builder.AppendLine("          }              ");
                builder.AppendLine("    .copyButtonImageMedium ");
                builder.AppendLine("          {              ");
                builder.AppendLine("          width:24px;");
                builder.AppendLine("          height:24px;");
                builder.AppendLine("          float:left;");
                if (this._copyButton24by24 > null)
                {
                    builder.Append("          background: transparent url(data:image/png;base64,");
                    builder.Append(this._copyButton24by24);
                    builder.AppendLine(") no-repeat center center;");
                }
                builder.AppendLine("          }              ");
                builder.AppendLine("    .copyButtonImageLarge ");
                builder.AppendLine("          {              ");
                builder.AppendLine("          width:32px;");
                builder.AppendLine("          height:32px;");
                builder.AppendLine("          float:left;");
                if (this._copyButton32by32 > null)
                {
                    builder.Append("          background: transparent url(data:image/png;base64,");
                    builder.Append(this._copyButton32by32);
                    builder.AppendLine(") no-repeat center center;");
                }
                builder.AppendLine("          }              ");
            }
            builder.AppendLine("</style>                 ");
            builder.AppendLine("</head>");
            builder.AppendLine("");
            return builder.ToString();
        }

        protected virtual string GetHtmlJavaScript()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<script type=\"text/javascript\" language=javascript> ");
            builder.AppendLine("var xmldoc = new ActiveXObject(\"Msxml2.DOMDocument.3.0\");");
            builder.AppendLine("");
            builder.AppendLine("var visitedControls = new Array();");
            builder.AppendLine("");
            builder.AppendLine("function testCrieria(param) {");
            builder.AppendLine("    var parts = param.split(\",\")");
            builder.AppendLine("    var controlName = parts[0];");
            builder.AppendLine("    var controlType = parts[1];");
            builder.AppendLine("    var conditional = parts[2];");
            builder.AppendLine("    var valueToTest = parts[3];");
            builder.AppendLine("");
            builder.AppendLine("    var currentValue;");
            builder.AppendLine("    if (controlType == 0)        // unknown type");
            builder.AppendLine("        currentValue = document.getElementById(controlName).value;");
            builder.AppendLine("    else if (controlType == 1)   // dropdown type");
            builder.AppendLine("        currentValue = document.getElementById(controlName).value;");
            builder.AppendLine("    else if (controlType == 2)   // label type");
            builder.AppendLine("        currentValue = document.getElementById(controlName).innerHTML;");
            builder.AppendLine("    else if (controlType == 3) { // radiobutton type");
            builder.AppendLine("        currentValue = \"\";");
            builder.AppendLine("        var radioArray = document.getElementsByName(controlName);");
            builder.AppendLine("    \t   if (radioArray) {");
            builder.AppendLine("            for (var i=0; i < radioArray.length; i++) {");
            builder.AppendLine("    \t           if (radioArray[i].checked)");
            builder.AppendLine("    \t\t           currentValue = radioArray[i].value;");
            builder.AppendLine("            }");
            builder.AppendLine("        }");
            builder.AppendLine("    }");
            builder.AppendLine("    else if (controlType == 4)   // textbox type");
            builder.AppendLine("        currentValue = document.getElementById(controlName).value;");
            builder.AppendLine("    else if (controlType == 5)   // textarea type");
            builder.AppendLine("        currentValue = document.getElementById(controlName).value;");
            builder.AppendLine("    else if (controlType == 6)   // hiddentextbox type");
            builder.AppendLine("        currentValue = document.getElementById(controlName).value;");
            builder.AppendLine("    else if (controlType == 7) { // calendar type");
            builder.AppendLine("        currentValue = document.getElementById(controlName + '_month').value;");
            builder.AppendLine("        currentValue += document.getElementById(controlName + '_day').value;");
            builder.AppendLine("        currentValue += document.getElementById(controlName + '_year').value;");
            builder.AppendLine("    }");
            builder.AppendLine("");
            builder.AppendLine("    if (conditional == 0) {         // equals");
            builder.AppendLine("        return (currentValue == valueToTest);");
            builder.AppendLine("    }");
            builder.AppendLine("    else if (conditional == 1) {    // greaterthan");
            builder.AppendLine("        return (currentValue > valueToTest);");
            builder.AppendLine("    }");
            builder.AppendLine("    else if (conditional == 2) {    // lessthan");
            builder.AppendLine("        return (currentValue < valueToTest);");
            builder.AppendLine("    }");
            builder.AppendLine("    else if (conditional == 3) {    // lengthgreaterthan");
            builder.AppendLine("        return (currentValue.length > valueToTest);");
            builder.AppendLine("    }");
            builder.AppendLine("    else if (conditional == 4) {    // lengthlessthan");
            builder.AppendLine("        return (currentValue.length < valueToTest);");
            builder.AppendLine("    }");
            builder.AppendLine("");
            builder.AppendLine("    return false;");
            builder.AppendLine("}");
            builder.AppendLine("");
            builder.AppendLine("function testCrieriaList(param) {");
            builder.AppendLine("    var criteria = param.split(\"|\");");
            builder.AppendLine("    var hasAnOr = false;");
            builder.AppendLine("    var orSatisfied = false;");
            builder.AppendLine("    var i;");
            builder.AppendLine("    for (i = 0; i < criteria.length; i++) {");
            builder.AppendLine("        var isTrue = testCrieria(criteria[i]);");
            builder.AppendLine("        var parts = criteria[i].split(\",\");");
            builder.AppendLine("        var operator = parts[4];");
            builder.AppendLine("        if (!isTrue && operator == 0)");
            builder.AppendLine("            return false;");
            builder.AppendLine("        if (isTrue && operator == 2)");
            builder.AppendLine("            return false;");
            builder.AppendLine("        if (operator == 1) {");
            builder.AppendLine("            hasAnOr = true;");
            builder.AppendLine("            if (isTrue)");
            builder.AppendLine("                orSatisfied = true;");
            builder.AppendLine("        };");
            builder.AppendLine("    };");
            builder.AppendLine("    if (hasAnOr && !orSatisfied)");
            builder.AppendLine("        return false;");
            builder.AppendLine("    return true;");
            builder.AppendLine("}");
            builder.AppendLine("");
            builder.AppendLine("function containsElement(a, obj){");
            builder.AppendLine("    for (var i = 0; i < a.length; i++) {");
            builder.AppendLine("        if (a[i] === obj)");
            builder.AppendLine("            return true;");
            builder.AppendLine("    };");
            builder.AppendLine("    return false;");
            builder.AppendLine("}");
            builder.AppendLine("");
            builder.AppendLine("function getStringForDate(name, format) {");
            builder.AppendLine("    var year = \"\";");
            builder.AppendLine("    var control = document.getElementById(name + \"_year\");");
            builder.AppendLine("    if (control) {");
            builder.AppendLine("        year = control.value;");
            builder.AppendLine("        if (year.length < 2)");
            builder.AppendLine("            return \"\";");
            builder.AppendLine("        if (year.length == 3)");
            builder.AppendLine("            return \"\";");
            builder.AppendLine("        if (year.length == 2) {");
            builder.AppendLine("            if (year[0] == \"0\" || year[0] == \"1\" || year[0] == \"2\")");
            builder.AppendLine("                year = \"20\" + year;");
            builder.AppendLine("            else");
            builder.AppendLine("                year = \"19\" + year;");
            builder.AppendLine("        }");
            builder.AppendLine("    }");
            builder.AppendLine("    else");
            builder.AppendLine("        return \"\";");
            builder.AppendLine("    var month = \"\";");
            builder.AppendLine("    control = document.getElementById(name + \"_month\");");
            builder.AppendLine("    if (control) {");
            builder.AppendLine("        month = control.value;");
            builder.AppendLine("        if (month.length < 1)");
            builder.AppendLine("            return \"\";");
            builder.AppendLine("        if (month.length == 1) {");
            builder.AppendLine("            month = \"0\" + month;");
            builder.AppendLine("        }");
            builder.AppendLine("    }");
            builder.AppendLine("    else");
            builder.AppendLine("        return \"\";");
            builder.AppendLine("    var day = \"\";");
            builder.AppendLine("    control = document.getElementById(name + \"_day\");");
            builder.AppendLine("    if (control) {");
            builder.AppendLine("        day = control.value;");
            builder.AppendLine("        if (day.length < 1)");
            builder.AppendLine("            return \"\";");
            builder.AppendLine("        if (day.length == 1) {");
            builder.AppendLine("            day = \"0\" + day;");
            builder.AppendLine("        }");
            builder.AppendLine("    }");
            builder.AppendLine("    else");
            builder.AppendLine("        return \"\";");
            builder.AppendLine("    if (format == \"YYYYMMDD\")");
            builder.AppendLine("        return year + month + day;");
            builder.AppendLine("    else");
            builder.AppendLine("        return month + day + year;");
            builder.AppendLine("}  ");
            builder.AppendLine("");
            builder.AppendLine("function getValueForRadioButton(name) {");
            builder.AppendLine("    var radioArray = document.getElementsByName(name);");
            builder.AppendLine("    if (radioArray) {");
            builder.AppendLine("        for (var i=0; i < radioArray.length; i++) {");
            builder.AppendLine("    \t       if (radioArray[i].checked)");
            builder.AppendLine("    \t\t       return radioArray[i].value;");
            builder.AppendLine("        }");
            builder.AppendLine("    }");
            builder.AppendLine("    return \"\";");
            builder.AppendLine("}  ");
            builder.AppendLine("");
            builder.AppendLine("function updateDropdownItems(sourceControl, destinationControl) {");
            builder.AppendLine("    var listOfNameValues = sourceControl.value.split(\"|\");");
            builder.AppendLine("    if (!listOfNameValues || listOfNameValues.length < 1)");
            builder.AppendLine("        return false;");
            builder.AppendLine("");
            builder.AppendLine("    destinationControl.options.length = 0;");
            builder.AppendLine("");
            builder.AppendLine("    var defaultElement = document.createElement(\"option\");");
            builder.AppendLine("    defaultElement.setAttribute(\"value\", \"\");");
            builder.AppendLine("    defaultElement.innerText = \"Please Select\";");
            builder.AppendLine("    destinationControl.appendChild(defaultElement)");
            builder.AppendLine("");
            builder.AppendLine("    for (var i = 0; i < listOfNameValues.length; i++) {");
            builder.AppendLine("        var valueAndName = listOfNameValues[i].split(\",\");");
            builder.AppendLine("        if (valueAndName.length > 1) {");
            builder.AppendLine("            var optionElement = document.createElement(\"option\");");
            builder.AppendLine("            optionElement.setAttribute(\"value\", valueAndName[0]);");
            builder.AppendLine("            optionElement.innerText = valueAndName[1];");
            builder.AppendLine("            destinationControl.appendChild(optionElement)");
            builder.AppendLine("        }");
            builder.AppendLine("    }");
            builder.AppendLine("");
            builder.AppendLine("    return true;");
            builder.AppendLine("}");
            builder.AppendLine("");
            builder.AppendLine("function updateRadioButtonItems(sourceControl, destinationControl) {");
            builder.AppendLine("    var listOfNameValues = sourceControl.value.split(\"|\");");
            builder.AppendLine("    if (!listOfNameValues || listOfNameValues.length < 1)");
            builder.AppendLine("        return false;");
            builder.AppendLine("");
            builder.AppendLine("    var parent = destinationControl.parentElement;");
            builder.AppendLine("    parent.removeChild(destinationControl);");
            builder.AppendLine("");
            builder.AppendLine("    for (var i = 0; i < listOfNameValues.length; i++) {");
            builder.AppendLine("        var valueAndName = listOfNameValues[i].split(\",\");");
            builder.AppendLine("        if (valueAndName.length > 1) {");
            builder.AppendLine("            var optionElement = document.createElement(destinationControl.outerHTML);");
            builder.AppendLine("            optionElement.setAttribute(\"value\", valueAndName[0]);");
            builder.AppendLine("            parent.innerHTML = parent.innerHTML + optionElement.outerHTML + \"&nbsp;&nbsp;\" + valueAndName[1] + \"<br />\";");
            builder.AppendLine("        }");
            builder.AppendLine("    }");
            builder.AppendLine("");
            builder.AppendLine("    return true;");
            builder.AppendLine("}");
            builder.AppendLine("");
            builder.AppendLine("function stateMachine(param) {");
            builder.AppendLine("    if (param && param == 'init') {");
            builder.AppendLine("        window.setTimeout(\"stateMachine('timer')\", 100);");
            builder.AppendLine("        return;");
            builder.AppendLine("    }");
            builder.AppendLine("    if (param && param == 'timer') {");
            builder.AppendLine("    }");
            builder.AppendLine("");
            builder.Append(this.BuildStateMachineBody(base.Activities));
            builder.AppendLine("}");
            builder.AppendLine("");
            builder.Append(this.BuildJavaScriptForControls(base.Activities));
            builder.AppendLine("");
            builder.AppendLine("function setOutputParametersOnClose() {");
            builder.AppendLine("    xmldoc.loadXML(\"<root></root>\");");
            builder.AppendLine("    var node; ");
            builder.Append(this.BuildUpdateCallDataXml(base.Activities));
            builder.AppendLine("");
            builder.AppendLine("    document.getElementById(\"CallDataToChange\").value = xmldoc.xml;");
            builder.AppendLine("}");
            builder.AppendLine("");
            builder.AppendLine("function setControlValueFromArray(controlName, controlType, varName, names, values){");
            builder.AppendLine("    for (var i = 0; i < names.length; i++) {");
            builder.AppendLine("        if (names[i] == varName) {");
            builder.AppendLine("            var newValue = values[i];");
            builder.AppendLine("            if (controlType == 7) { // calendar type");
            builder.AppendLine("                var year = document.getElementById(controlName + \"_year\");");
            builder.AppendLine("                var month = document.getElementById(controlName + \"_month\");");
            builder.AppendLine("                var day = document.getElementById(controlName + \"_day\");");
            builder.AppendLine("                if (year && month && day && newValue && newValue.length > 7) {");
            builder.AppendLine("                    month.value = newValue.substring(0, 2);");
            builder.AppendLine("                    day.value = newValue.substring(2, 4);");
            builder.AppendLine("                    year.value = newValue.substring(4, 8);");
            builder.AppendLine("                }");
            builder.AppendLine("            }");
            builder.AppendLine("            else if (controlType == 3) { // radiobutton type");
            builder.AppendLine("                var radioArray = document.getElementsByName(controlName);");
            builder.AppendLine("    \t           if (radioArray) {");
            builder.AppendLine("                    for (var i=0; i < radioArray.length; i++) {");
            builder.AppendLine("    \t                   if (newValue == radioArray[i].value)");
            builder.AppendLine("    \t\t                    radioArray[i].checked = \"true\";");
            builder.AppendLine("                    }");
            builder.AppendLine("                }");
            builder.AppendLine("            }");
            builder.AppendLine("            else {");
            builder.AppendLine("                var control = document.getElementById(controlName);");
            builder.AppendLine("                if (control)");
            builder.AppendLine("                    control.value = newValue;");
            builder.AppendLine("            }");
            builder.AppendLine("            return true;");
            builder.AppendLine("        }");
            builder.AppendLine("    };");
            builder.AppendLine("    return false;");
            builder.AppendLine("}");
            builder.AppendLine("");
            builder.AppendLine("function updateUserSelectionsForReplay(varNames, varValues) {");
            builder.Append(this.BuildJavaScriptForReplay(base.Activities));
            builder.AppendLine("");
            builder.AppendLine("    stateMachine(\"init\");");
            builder.AppendLine("}");
            builder.AppendLine("");
            return builder.ToString();
        }

        protected virtual string GetJavaScriptClosingTag()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("");
            builder.AppendLine("</script> ");
            return builder.ToString();
        }

        private string GetJavaScriptToInitControl(GUIElement outputElement)
        {
            StringBuilder builder = new StringBuilder();
            if (((outputElement.DestinationCallVariable != null) && (outputElement.DestinationCallVariable.Length > 0)) && this.CallVariableMap.ContainsKey(outputElement.DestinationCallVariable))
            {
                string str = (string) this.CallVariableMap[outputElement.DestinationCallVariable];
            }
            else if ((((outputElement is DropDown) || (outputElement is RadioButton)) || ((outputElement is TextBox) || (outputElement is TextArea))) || (outputElement is Calendar))
            {
                string[] textArray1 = new string[] { "    setControlValueFromArray(\"", outputElement.Name, "\", \"", this._elementTypeMap[outputElement.GetType()].ToString(), "\", \"", outputElement.Name, "\",varNames, varValues);" };
                builder.AppendLine(string.Concat(textArray1));
            }
            return builder.ToString();
        }

        private string GetJavaScriptToShowHideRows(IfElseBranch currentBranch, ArrayList listOfLists, int curColumn)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < listOfLists.Count; i++)
            {
                foreach (Activity activity in (ArrayList) listOfLists[i])
                {
                    string rowIdentifier = null;
                    if (activity is GUIElement)
                    {
                        if (!(activity is HiddenTextBox))
                        {
                            rowIdentifier = ((GUIElement) activity).RowIdentifier;
                        }
                    }
                    else if (activity is ButtonBase)
                    {
                        rowIdentifier = ((ButtonBase) activity).RowIdentifier;
                    }
                    if (rowIdentifier > null)
                    {
                        if (i == curColumn)
                        {
                            if ((currentBranch != null) && (currentBranch == activity.Parent))
                            {
                                if ((activity is ButtonBase) && ((ButtonBase) activity).AutoFire)
                                {
                                    builder.AppendLine("    if (document.getElementById('" + activity.Name + "_Clicked').value != '1') {");
                                    builder.AppendLine("        document.getElementById('" + activity.Name + "_Clicked').value = '1';");
                                    builder.AppendLine("        document.getElementById('" + activity.Name + "').click();");
                                    builder.AppendLine("    }");
                                }
                                else
                                {
                                    builder.AppendLine("    document.getElementById('" + rowIdentifier + "').style.display = '';");
                                }
                            }
                        }
                        else
                        {
                            builder.AppendLine("    document.getElementById('" + rowIdentifier + "').style.display = 'none';");
                            if ((activity is ButtonBase) && ((ButtonBase) activity).AutoFire)
                            {
                                builder.AppendLine("        document.getElementById('" + activity.Name + "_Clicked').value = '0';");
                            }
                        }
                    }
                }
            }
            return builder.ToString();
        }

        private ArrayList GetListOfChildren(ActivityCollection childActivites)
        {
            ArrayList list = new ArrayList();
            foreach (Activity activity in childActivites)
            {
                if (activity.GetType() == typeof(IfElseTest))
                {
                    IfElseTest test = (IfElseTest) activity;
                    list.AddRange(this.GetListOfChildren(test.Activities));
                }
                else if (activity.GetType() == typeof(IfElseBranch))
                {
                    IfElseBranch branch = (IfElseBranch) activity;
                    list.AddRange(this.GetListOfChildren(branch.Activities));
                }
                else
                {
                    list.Add(activity);
                }
            }
            return list;
        }

        private string GetXmlForDestinationCallVar(GUIElement outputElement)
        {
            StringBuilder builder = new StringBuilder();
            if (((outputElement.DestinationCallVariable != null) && (outputElement.DestinationCallVariable.Length > 0)) && this.CallVariableMap.ContainsKey(outputElement.DestinationCallVariable))
            {
                string callVar = (string) this.CallVariableMap[outputElement.DestinationCallVariable];
                builder.AppendLine("    node = xmldoc.selectSingleNode(\"//root\");");
                builder.AppendLine("    if (node && containsElement(visitedControls, '" + outputElement.Name + "')) {");
                builder.AppendLine("        var callVarElement = xmldoc.createElement(\"callvar\");");
                builder.AppendLine("        var typeElement = xmldoc.createElement(\"type\");");
                builder.AppendLine("        callVarElement.appendChild(typeElement);");
                builder.AppendLine("        var nameElement = xmldoc.createElement(\"name\");");
                builder.AppendLine("        nameElement.appendChild(xmldoc.createTextNode(\"" + callVar + "\"));");
                builder.AppendLine("        callVarElement.appendChild(nameElement);");
                builder.AppendLine("        var valueElement = xmldoc.createElement(\"value\");");
                builder.Append("        valueElement.appendChild(xmldoc.createTextNode(");
                builder.AppendLine(outputElement.GetJavaScriptForValue(callVar) + "));");
                builder.AppendLine("        callVarElement.appendChild(valueElement);");
                builder.AppendLine("        var startElement = xmldoc.createElement(\"start\");");
                builder.AppendLine("        startElement.appendChild(xmldoc.createTextNode(\"" + callVar.ToString() + "\"));");
                builder.AppendLine("        callVarElement.appendChild(startElement);");
                builder.AppendLine("        var lengthElement = xmldoc.createElement(\"length\");");
                builder.AppendLine("        lengthElement.appendChild(xmldoc.createTextNode(\"" + callVar.ToString() + "\"));");
                builder.AppendLine("        callVarElement.appendChild(lengthElement);");
                builder.AppendLine("        node.appendChild(callVarElement);");
                builder.AppendLine("    };");
                builder.Append(this.GetDefaultXmlForDestinationCallVar(outputElement, null));
            }
            else if ((((outputElement is DropDown) || (outputElement is RadioButton)) || ((outputElement is TextBox) || (outputElement is TextArea))) || (outputElement is Calendar))
            {
                builder.Append(this.GetDefaultXmlForDestinationCallVar(outputElement, null));
            }
            return builder.ToString();
        }

        private string ImageToPngBase64(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Png);
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        private void UpdateControlPropertiesFromChangedProperty(Activity control)
        {
            if (control.GetType() == typeof(IfElseBranch))
            {
                ArrayList list = ((IfElseBranch) control).Criteria;
                if ((list != null) && (list.Count != 0))
                {
                    ArrayList newValue = new ArrayList();
                    bool flag2 = false;
                    foreach (IfElseCriteria criteria in list)
                    {
                        IfElseCriteria criteria2 = criteria;
                        if (this.changedControl.GetType() == typeof(ValidateButton))
                        {
                            char[] separator = new char[] { '_' };
                            string[] strArray = criteria.ActivityName.Split(separator);
                            if (strArray.Length > 1)
                            {
                                string str2 = strArray[0];
                                string str3 = strArray[1];
                                if (str2 == this.changedControl.Name)
                                {
                                    ArrayList outputParameters = ((ValidateButton) this.changedControl).OutputParameters;
                                    if ((outputParameters == null) || (outputParameters.Count == 0))
                                    {
                                        criteria2 = null;
                                        flag2 = true;
                                    }
                                    else
                                    {
                                        bool flag8 = false;
                                        foreach (ValidateOutputParameter parameter in outputParameters)
                                        {
                                            if (parameter.ParameterName == str3)
                                            {
                                                flag8 = true;
                                            }
                                        }
                                        if (!flag8)
                                        {
                                            criteria2 = null;
                                            flag2 = true;
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
                    if (flag2)
                    {
                        this.UpdatePropertyForDesigner(control, "Criteria", ((IfElseBranch) control).Criteria, newValue);
                    }
                }
            }
        }

        private void UpdateControlPropertiesWithNewReferencedName(Activity control)
        {
            if (control.GetType() == typeof(IfElseBranch))
            {
                ArrayList list = ((IfElseBranch) control).Criteria;
                if ((list != null) && (list.Count != 0))
                {
                    ArrayList newValue = new ArrayList();
                    bool flag2 = false;
                    foreach (IfElseCriteria criteria in list)
                    {
                        string activityName = criteria.ActivityName;
                        string newNameOfControl = this.newNameOfControl;
                        if (this.changedControl.GetType() == typeof(ValidateButton))
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
                        if (activityName == this.oldNameOfControl)
                        {
                            if ((this.newNameOfControl != null) && (this.newNameOfControl.Length > 0))
                            {
                                IfElseCriteria criteria2 = new IfElseCriteria {
                                    ActivityName = newNameOfControl,
                                    Conditional = criteria.Conditional,
                                    Operator = criteria.Operator,
                                    ValueToTest = criteria.ValueToTest
                                };
                                newValue.Add(criteria2);
                            }
                            flag2 = true;
                        }
                        else
                        {
                            newValue.Add(criteria);
                        }
                    }
                    if (flag2)
                    {
                        this.UpdatePropertyForDesigner(control, "Criteria", ((IfElseBranch) control).Criteria, newValue);
                    }
                }
            }
            else if (control.GetType() == typeof(ValidateButton))
            {
                ArrayList inputParameters = ((ValidateButton) control).InputParameters;
                if ((inputParameters != null) && (inputParameters.Count > 0))
                {
                    ArrayList newValue = new ArrayList();
                    bool flag12 = false;
                    foreach (ValidateInputParameter parameter in inputParameters)
                    {
                        if (parameter.ActivityName == this.oldNameOfControl)
                        {
                            if ((this.newNameOfControl != null) && (this.newNameOfControl.Length > 0))
                            {
                                ValidateInputParameter parameter2 = new ValidateInputParameter {
                                    ActivityName = this.newNameOfControl,
                                    IsAStaticValue = parameter.IsAStaticValue,
                                    ParameterName = parameter.ParameterName,
                                    StaticValue = parameter.StaticValue
                                };
                                newValue.Add(parameter2);
                            }
                            flag12 = true;
                        }
                        else
                        {
                            newValue.Add(parameter);
                        }
                    }
                    if (flag12)
                    {
                        this.UpdatePropertyForDesigner(control, "InputParameters", ((ValidateButton) control).InputParameters, newValue);
                    }
                }
                ArrayList outputParameters = ((ValidateButton) control).OutputParameters;
                if ((outputParameters != null) && (outputParameters.Count > 0))
                {
                    ArrayList newValue = new ArrayList();
                    bool flag17 = false;
                    foreach (ValidateOutputParameter parameter3 in outputParameters)
                    {
                        if (parameter3.DestinationControl == this.oldNameOfControl)
                        {
                            if ((this.newNameOfControl != null) && (this.newNameOfControl.Length > 0))
                            {
                                ValidateOutputParameter parameter4 = new ValidateOutputParameter {
                                    DestinationControl = this.newNameOfControl,
                                    InitialValue = parameter3.InitialValue,
                                    ParameterName = parameter3.ParameterName
                                };
                                newValue.Add(parameter4);
                            }
                            flag17 = true;
                        }
                        else
                        {
                            newValue.Add(parameter3);
                        }
                    }
                    if (flag17)
                    {
                        this.UpdatePropertyForDesigner(control, "OutputParameters", ((ValidateButton) control).OutputParameters, newValue);
                    }
                }
            }
        }

        protected void UpdatePropertyForDesigner(Activity control, string propertyName, object oldValue, object newValue)
        {
            try
            {
                PropertyDescriptor member = TypeDescriptor.GetProperties(control)[propertyName];
                this.designerCcs.OnComponentChanging(control, member);
                member.SetValue(control, newValue);
                this.designerCcs.OnComponentChanged(control, member, oldValue, newValue);
            }
            catch (CheckoutException exception)
            {
                if (exception != CheckoutException.Canceled)
                {
                    throw exception;
                }
            }
        }

        protected virtual void UpdateReferencesToControl(ActivityCollection childActivites)
        {
            foreach (Activity activity in childActivites)
            {
                if ((activity is GUIElement) || (activity is ButtonBase))
                {
                    if (this.changedMember == null)
                    {
                        this.UpdateControlPropertiesWithNewReferencedName(activity);
                    }
                }
                else if (activity.GetType() == typeof(IfElseTest))
                {
                    IfElseTest test = (IfElseTest) activity;
                    this.UpdateReferencesToControl(test.Activities);
                }
                else if (activity.GetType() == typeof(IfElseBranch))
                {
                    IfElseBranch branch = (IfElseBranch) activity;
                    if (this.changedMember == null)
                    {
                        this.UpdateControlPropertiesWithNewReferencedName(activity);
                    }
                    else
                    {
                        this.UpdateControlPropertiesFromChangedProperty(activity);
                    }
                    this.UpdateReferencesToControl(branch.Activities);
                }
            }
        }

        [Browsable(true), ReadOnly(true), Category("General"), Description("Name of the workflow.  This cannot be changed.")]
        public string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }

        [Browsable(true), Category("General"), Description("Description of the workflow.")]
        public string Description
        {
            get
            {
                return base.Description;
            }
            set
            {
                base.Description = value;
            }
        }

        [Browsable(true), ReadOnly(true), Category("General"), Description("Enable/disable the workflow.")]
        public bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
            }
        }

        [Browsable(true), Category("Appearance"), Description("Maximum width and height for cells in column 1.")]
        public Size Column1Size
        {
            get
            {
                return this._col1Size;
            }
            set
            {
                this._col1Size = value;
            }
        }

        [Browsable(true), Category("Appearance"), Description("Maximum width and height for cells in column 2.")]
        public Size Column2Size
        {
            get
            {
                return this._col2Size;
            }
            set
            {
                this._col2Size = value;
            }
        }

        [Browsable(false)]
        public ActivityCondition DynamicUpdateCondition
        {
            get
            {
                return base.DynamicUpdateCondition;
            }
            set
            {
                base.DynamicUpdateCondition = value;
            }
        }

        [Browsable(false)]
        public virtual string GetHtml
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(this.GetHtmlHeadingTag());
                builder.Append(this.GetHtmlJavaScript());
                builder.Append(this.GetJavaScriptClosingTag());
                builder.Append(this.GetHtmlBodyTag());
                builder.Append(this.GetHtmlForControls());
                builder.Append(this.GetHiddenInputFields());
                builder.Append(this.GetHtmlClosingTags());
                return builder.ToString();
            }
        }

        [Browsable(false)]
        public Hashtable CallVariableMap
        {
            get
            {
                if (this._callVarMap <= null)
                {
                    this._callVarMap = new Hashtable(StringComparer.CurrentCultureIgnoreCase);
                    List<string> callVariableList = this.CallVariableList;
                    if (callVariableList > null)
                    {
                        foreach (string str in callVariableList)
                        {
                            if ((str > null) && !this._callVarMap.ContainsKey(str))
                            {
                                this._callVarMap.Add(str, str);
                            }
                        }
                    }
                }
                return this._callVarMap;
            }
        }

        [Browsable(false)]
        public List<string> CallVariableNames
        {
            get
            {
                if (this._callVarNames <= null)
                {
                    this._callVarNames = new List<string>();
                    List<string> callVariableList = this.CallVariableList;
                    if (callVariableList > null)
                    {
                        foreach (string str in callVariableList)
                        {
                            this._callVarNames.Add(str);
                        }
                    }
                    this._callVarNames.Sort();
                }
                return this._callVarNames;
            }
        }

        [Browsable(false)]
        public List<string> CallVariableList
        {
            get
            {
                if (this._callVarList <= null)
                {
                    this._callVarList = DBHelper.GetScreenPopsAndCallVars();
                }
                return this._callVarList;
            }
        }
    }
}

