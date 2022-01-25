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

    public abstract class GUIElement : ControlBase
    {
        private string _labelText;
        private string _initialValue;
        protected ButtonsType _controlButtons = ButtonsType.None;
        public static DependencyProperty SourceCallVariableProperty = DependencyProperty.Register("SourceCallVariable", typeof(string), typeof(GUIElement), new PropertyMetadata(DependencyPropertyOptions.Metadata));
        public static DependencyProperty DestinationCallVariableProperty = DependencyProperty.Register("DestinationCallVariable", typeof(string), typeof(GUIElement), new PropertyMetadata(DependencyPropertyOptions.Metadata));

        protected void AddCallVarTags(StringBuilder sb)
        {
            if (sb > null)
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
            get
            {
                return this._initialValue;
            }
            set
            {
                this._initialValue = value;
            }
        }

        [Browsable(true), Category("Appearance"), Description("Label to display before the control.")]
        public string LabelText
        {
            get
            {
                return this._labelText;
            }
            set
            {
                this._labelText = value;
            }
        }

        [TypeConverter(typeof(StringListConverter)), DefaultValue("{none}"), Category("Call Data"), Description("The name of the call variable to display.")]
        public string SourceCallVariable
        {
            get
            {
                string str = Convert.ToString(base.GetValue(SourceCallVariableProperty));
                if (str == "{none}")
                {
                    return null;
                }
                return str;
            }
            set
            {
                base.SetValue(SourceCallVariableProperty, value);
            }
        }

        [TypeConverter(typeof(StringListConverter)), DefaultValue("{none}"), Category("Call Data"), Description("The name of the call variable to update.")]
        public string DestinationCallVariable
        {
            get
            {
                string str = Convert.ToString(base.GetValue(DestinationCallVariableProperty));
                if (str == "{none}")
                {
                    return null;
                }
                return str;
            }
            set
            {
                base.SetValue(DestinationCallVariableProperty, value);
            }
        }

        [Browsable(false), DefaultValue(0), Category("Misc"), Description("Extra control buttons for the generated control.")]
        public virtual ButtonsType ButtonsForControl
        {
            get
            {
                return this._controlButtons;
            }
            set
            {
                this._controlButtons = value;
            }
        }

        [Browsable(false), Category("General"), Description("Gets the HTML for the control.")]
        public virtual string GetHtml
        {
            get
            {
                return null;
            }
        }

        [Browsable(false), Category("General"), Description("TD tag for column 1 for this control.")]
        public virtual string GetColumn1Tag
        {
            get
            {
                if (base.ColorOfLabel.ToArgb() == Color.Black.ToArgb())
                {
                    if (base.ColorOfBackground.ToArgb() != Color.White.ToArgb())
                    {
                        string[] textArray1 = new string[] { "<td class=\"", this.GetClassForRow, this.GetClassForLabel, " col1Style\">", this.LabelText, "</td>" };
                        return string.Concat(textArray1);
                    }
                    string[] textArray2 = new string[] { "<td class=\"", this.GetClassForRow, this.GetClassForLabel, " col1Style\" style=\"background-color: ", ColorTranslator.ToHtml(base.BackgroundColorOfLabel), "\">", this.LabelText, "</td>" };
                    return string.Concat(textArray2);
                }
                if (base.ColorOfBackground.ToArgb() != Color.White.ToArgb())
                {
                    string[] textArray3 = new string[] { "<td class=\"", this.GetClassForRow, this.GetClassForLabel, " col1Style\" style=\"color: ", ColorTranslator.ToHtml(base.ColorOfLabel), "\">", this.LabelText, "</td>" };
                    return string.Concat(textArray3);
                }
                string[] textArray4 = new string[] { "<td class=\"", this.GetClassForRow, this.GetClassForLabel, " col1Style\" style=\"color: ", ColorTranslator.ToHtml(base.ColorOfLabel), ";background-color: ", ColorTranslator.ToHtml(base.BackgroundColorOfLabel), "\">", this.LabelText, "</td>" };
                return string.Concat(textArray4);
            }
        }

        [Browsable(false), Category("General"), Description("TD tag for column 2 for this control.")]
        public virtual string GetColumn2Tag
        {
            get
            {
                if (base.ColorOfControl.ToArgb() == Color.Black.ToArgb())
                {
                    if (base.ColorOfBackground.ToArgb() != Color.White.ToArgb())
                    {
                        return ("<td class=\"" + this.GetClassForRow + this.GetClassForControl + " col2Style\">");
                    }
                    string[] textArray1 = new string[] { "<td class=\"", this.GetClassForRow, this.GetClassForControl, " col2Style\" style=\"background-color: ", ColorTranslator.ToHtml(base.BackgroundColorOfControl), "\">" };
                    return string.Concat(textArray1);
                }
                if (base.ColorOfBackground.ToArgb() != Color.White.ToArgb())
                {
                    string[] textArray2 = new string[] { "<td class=\"", this.GetClassForRow, this.GetClassForControl, " col2Style\" style=\"color: ", ColorTranslator.ToHtml(base.ColorOfControl), "\">" };
                    return string.Concat(textArray2);
                }
                string[] textArray3 = new string[] { "<td class=\"", this.GetClassForRow, this.GetClassForControl, " col2Style\" style=\"color: ", ColorTranslator.ToHtml(base.ColorOfControl), ";background-color: ", ColorTranslator.ToHtml(base.BackgroundColorOfControl), "\">" };
                return string.Concat(textArray3);
            }
        }

        [Browsable(false), Category("General"), Description("Gets call variable reserved word for the control.")]
        protected virtual string GetCallVarReservedWord
        {
            get
            {
                if ((this.SourceCallVariable == null) || (this.SourceCallVariable.Length == 0))
                {
                    return "";
                }
                string str = null;
                CustomCCSDTWorkflowBase getParentWorkflow = this.GetParentWorkflow;
                if (((getParentWorkflow != null) && (this.SourceCallVariable > null)) && getParentWorkflow.CallVariableMap.ContainsKey(this.SourceCallVariable))
                {
                    str = (string) getParentWorkflow.CallVariableMap[this.SourceCallVariable];
                }
                return str;
            }
        }

        [Browsable(false), Category("General"), Description("HTML for extra control buttons if selected.")]
        public virtual string GetButtonsHtml
        {
            get
            {
                switch (this.ButtonsForControl)
                {
                    case ButtonsType.CopySmall:
                    {
                        string[] textArray1 = new string[] { "<div id=\"", base.Name, "_copybutton\" class=\"copyButtonImageSmall\" title=\"Copy to clipboard\" onclick=\"window.clipboardData.setData('text', document.getElementById('", base.Name, "').value );\"></div>" };
                        return string.Concat(textArray1);
                    }
                    case ButtonsType.CopyMedium:
                    {
                        string[] textArray2 = new string[] { "<div id=\"", base.Name, "_copybutton\" class=\"copyButtonImageMedium\" title=\"Copy to clipboard\" onclick=\"window.clipboardData.setData('text', document.getElementById('", base.Name, "').value );\"></div>" };
                        return string.Concat(textArray2);
                    }
                    case ButtonsType.CopyLarge:
                    {
                        string[] textArray3 = new string[] { "<div id=\"", base.Name, "_copybutton\" class=\"copyButtonImageLarge\" title=\"Copy to clipboard\" onclick=\"window.clipboardData.setData('text', document.getElementById('", base.Name, "').value );\"></div>" };
                        return string.Concat(textArray3);
                    }
                }
                return "";
            }
        }

        public class StringListConverter : TypeConverter
        {
            public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                ArrayList values = null;
                foreach (object obj2 in context.Container.Components)
                {
                    if (obj2 is CustomCCSDTWorkflowBase)
                    {
                        values = new ArrayList(((CustomCCSDTWorkflowBase) obj2).CallVariableNames);
                    }
                }
                if (values == null)
                {
                    values = new ArrayList();
                }
                values.Insert(0, "{none}");
                return new TypeConverter.StandardValuesCollection(values);
            }

            public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
            {
                return true;
            }
        }
    }
}

