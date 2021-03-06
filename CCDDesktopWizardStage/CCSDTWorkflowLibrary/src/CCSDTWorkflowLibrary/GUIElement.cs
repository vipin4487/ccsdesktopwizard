namespace CCSDTWorkflowLibrary
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Text;
    using System.Windows.Forms;
    using System.Workflow.ComponentModel;

    public abstract class GUIElement : ControlBase
    {
        private string _labelText;
        private string _initialValue;
        protected ButtonsType _controlButtons = ButtonsType.None;
        public static DependencyProperty SourceCallVariableProperty = DependencyProperty.Register("SourceCallVariable", typeof(string), typeof(GUIElement), new PropertyMetadata(DependencyPropertyOptions.Metadata));
        public static DependencyProperty DestinationCallVariableProperty = DependencyProperty.Register("DestinationCallVariable", typeof(string), typeof(GUIElement), new PropertyMetadata(DependencyPropertyOptions.Metadata));
        public string strValue;

        protected void AddCallVarTags(StringBuilder sb)
        {
            if (sb != null)
            {
                if ((this.SourceCallVariable != null) && (this.SourceCallVariable.Length > 0))
                {
                    sb.Append("sourcecallvar=\"" + this.SourceCallVariable + "\" ");
                }
                if ((this.DestinationCallVariable != null) && (this.DestinationCallVariable.Length > 0))
                {
                    sb.Append("destinationcallvar=\"" + this.DestinationCallVariable + "\" ");
                }
                if ((this.InitialValue != null) && (this.InitialValue.Length > 0))
                {
                    sb.Append("initialvalue=\"" + this.InitialValue + "\" ");
                }
            }
        }

        public virtual string GetJavaScriptForValue(string callVar)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("document.getElementById(\"" + base.Name + "\").value");
            return builder.ToString();
        }

        [Browsable(true), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor)), Description("Initial value for the control, SourceCallVariable will override this.")]
        public string InitialValue
        {
            get => 
                this._initialValue;
            set => 
                this._initialValue = value;
        }

        [Browsable(true), Category("Appearance"), Description("Label to display before the control.")]
        public string LabelText
        {
            get => 
                this._labelText;
            set => 
                this._labelText = value;
        }

        [TypeConverter(typeof(StringListConverter)), DefaultValue("{none}"), Category("Call Data"), Description("The name of the call variable to display.")]
        public string SourceCallVariable
        {
            get
            {
                string str = Convert.ToString(base.GetValue(SourceCallVariableProperty));
                return ((str != "{none}") ? str : null);
            }
            set => 
                base.SetValue(SourceCallVariableProperty, value);
        }

        [TypeConverter(typeof(StringListConverter)), DefaultValue("{none}"), Category("Call Data"), Description("The name of the call variable to update.")]
        public string DestinationCallVariable
        {
            get
            {
                string str = Convert.ToString(base.GetValue(DestinationCallVariableProperty));
                return ((str != "{none}") ? str : null);
            }
            set => 
                base.SetValue(DestinationCallVariableProperty, value);
        }

        [Editor(typeof(DropdownEditorBox), typeof(UITypeEditor)), DefaultValue("{none}"), DisplayName("New Call Variable"), Category("Add Call Data"), Description("The name of the call variable to update.")]
        public string New_Call_Variable
        {
            get => 
                this.strValue;
            set => 
                this.strValue = value;
        }

        [Browsable(false), DefaultValue(0), Category("Misc"), Description("Extra control buttons for the generated control.")]
        public virtual ButtonsType ButtonsForControl
        {
            get => 
                this._controlButtons;
            set => 
                this._controlButtons = value;
        }

        [Browsable(false), Category("General"), Description("Gets the HTML for the control.")]
        public virtual string GetHtml =>
            null;

        [Browsable(false), Category("General"), Description("TD tag for column 1 for this control.")]
        public virtual string GetColumn1Tag
        {
            get
            {
                string str;
                if (base.ColorOfLabel.ToArgb() == Color.Black.ToArgb())
                {
                    if (base.ColorOfBackground.ToArgb() != Color.White.ToArgb())
                    {
                        string[] textArray1 = new string[] { "<td class=\"", this.GetClassForRow, this.GetClassForLabel, " col1Style\">", this.LabelText, "</td>" };
                        str = string.Concat(textArray1);
                    }
                    else
                    {
                        string[] textArray2 = new string[] { "<td class=\"", this.GetClassForRow, this.GetClassForLabel, " col1Style\" style=\"background-color: ", ColorTranslator.ToHtml(base.BackgroundColorOfLabel), "\">", this.LabelText, "</td>" };
                        str = string.Concat(textArray2);
                    }
                }
                else if (base.ColorOfBackground.ToArgb() != Color.White.ToArgb())
                {
                    string[] textArray3 = new string[] { "<td class=\"", this.GetClassForRow, this.GetClassForLabel, " col1Style\" style=\"color: ", ColorTranslator.ToHtml(base.ColorOfLabel), "\">", this.LabelText, "</td>" };
                    str = string.Concat(textArray3);
                }
                else
                {
                    string[] textArray4 = new string[10];
                    textArray4[0] = "<td class=\"";
                    textArray4[1] = this.GetClassForRow;
                    textArray4[2] = this.GetClassForLabel;
                    textArray4[3] = " col1Style\" style=\"color: ";
                    textArray4[4] = ColorTranslator.ToHtml(base.ColorOfLabel);
                    textArray4[5] = ";background-color: ";
                    textArray4[6] = ColorTranslator.ToHtml(base.BackgroundColorOfLabel);
                    textArray4[7] = "\">";
                    textArray4[8] = this.LabelText;
                    textArray4[9] = "</td>";
                    str = string.Concat(textArray4);
                }
                return str;
            }
        }

        [Browsable(false), Category("General"), Description("TD tag for column 2 for this control.")]
        public virtual string GetColumn2Tag
        {
            get
            {
                string str;
                if (base.ColorOfControl.ToArgb() == Color.Black.ToArgb())
                {
                    if (base.ColorOfBackground.ToArgb() != Color.White.ToArgb())
                    {
                        str = "<td class=\"" + this.GetClassForRow + this.GetClassForControl + " col2Style\">";
                    }
                    else
                    {
                        string[] textArray1 = new string[] { "<td class=\"", this.GetClassForRow, this.GetClassForControl, " col2Style\" style=\"background-color: ", ColorTranslator.ToHtml(base.BackgroundColorOfControl), "\">" };
                        str = string.Concat(textArray1);
                    }
                }
                else if (base.ColorOfBackground.ToArgb() != Color.White.ToArgb())
                {
                    string[] textArray2 = new string[] { "<td class=\"", this.GetClassForRow, this.GetClassForControl, " col2Style\" style=\"color: ", ColorTranslator.ToHtml(base.ColorOfControl), "\">" };
                    str = string.Concat(textArray2);
                }
                else
                {
                    string[] textArray3 = new string[] { "<td class=\"", this.GetClassForRow, this.GetClassForControl, " col2Style\" style=\"color: ", ColorTranslator.ToHtml(base.ColorOfControl), ";background-color: ", ColorTranslator.ToHtml(base.BackgroundColorOfControl), "\">" };
                    str = string.Concat(textArray3);
                }
                return str;
            }
        }

        [Browsable(false), Category("General"), Description("Gets call variable reserved word for the control.")]
        protected virtual string GetCallVarReservedWord
        {
            get
            {
                string str2;
                if ((this.SourceCallVariable == null) || (this.SourceCallVariable.Length == 0))
                {
                    str2 = "";
                }
                else
                {
                    string str = null;
                    CustomCCSDTWorkflowBase getParentWorkflow = this.GetParentWorkflow;
                    if (((getParentWorkflow != null) && (this.SourceCallVariable != null)) && getParentWorkflow.CallVariableMap.ContainsKey(this.SourceCallVariable))
                    {
                        str = (string) getParentWorkflow.CallVariableMap[this.SourceCallVariable];
                    }
                    str2 = "<callvar, " + str + ">";
                }
                return str2;
            }
        }

        [Browsable(false), Category("General"), Description("HTML for extra control buttons if selected.")]
        public virtual string GetButtonsHtml
        {
            get
            {
                string str;
                switch (this.ButtonsForControl)
                {
                    case ButtonsType.CopySmall:
                    {
                        string[] textArray1 = new string[] { "<div id=\"", base.Name, "_copybutton\" class=\"copyButtonImageSmall\" title=\"Copy to clipboard\" onclick=\"window.clipboardData.setData('text', document.getElementById('", base.Name, "').value );\"></div>" };
                        str = string.Concat(textArray1);
                        break;
                    }
                    case ButtonsType.CopyMedium:
                    {
                        string[] textArray2 = new string[] { "<div id=\"", base.Name, "_copybutton\" class=\"copyButtonImageMedium\" title=\"Copy to clipboard\" onclick=\"window.clipboardData.setData('text', document.getElementById('", base.Name, "').value );\"></div>" };
                        str = string.Concat(textArray2);
                        break;
                    }
                    case ButtonsType.CopyLarge:
                    {
                        string[] textArray3 = new string[] { "<div id=\"", base.Name, "_copybutton\" class=\"copyButtonImageLarge\" title=\"Copy to clipboard\" onclick=\"window.clipboardData.setData('text', document.getElementById('", base.Name, "').value );\"></div>" };
                        str = string.Concat(textArray3);
                        break;
                    }
                    default:
                        str = "";
                        break;
                }
                return str;
            }
        }

        public class DropdownEditorBox : UITypeEditor
        {
            public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                object obj2;
                if ((value == null) || (value.ToString().Trim() == ""))
                {
                    MessageBox.Show("Please provide the new Call variable details to add", "Alert", MessageBoxButtons.OK);
                    obj2 = value;
                }
                else
                {
                    if (DBHelper.IsCallVariableExists(value.ToString()))
                    {
                        MessageBox.Show("Call Variable data already exists", "Alert", MessageBoxButtons.OK);
                    }
                    else
                    {
                        DBHelper.InserCallVariableData(value.ToString());
                        MessageBox.Show("Successfully added Call Variable", "Alert", MessageBoxButtons.OK);
                        DBHelper.DoCallVariableRefresh();
                    }
                    obj2 = base.EditValue(context, provider, value);
                }
                return obj2;
            }

            public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) => 
                UITypeEditorEditStyle.DropDown;

            public TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                ArrayList objA = null;
                foreach (object obj2 in context.Container.Components)
                {
                    if (obj2 is CustomCCSDTWorkflowBase)
                    {
                        objA = new ArrayList(((CustomCCSDTWorkflowBase) obj2).CallVariableNames);
                    }
                }
                if (ReferenceEquals(objA, null))
                {
                    objA = new ArrayList();
                }
                objA.Insert(0, "{none}");
                return new TypeConverter.StandardValuesCollection(objA);
            }
        }

        public class StringListConverter : TypeConverter
        {
            public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                ArrayList objA = null;
                foreach (object obj2 in context.Container.Components)
                {
                    if (obj2 is CustomCCSDTWorkflowBase)
                    {
                        objA = new ArrayList(((CustomCCSDTWorkflowBase) obj2).CallVariableNames);
                    }
                }
                if (ReferenceEquals(objA, null))
                {
                    objA = new ArrayList();
                }
                objA.Insert(0, "{none}");
                return new TypeConverter.StandardValuesCollection(objA);
            }

            public override bool GetStandardValuesSupported(ITypeDescriptorContext context) => 
                true;
        }
    }
}

