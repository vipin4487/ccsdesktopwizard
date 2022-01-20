namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Text;

    [ToolboxBitmap(typeof(ImageButton), "Images.Image.png")]
    public class ImageButton : ButtonBase
    {
        private string _ImageBase64;
        private int _ImageWidth = 0;
        private int _ImageHeight = 0;
        private string _UrlOnClick;

        [Editor(typeof(ImageFileEditor), typeof(UITypeEditor)), Browsable(true), Category("Image"), Description("Sets the Source for the Image.")]
        public string ImageBase64
        {
            get => 
                this._ImageBase64;
            set => 
                this._ImageBase64 = value;
        }

        [Browsable(true), Category("Image"), Description("Sets width of the image.  Set to zero for default width.")]
        public int ImageWidth
        {
            get => 
                this._ImageWidth;
            set => 
                this._ImageWidth = value;
        }

        [Browsable(true), Category("Image"), Description("Sets height of the image.  Set to zero for default height.")]
        public int ImageHeight
        {
            get => 
                this._ImageHeight;
            set => 
                this._ImageHeight = value;
        }

        [Browsable(true), Category("Image"), Description("URL to navigate to on clicking image.")]
        public string UrlOnClick
        {
            get => 
                this._UrlOnClick;
            set => 
                this._UrlOnClick = value;
        }

        [Browsable(false), Category("Appearance"), Description("Text to display on the button.")]
        public string ButtonText
        {
            get => 
                base.ButtonText;
            set => 
                base.ButtonText = value;
        }

        [Browsable(false), DefaultValue(false), Category("Appearance"), Description("Button will be hidden and will fire when its parent IfElse criteria is met.")]
        public bool AutoFire
        {
            get => 
                base.AutoFire;
            set => 
                base.AutoFire = value;
        }

        [Browsable(false), DefaultValue(false), Category("Appearance"), Description("The form hosting the button will close when this button is clicked.")]
        public bool AutoClose
        {
            get => 
                base.AutoClose;
            set => 
                base.AutoClose = value;
        }

        [Browsable(false), Description("Number to dial if not using routing services (VDN).")]
        public string NumberToDial
        {
            get => 
                base.NumberToDial;
            set => 
                base.NumberToDial = value;
        }

        [Browsable(false), Category("General"), Description("Gets the HTML for the control.")]
        public override string GetHtml
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(this.RowTagStart);
                builder.Append("<td class=\"" + this.GetClassForRow + this.GetClassForControl + "\"  col2SpanStyle\" colspan=\"2\" align=\"center\">");
                builder.Append("<img src='data:image/png;base64," + this.ImageBase64 + "'");
                if (this.ImageHeight > 0)
                {
                    builder.Append(" height=" + DBHelper.AddSingleQuotes(this.ImageHeight.ToString()));
                }
                if (this.ImageWidth > 0)
                {
                    builder.Append(" width=" + DBHelper.AddSingleQuotes(this.ImageWidth.ToString()));
                }
                if ((base.Description != null) && (base.Description.Length > 0))
                {
                    builder.Append(" alt=" + DBHelper.AddSingleQuotes(base.Description));
                }
                if ((this.UrlOnClick != null) && (this.UrlOnClick.Length > 0))
                {
                    string[] textArray1 = new string[] { " onclick=\"window.open(", DBHelper.AddSingleQuotes(this.UrlOnClick), ", ", DBHelper.AddSingleQuotes("_blank"), ");\"" };
                    builder.Append(string.Concat(textArray1));
                }
                builder.Append(" />");
                builder.AppendLine("</td>");
                builder.AppendLine("</tr>");
                return builder.ToString();
            }
        }
    }
}

