namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Text;

    [ToolboxBitmap(typeof(HiddenTextBox), "Images.HiddenTextBox.png")]
    public class HiddenTextBox : GUIElement
    {
        [Browsable(false), Category("Appearance"), Description("Label to display before the control.")]
        public string LabelText =>
            null;

        [Browsable(false), DefaultValue(0), Category("Appearance"), Description("Alignment for the specified for this control.")]
        public AlignmentType AlignmentOfLabel { get; set; }

        [Browsable(false), DefaultValue(0), Category("Appearance"), Description("Font for the label specified for this control.")]
        public FontType FontOfLabel { get; set; }

        [Browsable(false), DefaultValue(0), Category("Appearance"), Description("Font for the label specified for this control.")]
        public FontType FontOfControl { get; set; }

        [Browsable(false), Category("Appearance"), Description("Font for the label specified for this control.")]
        public Color ColorOfLabel { get; set; }

        [Browsable(false), Category("Appearance"), Description("Font for the label specified for this control.")]
        public Color ColorOfControl { get; set; }

        [Browsable(false), Category("General"), Description("Gets the HTML for the control.")]
        public override string GetHtml
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(this.RowTagStartHidden);
                builder.AppendLine(this.GetColumn1Tag);
                builder.AppendLine(this.GetColumn2Tag);
                builder.Append("<input id=" + DBHelper.AddSingleQuotes(base.Name));
                if ((base.SourceCallVariable != null) && (base.SourceCallVariable.Length > 0))
                {
                    builder.Append(" value=\"<callvar, " + base.SourceCallVariable + ">\"");
                }
                else if (base.InitialValue != null)
                {
                    builder.Append(" value=\"" + base.InitialValue + "\"");
                }
                builder.Append(" type='hidden' ");
                builder.AppendLine(" ></td>");
                builder.AppendLine("</tr>");
                return builder.ToString();
            }
        }
    }
}

