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
            get
            {
                return base._controlButtons;
            }
            set
            {
                base._controlButtons = value;
            }
        }

        [Browsable(false), Category("General"), Description("Gets the HTML for the control.")]
        public string DestinationCallVariable
        {
            get
            {
                return Convert.ToString(base.GetValue(GUIElement.DestinationCallVariableProperty));
            }
            set
            {
                base.SetValue(GUIElement.DestinationCallVariableProperty, value);
            }
        }

        [Browsable(false), Category("General"), Description("Gets the HTML for the control.")]
        public override string GetHtml
        {
            get
            {
                string str = null;
                CustomCCSDTWorkflowBase getParentWorkflow = this.GetParentWorkflow;
                if (((getParentWorkflow != null) && (base.SourceCallVariable > null)) && getParentWorkflow.CallVariableMap.ContainsKey(base.SourceCallVariable))
                {
                    str = (string) getParentWorkflow.CallVariableMap[base.SourceCallVariable];
                }
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(this.RowTagStart);
                if (((((base.SourceCallVariable != null) && (base.SourceCallVariable.Length > 0)) || ((base.InitialValue != null) && (base.InitialValue.Length > 0))) && (base.LabelText != null)) && (base.LabelText.Length > 0))
                {
                    builder.AppendLine(this.GetColumn1Tag);
                    builder.AppendLine(this.GetColumn2Tag);
                    builder.Append("<span id='" + base.Name + "'  style=\"float: none;\">");
                    if ((base.SourceCallVariable != null) && (base.SourceCallVariable.Length > 0))
                    {
                        builder.Append("<callvar, " + base.SourceCallVariable + ">");
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
                        builder.Append("<td class=\"" + this.GetClassForRow + this.GetClassForControl + " colInstructionStyle\" colspan=\"2\" align=\"center\" ><span id='" + base.Name + "' style=\"float: none;\"><callvar, " + this.GetCallVarReservedWord + "></span>");
                    }
                    else
                    {
                        builder.Append("<td class=\"" + this.GetClassForRow + this.GetClassForControl + " colInstructionStyle\" colspan=\"2\" align=\"center\"style=\"color: " + ColorTranslator.ToHtml(base.ColorOfControl) + "\"><span id='" + base.Name + "' style=\"float: none;\">" + this.GetCallVarReservedWord + "</span>");
                    }
                    builder.AppendLine(this.GetButtonsHtml);
                }
                else if ((base.InitialValue != null) && (base.InitialValue.Length > 0))
                {
                    if (base.ColorOfControl.ToArgb() == Color.Black.ToArgb())
                    {
                        builder.Append("<td class=\"" + this.GetClassForRow + this.GetClassForControl + " colInstructionStyle\" colspan=\"2\" align=\"center\"><span id='" + base.Name + "' style=\"float: none;\">" + base.InitialValue + "</span>");
                    }
                    else
                    {
                        builder.Append("<td class=\"" + this.GetClassForRow + this.GetClassForControl + " colInstructionStyle\" colspan=\"2\" align=\"center\"style=\"color: " + ColorTranslator.ToHtml(base.ColorOfControl) + "\"><span id='" + base.Name + "' style=\"float: none;\">" + base.InitialValue + "</span>");
                    }
                }
                else if (base.ColorOfLabel.ToArgb() == Color.Black.ToArgb())
                {
                    builder.Append("<td class=\"" + this.GetClassForRow + this.GetClassForLabel + " colInstructionStyle\" colspan=\"2\" align=\"center\"><span id='" + base.Name + "' style=\"float: none;\">" + base.LabelText + "</span>");
                }
                else
                {
                    builder.Append("<td class=\"" + this.GetClassForRow + this.GetClassForLabel + " colInstructionStyle\" colspan=\"2\" align=\"center\"style=\"color: " + ColorTranslator.ToHtml(base.ColorOfLabel) + "\"><span id='" + base.Name + "' style=\"float: none;\">" + base.LabelText + "</span>");
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
                switch (this.ButtonsForControl)
                {
                    case ButtonsType.CopySmall:
                    {
                        string[] textArray1 = new string[] { "<div id=\"", base.Name, "_copybutton\" class=\"copyButtonImageSmall\" title=\"Copy to clipboard\" onclick=\"window.clipboardData.setData('text', document.getElementById('", base.Name, "').innerHTML );\"></div>" };
                        return string.Concat(textArray1);
                    }
                    case ButtonsType.CopyMedium:
                    {
                        string[] textArray2 = new string[] { "<div id=\"", base.Name, "_copybutton\" class=\"copyButtonImageMedium\" title=\"Copy to clipboard\" onclick=\"window.clipboardData.setData('text', document.getElementById('", base.Name, "').innerHTML );\"></div>" };
                        return string.Concat(textArray2);
                    }
                    case ButtonsType.CopyLarge:
                    {
                        string[] textArray3 = new string[] { "<div id=\"", base.Name, "_copybutton\" class=\"copyButtonImageLarge\" title=\"Copy to clipboard\" onclick=\"window.clipboardData.setData('text', document.getElementById('", base.Name, "').innerHTML );\"></div>" };
                        return string.Concat(textArray3);
                    }
                }
                return "";
            }
        }
    }
}

