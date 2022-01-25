namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;

    [ToolboxBitmap(typeof(Calendar), "Images.Calendar.png")]
    public class Calendar : GUIElement
    {
        public override string GetJavaScriptForValue(string callVar)
        {
            return string.Empty;
        }

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
        public override string GetHtml
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(this.RowTagStart);
                builder.AppendLine(this.GetColumn1Tag);
                builder.AppendLine(this.GetColumn2Tag);
                builder.AppendLine("<span style=\"float: left;\">");
                builder.Append("<input id='" + base.Name + "_month'");
                if ((base.SourceCallVariable != null) && (base.SourceCallVariable.Length > 0))
                {
                    builder.Append(" value=\"<callvarmonth, " + base.SourceCallVariable + ">\" ");
                }
                builder.Append(" size=\"1\" maxlength=\"2\"");
                builder.Append(" onpaste=\"stateMachine('" + base.Name + "_month'); \"");
                builder.Append(" onkeyup=\"stateMachine('" + base.Name + "_month'); \"");
                builder.Append(" >");
                builder.Append("/");
                builder.Append("<input id='" + base.Name + "_day'");
                if ((base.SourceCallVariable != null) && (base.SourceCallVariable.Length > 0))
                {
                    builder.Append(" value=\"<callvarday, " + base.SourceCallVariable + ">\" ");
                }
                builder.Append(" size=\"1\" maxlength=\"2\"");
                builder.Append(" onpaste=\"stateMachine('" + base.Name + "_day'); \"");
                builder.Append(" onkeyup=\"stateMachine('" + base.Name + "_day'); \"");
                builder.Append(" >");
                builder.Append("/");
                builder.Append("<input id='" + base.Name + "_year'");
                if ((base.SourceCallVariable != null) && (base.SourceCallVariable.Length > 0))
                {
                    builder.Append(" value=\"<callvaryear, " + base.SourceCallVariable + ">\" ");
                }
                builder.Append(" size=\"2\" maxlength=\"4\"");
                builder.Append(" onpaste=\"stateMachine('" + base.Name + "_year'); \"");
                builder.Append(" onkeyup=\"stateMachine('" + base.Name + "_year'); \"");
                builder.Append(" >");
                builder.AppendLine("</span>");
                builder.AppendLine(this.GetButtonsHtml);
                builder.AppendLine("</td>");
                builder.AppendLine("</tr>");
                if (((base.SourceCallVariable == null) || (base.SourceCallVariable.Length == 0)) && ((base.InitialValue != null) && (base.InitialValue.Length > 0)))
                {
                    builder.AppendLine("<script type=\"text/javascript\" language=javascript> ");
                    builder.AppendLine("  var dateValue = \"" + base.InitialValue + "\";");
                    builder.AppendLine("  if (dateValue.length > 7 && dateValue != \"99991231\" && dateValue != \"12319999\") {");
                    builder.AppendLine("    var control = document.getElementById(\"" + base.Name + "_month\");");
                    builder.AppendLine("    if (control) {");
                    builder.AppendLine("       control.value = dateValue.substring(0,2);");
                    builder.AppendLine("    }");
                    builder.AppendLine("    control = document.getElementById(\"" + base.Name + "_day\");");
                    builder.AppendLine("    if (control) {");
                    builder.AppendLine("       control.value = dateValue.substring(2,4);");
                    builder.AppendLine("    }");
                    builder.AppendLine("    control = document.getElementById(\"" + base.Name + "_year\");");
                    builder.AppendLine("    if (control) {");
                    builder.AppendLine("       control.value = dateValue.substring(4,8);");
                    builder.AppendLine("    }");
                    builder.AppendLine("  }");
                    builder.AppendLine("</script> ");
                }
                return builder.ToString();
            }
        }

        [Browsable(false), Category("General"), Description("HTML for extra control buttons if selected.")]
        public override string GetButtonsHtml
        {
            get
            {
                string str = "";
                switch (this.ButtonsForControl)
                {
                    case ButtonsType.CopySmall:
                        str = "<div id=\"" + base.Name + "_copybutton\" class=\"copyButtonImageSmall\" title=\"Copy to clipboard\"";
                        break;

                    case ButtonsType.CopyMedium:
                        str = "<div id=\"" + base.Name + "_copybutton\" class=\"copyButtonImageMedium\" title=\"Copy to clipboard\"";
                        break;

                    case ButtonsType.CopyLarge:
                        str = "<div id=\"" + base.Name + "_copybutton\" class=\"copyButtonImageLarge\" title=\"Copy to clipboard\"";
                        break;

                    default:
                        return "";
                }
                return ((((str + " onclick=\"var fullDateString = document.getElementById('" + base.Name + "_month').value") + " + '/' + document.getElementById('" + base.Name + "_day').value") + " + '/' + document.getElementById('" + base.Name + "_year').value;") + " window.clipboardData.setData('text', fullDateString);" + "\"></div>");
            }
        }
    }
}

