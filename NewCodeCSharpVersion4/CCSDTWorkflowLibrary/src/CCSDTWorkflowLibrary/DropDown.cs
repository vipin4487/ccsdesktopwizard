namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;

    [ToolboxBitmap(typeof(DropDown), "Images.DropDown.png")]
    public class DropDown : GUIElement
    {
        private string[] m_ListItems;

        [Editor("StringArrayEditor", "UITypeEditor")]
        public string[] ListItems
        {
            get
            {
                return this.m_ListItems;
            }
            set
            {
                this.m_ListItems = value;
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
                sb.Append(this.GetColumn2Tag + "<select name=\"" + base.Name + "\" ");
                sb.Append("onchange=\"stateMachine('" + base.Name + "');\" ");
                base.AddCallVarTags(sb);
                sb.Append(" class=\"" + this.GetFontClassForControl + "\"");
                sb.AppendLine(">");
                if (this.m_ListItems > null)
                {
                    foreach (string str in this.m_ListItems)
                    {
                        sb.AppendLine("<option value=\"" + str + "\">" + str + "</option>");
                    }
                }
                sb.AppendLine("</select></td>");
                sb.AppendLine("</tr>");
                return sb.ToString();
            }
        }
    }
}

