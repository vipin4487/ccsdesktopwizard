namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;

    [ToolboxBitmap(typeof(TextBox), "Images.TextBox.png")]
    public class TextBox : GUIElement
    {
        private int maximumLength = 0;
        private int columns = 0;

        [Browsable(true), DefaultValue(0), Description("Maximum length for input text (0 for no max).")]
        public int MaximumLength
        {
            get => 
                this.maximumLength;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("MaximumLength cannot be less than 0.");
                }
                this.maximumLength = value;
            }
        }

        [Browsable(true), DefaultValue(0), Description("Sets the number of columns (0 for default).")]
        public int Columns
        {
            get => 
                this.columns;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Columns cannot be less than 0.");
                }
                this.columns = value;
            }
        }

        [Browsable(true), DefaultValue(0), Category("Misc"), Description("Extra control buttons for the generated control.")]
        public override ButtonsType ButtonsForControl
        {
            get => 
                base._controlButtons;
            set => 
                base._controlButtons = value;
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
                builder.Append("<input id=" + DBHelper.AddSingleQuotes(base.Name));
                builder.Append(" class=\"" + this.GetFontClassForControl + "\"");
                if (base.ColorOfControl.ToArgb() != Color.Black.ToArgb())
                {
                    builder.Append(" style=\"background-color: " + ColorTranslator.ToHtml(base.ColorOfControl) + "; float: left;\"");
                }
                else
                {
                    builder.Append(" style=\"float: left;\"");
                }
                if ((base.SourceCallVariable != null) && (base.SourceCallVariable.Length > 0))
                {
                    builder.Append(" value=\"" + this.GetCallVarReservedWord + "\"");
                }
                else if (base.InitialValue != null)
                {
                    builder.Append(" value=\"" + base.InitialValue + "\"");
                }
                if (this.MaximumLength > 0)
                {
                    builder.Append(" maxlength=\"" + this.MaximumLength.ToString() + "\"");
                }
                if (this.Columns > 0)
                {
                    builder.Append(" size=\"" + this.Columns.ToString() + "\" ");
                }
                builder.Append(" onpaste=\"stateMachine('" + base.Name + "'); \"");
                builder.Append(" onkeyup=\"stateMachine('" + base.Name + "'); \"");
                builder.Append(" onblur=\"stateMachine('" + base.Name + "'); \"");
                builder.Append(" >");
                builder.AppendLine(this.GetButtonsHtml);
                builder.AppendLine("</td>");
                builder.AppendLine("</tr>");
                return builder.ToString();
            }
        }
    }
}

