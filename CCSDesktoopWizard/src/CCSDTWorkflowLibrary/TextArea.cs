namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;

    [ToolboxBitmap(typeof(TextArea), "Images.TextArea.png")]
    public class TextArea : TextBox
    {
        private int _Rows = 5;

        [Browsable(true), Description("Sets the number of rows.")]
        public int Rows
        {
            get => 
                this._Rows;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Rows cannot be less than 1.");
                }
                this._Rows = value;
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
                builder.Append("<textarea name=" + DBHelper.AddSingleQuotes(base.Name));
                builder.Append(" class=\"" + this.GetFontClassForControl + "\"");
                if (base.ColorOfControl.ToArgb() != Color.Black.ToArgb())
                {
                    builder.Append(" style=\"background-color: " + ColorTranslator.ToHtml(base.ColorOfControl) + "; float: left;\"");
                }
                else
                {
                    builder.Append(" style=\"float: left;\"");
                }
                builder.Append(" rows=\"" + this.Rows + "\" ");
                if (base.Columns > 0)
                {
                    builder.Append(" cols=\"" + base.Columns + "\" ");
                }
                if (base.MaximumLength > 0)
                {
                    builder.Append(" maxlength=\"" + base.MaximumLength.ToString() + "\"");
                }
                builder.Append(" onpaste=\"stateMachine('" + base.Name + "'); \"");
                builder.Append(" onkeyup=\"stateMachine('" + base.Name + "'); \"");
                builder.Append(" onblur=\"stateMachine('" + base.Name + "'); \"");
                builder.AppendLine(" >");
                if ((base.SourceCallVariable != null) && (base.SourceCallVariable.Length > 0))
                {
                    builder.Append(this.GetCallVarReservedWord);
                }
                builder.AppendLine("</textarea>");
                builder.AppendLine(this.GetButtonsHtml);
                builder.AppendLine("</td>");
                builder.AppendLine("</tr>");
                return builder.ToString();
            }
        }
    }
}

