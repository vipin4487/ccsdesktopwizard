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
            get => 
                this._URL;
            set
            {
                if (!Regex.IsMatch(value, @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\=\.\?\,'\/\\+&amp;%\$#_<>]*)?$"))
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
                string str = string.Empty;
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(this.RowTagStart);
                builder.Append("<td class=\"" + this.GetClassForRow + this.GetClassForControl + "\" col2SpanStyle\" colspan=\"2\" align=\"center\">");
                str = !string.IsNullOrEmpty(base.LabelText) ? base.LabelText : this.URL;
                string[] textArray1 = new string[] { "<a href=", DBHelper.AddSingleQuotes(this.URL), " target='_blank'>", str, "</a>" };
                builder.Append(string.Concat(textArray1));
                builder.AppendLine("</td>");
                builder.AppendLine("</tr>");
                return builder.ToString();
            }
        }
    }
}

