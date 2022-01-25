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
            get
            {
                return this._listItems;
            }
            set
            {
                this._listItems = value;
            }
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
                if ((this._listItems != null) && (this._listItems.Length != 0))
                {
                    foreach (string str in this._listItems)
                    {
                        sb.Append("<input type=\"radio\" name=\"" + base.Name + "\" ");
                        base.AddCallVarTags(sb);
                        sb.Append("onclick=\"stateMachine('" + base.Name + "');\" ");
                        sb.AppendLine("value=\"" + str + "\"/>&nbsp;&nbsp;" + str + "<br />");
                    }
                }
                else
                {
                    sb.Append("<input type=\"radio\" name=\"" + base.Name + "\" ");
                    base.AddCallVarTags(sb);
                    sb.Append("onclick=\"stateMachine('" + base.Name + "');\" ");
                    sb.AppendLine("<br />");
                }
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
                return sb.ToString();
            }
        }
    }
}

