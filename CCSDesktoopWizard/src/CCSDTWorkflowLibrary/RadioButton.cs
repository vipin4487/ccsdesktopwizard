namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;

    [ToolboxBitmap(typeof(RadioButton), "Images.RadioButton.png")]
    public class RadioButton : GUIElement
    {
        private string[] _listItems;

        public override string GetJavaScriptForValue(string callVar)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("getValueForRadioButton(\"" + base.Name + "\")");
            return builder.ToString();
        }

        [Editor("StringArrayEditor", "UITypeEditor")]
        public string[] ListItems
        {
            get => 
                this._listItems;
            set => 
                this._listItems = value;
        }

        [Browsable(false), Category("General"), Description("Gets the HTML for the control.")]
        public override string GetHtml
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(this.RowTagStart);
                sb.AppendLine(this.GetColumn1Tag);
                sb.AppendLine(this.GetColumn2Tag);
                if ((this._listItems == null) || (this._listItems.Length == 0))
                {
                    sb.Append("<input type=\"radio\" name=\"" + base.Name + "\" ");
                    base.AddCallVarTags(sb);
                    sb.Append("onclick=\"stateMachine('" + base.Name + "');\" ");
                    sb.AppendLine("<br />");
                }
                else
                {
                    foreach (string str in this._listItems)
                    {
                        sb.Append("<input type=\"radio\" name=\"" + base.Name + "\" ");
                        base.AddCallVarTags(sb);
                        sb.Append("onclick=\"stateMachine('" + base.Name + "');\" ");
                        string[] textArray1 = new string[] { "value=\"", str, "\"/>&nbsp;&nbsp;", str, "<br />" };
                        sb.AppendLine(string.Concat(textArray1));
                    }
                }
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
                return sb.ToString();
            }
        }
    }
}

