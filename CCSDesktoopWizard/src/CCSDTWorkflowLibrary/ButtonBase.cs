namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Text;

    [ToolboxBitmap(typeof(ButtonBase), "Images.ButtonBase.png")]
    public abstract class ButtonBase : ControlBase
    {
        private string _buttonText;
        private string _numberToDial;
        private bool _autoFire;
        private bool _autoClose;

        [Browsable(true), Category("Appearance"), Description("Text to display on the button.")]
        public string ButtonText
        {
            get => 
                this._buttonText;
            set => 
                this._buttonText = value;
        }

        [Browsable(true), DefaultValue(false), Category("Appearance"), Description("Button will be hidden and will fire when its parent IfElse criteria is met.")]
        public bool AutoFire
        {
            get => 
                this._autoFire;
            set => 
                this._autoFire = value;
        }

        [Browsable(true), DefaultValue(false), Category("Appearance"), Description("The form hosting the button will close when this button is clicked.")]
        public bool AutoClose
        {
            get => 
                this._autoClose;
            set => 
                this._autoClose = value;
        }

        [Browsable(false), DefaultValue(0), Category("Appearance"), Description("Alignment for the specified for this control.")]
        public AlignmentType AlignmentOfLabel { get; set; }

        [Browsable(false), DefaultValue(0), Category("Appearance"), Description("Font for the label specified for this control.")]
        public FontType FontOfLabel { get; set; }

        [Browsable(false), Category("Appearance"), Description("Font for the label specified for this control.")]
        public Color ColorOfLabel { get; set; }

        [Browsable(true), Description("Number to dial if not using routing services (VDN).")]
        public string NumberToDial
        {
            get => 
                this._numberToDial;
            set => 
                this._numberToDial = value;
        }

        [Browsable(false), Category("General"), Description("Gets the HTML for the control.")]
        public virtual string GetHtml
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                if (this.AutoFire)
                {
                    builder.AppendLine(this.RowTagStartHidden);
                }
                else
                {
                    builder.AppendLine(this.RowTagStart);
                }
                builder.Append("<td class=\"" + this.GetClassForRow + this.GetClassForControl + " col2SpanStyle\" colspan=\"2\" align=\"center\">");
                builder.Append("<input type='button' name='" + base.Name + "'");
                builder.Append(" class=\"" + this.GetFontClassForControl + "\"");
                if (base.ColorOfControl.ToArgb() != Color.Black.ToArgb())
                {
                    builder.Append(" style=\"background-color: " + ColorTranslator.ToHtml(base.ColorOfControl) + "\"");
                }
                builder.Append(" value=" + DBHelper.AddSingleQuotes(this.ButtonText) + "/></td>");
                builder.AppendLine("</tr>");
                return builder.ToString();
            }
        }
    }
}

