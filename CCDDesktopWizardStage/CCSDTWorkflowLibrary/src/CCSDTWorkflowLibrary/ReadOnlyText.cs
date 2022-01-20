namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;

    [ToolboxBitmap(typeof(ReadOnlyText), "Images.StaticText.png")]
    public class ReadOnlyText : GUIElement
    {
        [Browsable(true), DefaultValue(0), Category("Misc"), Description("Extra control buttons for the generated control.")]
        public override ButtonsType ButtonsForControl
        {
            get => 
                base._controlButtons;
            set => 
                base._controlButtons = value;
        }

        [Browsable(false), Category("General"), Description("Gets the HTML for the control.")]
        public string DestinationCallVariable
        {
            get => 
                Convert.ToString(base.GetValue(GUIElement.DestinationCallVariableProperty));
            set => 
                base.SetValue(GUIElement.DestinationCallVariableProperty, value);
        }

        [Browsable(false), Category("General"), Description("Gets the HTML for the control.")]
        public override string GetHtml
        {
            get
            {
                string str = null;
                bool flag1;
                CustomCCSDTWorkflowBase getParentWorkflow = this.GetParentWorkflow;
                if (((getParentWorkflow != null) && (base.SourceCallVariable != null)) && getParentWorkflow.CallVariableMap.ContainsKey(base.SourceCallVariable))
                {
                    str = (string) getParentWorkflow.CallVariableMap[base.SourceCallVariable];
                }
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(this.RowTagStart);
                if ((((base.SourceCallVariable == null) || (base.SourceCallVariable.Length <= 0)) && ((base.InitialValue == null) || (base.InitialValue.Length <= 0))) || (base.LabelText == null))
                {
                    flag1 = false;
                }
                else
                {
                    flag1 = base.LabelText.Length > 0;
                }
                if (flag1)
                {
                    builder.AppendLine(this.GetColumn1Tag);
                    builder.AppendLine(this.GetColumn2Tag);
                    builder.Append("<span id='" + base.Name + "'  style=\"float: none;\">");
                    if ((base.SourceCallVariable != null) && (base.SourceCallVariable.Length > 0))
                    {
                        builder.Append(this.GetCallVarReservedWord);
                    }
                    else
                    {
                        builder.Append(base.InitialValue);
                    }
                    builder.Append("</span>");
                    builder.AppendLine(this.GetButtonsHtml);
                }
                else if ((base.SourceCallVariable != null) && (base.SourceCallVariable.Length > 0))
                {
                    if (base.ColorOfControl.ToArgb() == Color.Black.ToArgb())
                    {
                        string[] textArray1 = new string[] { "<td class=\"", this.GetClassForRow, this.GetClassForControl, " colInstructionStyle\" colspan=\"2\" align=\"center\" ><span id='", base.Name, "' style=\"float: none;\">", this.GetCallVarReservedWord, "</span>" };
                        builder.Append(string.Concat(textArray1));
                    }
                    else
                    {
                        string[] textArray2 = new string[10];
                        textArray2[0] = "<td class=\"";
                        textArray2[1] = this.GetClassForRow;
                        textArray2[2] = this.GetClassForControl;
                        textArray2[3] = " colInstructionStyle\" colspan=\"2\" align=\"center\"style=\"color: ";
                        textArray2[4] = ColorTranslator.ToHtml(base.ColorOfControl);
                        textArray2[5] = "\"><span id='";
                        textArray2[6] = base.Name;
                        textArray2[7] = "' style=\"float: none;\">";
                        textArray2[8] = this.GetCallVarReservedWord;
                        textArray2[9] = "</span>";
                        builder.Append(string.Concat(textArray2));
                    }
                    builder.AppendLine(this.GetButtonsHtml);
                }
                else if ((base.InitialValue != null) && (base.InitialValue.Length > 0))
                {
                    if (base.ColorOfControl.ToArgb() == Color.Black.ToArgb())
                    {
                        string[] textArray3 = new string[] { "<td class=\"", this.GetClassForRow, this.GetClassForControl, " colInstructionStyle\" colspan=\"2\" align=\"center\"><span id='", base.Name, "' style=\"float: none;\">", base.InitialValue, "</span>" };
                        builder.Append(string.Concat(textArray3));
                    }
                    else
                    {
                        string[] textArray4 = new string[10];
                        textArray4[0] = "<td class=\"";
                        textArray4[1] = this.GetClassForRow;
                        textArray4[2] = this.GetClassForControl;
                        textArray4[3] = " colInstructionStyle\" colspan=\"2\" align=\"center\"style=\"color: ";
                        textArray4[4] = ColorTranslator.ToHtml(base.ColorOfControl);
                        textArray4[5] = "\"><span id='";
                        textArray4[6] = base.Name;
                        textArray4[7] = "' style=\"float: none;\">";
                        textArray4[8] = base.InitialValue;
                        textArray4[9] = "</span>";
                        builder.Append(string.Concat(textArray4));
                    }
                }
                else if (base.ColorOfLabel.ToArgb() == Color.Black.ToArgb())
                {
                    string[] textArray5 = new string[] { "<td class=\"", this.GetClassForRow, this.GetClassForLabel, " colInstructionStyle\" colspan=\"2\" align=\"center\"><span id='", base.Name, "' style=\"float: none;\">", base.LabelText, "</span>" };
                    builder.Append(string.Concat(textArray5));
                }
                else
                {
                    string[] textArray6 = new string[10];
                    textArray6[0] = "<td class=\"";
                    textArray6[1] = this.GetClassForRow;
                    textArray6[2] = this.GetClassForLabel;
                    textArray6[3] = " colInstructionStyle\" colspan=\"2\" align=\"center\"style=\"color: ";
                    textArray6[4] = ColorTranslator.ToHtml(base.ColorOfLabel);
                    textArray6[5] = "\"><span id='";
                    textArray6[6] = base.Name;
                    textArray6[7] = "' style=\"float: none;\">";
                    textArray6[8] = base.LabelText;
                    textArray6[9] = "</span>";
                    builder.Append(string.Concat(textArray6));
                }
                builder.AppendLine("</td>");
                builder.AppendLine("</tr>");
                return builder.ToString();
            }
        }

        [Browsable(false), Category("General"), Description("HTML for extra control buttons if selected.")]
        public override string GetButtonsHtml
        {
            get
            {
                string str;
                switch (this.ButtonsForControl)
                {
                    case ButtonsType.CopySmall:
                    {
                        string[] textArray1 = new string[] { "<div id=\"", base.Name, "_copybutton\" class=\"copyButtonImageSmall\" title=\"Copy to clipboard\" onclick=\"window.clipboardData.setData('text', document.getElementById('", base.Name, "').innerHTML );\"></div>" };
                        str = string.Concat(textArray1);
                        break;
                    }
                    case ButtonsType.CopyMedium:
                    {
                        string[] textArray2 = new string[] { "<div id=\"", base.Name, "_copybutton\" class=\"copyButtonImageMedium\" title=\"Copy to clipboard\" onclick=\"window.clipboardData.setData('text', document.getElementById('", base.Name, "').innerHTML );\"></div>" };
                        str = string.Concat(textArray2);
                        break;
                    }
                    case ButtonsType.CopyLarge:
                    {
                        string[] textArray3 = new string[] { "<div id=\"", base.Name, "_copybutton\" class=\"copyButtonImageLarge\" title=\"Copy to clipboard\" onclick=\"window.clipboardData.setData('text', document.getElementById('", base.Name, "').innerHTML );\"></div>" };
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
    }
}

