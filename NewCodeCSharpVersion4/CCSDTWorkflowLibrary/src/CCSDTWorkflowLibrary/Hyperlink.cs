namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Text.RegularExpressions;

    [ToolboxBitmap(typeof(Hyperlink), "Images.HyperLink.png")]
    public class Hyperlink : GUIElement
    {
        private string _URL;

        [Browsable(true), Category("General"), Description("Sets the URL for the hyperlink.")]
        public string URL
        {
            get
            {
                return this._URL;
            }
            set
            {
                if (!Regex.IsMatch(value, @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\=\.\?\,'\/\\+&amp;%\$#_]*)?$"))
                {
                    throw new ArgumentException("Invalid URL");
                }
                this._URL = value;
            }
        }

        [Browsable(false), Category("General"), Description("Gets the HTML for the control.")]
        public override string GetHtml
        {
            get
            {
                string uRL = string.Empty;
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(this.RowTagStart);
                builder.Append("<td class=\"" + this.GetClassForRow + this.GetClassForControl + "\" col2SpanStyle\" colspan=\"2\" align=\"center\">");
                if (string.IsNullOrEmpty(base.LabelText))
                {
                    uRL = this.URL;
                }
                else
                {
                    uRL = base.LabelText;
                }
                builder.Append("<a href=" + DBHelper.AddSingleQuotes(this.URL) + " target='_blank'>" + uRL + "</a>");
                builder.AppendLine("</td>");
                builder.AppendLine("</tr>");
                return builder.ToString();
            }
        }
    }
}

