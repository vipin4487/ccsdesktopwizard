namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Workflow.ComponentModel;

    public abstract class ControlBase : Activity
    {
        private DecorationType _decoration;
        private AlignmentType _alignmentLabel;
        private AlignmentType _alignmentControl;
        private FontType _fontLabel;
        private FontType _fontControl;
        private Color _colorLabel = Color.Black;
        private Color _colorControl = Color.Black;
        private Color _colorBackground = Color.White;
        private Color _colorLabelBackground = Color.White;
        private Color _colorControlBackground = Color.White;
        private MinHeightType _minRowHeight;

        [Browsable(true), Category("General"), Description("Name of the control.")]
        public string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
            }
        }

        [Browsable(true), Category("General"), Description("Description for internal use.")]
        public string Description
        {
            get
            {
                return base.Description;
            }
            set
            {
                base.Description = value;
            }
        }

        [Browsable(true), Category("General"), Description("Enable/disable the control.")]
        public bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
                base.Enabled = value;
            }
        }

        [Browsable(true), DefaultValue(0), Category("Appearance"), Description("Alignment for the specified for this control.")]
        public AlignmentType AlignmentOfLabel
        {
            get
            {
                return this._alignmentLabel;
            }
            set
            {
                this._alignmentLabel = value;
            }
        }

        [Browsable(true), DefaultValue(0), Category("Appearance"), Description("Alignment for the generated control.")]
        public AlignmentType AlignmentOfControl
        {
            get
            {
                return this._alignmentControl;
            }
            set
            {
                this._alignmentControl = value;
            }
        }

        [Browsable(true), DefaultValue(0), Category("Appearance"), Description("Decoration for the row containing the control.")]
        public DecorationType Decoration
        {
            get
            {
                return this._decoration;
            }
            set
            {
                this._decoration = value;
            }
        }

        [Browsable(true), DefaultValue(0), Category("Appearance"), Description("Font for the label specified for this control.")]
        public FontType FontOfLabel
        {
            get
            {
                return this._fontLabel;
            }
            set
            {
                this._fontLabel = value;
            }
        }

        [Browsable(true), Category("Appearance"), Description("Color for the label specified for this control.")]
        public Color ColorOfLabel
        {
            get
            {
                return this._colorLabel;
            }
            set
            {
                this._colorLabel = value;
            }
        }

        [Browsable(true), DefaultValue(0), Category("Appearance"), Description("Font for the generated control text.")]
        public FontType FontOfControl
        {
            get
            {
                return this._fontControl;
            }
            set
            {
                this._fontControl = value;
            }
        }

        [Browsable(true), Category("Appearance"), Description("Color for the generated control text.")]
        public Color ColorOfControl
        {
            get
            {
                return this._colorControl;
            }
            set
            {
                this._colorControl = value;
            }
        }

        [Browsable(true), Category("Appearance"), Description("Color of the background for the row.")]
        public Color ColorOfBackground
        {
            get
            {
                return this._colorBackground;
            }
            set
            {
                this._colorBackground = value;
            }
        }

        [Browsable(true), Category("Appearance"), Description("Color of the Label background for the row.")]
        public Color BackgroundColorOfLabel
        {
            get
            {
                return this._colorLabelBackground;
            }
            set
            {
                this._colorLabelBackground = value;
            }
        }

        [Browsable(true), Category("Appearance"), Description("Color of the Control background for the row.")]
        public Color BackgroundColorOfControl
        {
            get
            {
                return this._colorControlBackground;
            }
            set
            {
                this._colorControlBackground = value;
            }
        }

        [Browsable(true), DefaultValue(0), Category("Appearance"), Description("Minimum height for the row.")]
        public MinHeightType MinRowHeight
        {
            get
            {
                return this._minRowHeight;
            }
            set
            {
                this._minRowHeight = value;
            }
        }

        [Browsable(false), Category("General"), Description("Id for the row (TD) that hosts this control.")]
        public virtual string RowIdentifier
        {
            get
            {
                return (this.Name + "_Row");
            }
        }

        [Browsable(false), Category("General"), Description("TR tag for row hosting this control.")]
        public virtual string RowTagStart
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("<tr ");
                builder.Append("id='" + this.RowIdentifier + "'");
                if (this.ColorOfBackground != Color.White)
                {
                    builder.Append(" bgcolor='" + ColorTranslator.ToHtml(this.ColorOfBackground) + "'");
                }
                builder.Append(">");
                return builder.ToString();
            }
        }

        [Browsable(false), Category("General"), Description("TR tag for row hosting this control.")]
        public virtual string RowTagStartHidden
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("<tr ");
                builder.Append("style='display: none' id='" + this.RowIdentifier + "'");
                if (this.ColorOfBackground != Color.White)
                {
                    builder.Append(" bgcolor='" + ColorTranslator.ToHtml(this.ColorOfBackground) + "'");
                }
                builder.Append(">");
                return builder.ToString();
            }
        }

        [Browsable(false), Category("General"), Description("Class for entire row hosting this control (can't put it on the TR tag).")]
        public virtual string GetClassForRow
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                switch (this.Decoration)
                {
                    case DecorationType.None:
                        builder.Append("rowNormalStyle");
                        break;

                    case DecorationType.ThinLineAbove:
                        builder.Append("rowUpperlineStyle");
                        break;

                    case DecorationType.ThinLineBelow:
                        builder.Append("rowUnderlineStyle");
                        break;
                }
                switch (this.MinRowHeight)
                {
                    case MinHeightType.Default:
                    {
                        if (!(this is ReadOnlyText))
                        {
                            if (this is Hyperlink)
                            {
                                builder.Append(" rowHeightOther");
                            }
                            else if (this is GUIElement)
                            {
                                builder.Append(" rowHeightDefault");
                            }
                            else if (this is ButtonBase)
                            {
                                builder.Append(" rowHeightOther");
                            }
                            break;
                        }
                        ReadOnlyText text = (ReadOnlyText) this;
                        if (((((text.SourceCallVariable == null) || (text.SourceCallVariable.Length <= 0)) && ((text.InitialValue == null) || (text.InitialValue.Length <= 0))) || (text.LabelText == null)) || (text.LabelText.Length <= 0))
                        {
                            builder.Append(" rowHeightOther");
                            break;
                        }
                        builder.Append(" rowHeightDefault");
                        break;
                    }
                    case MinHeightType.Height_5px:
                        builder.Append(" rowHeight5px");
                        break;

                    case MinHeightType.Height_10px:
                        builder.Append(" rowHeight10px");
                        break;

                    case MinHeightType.Height_15px:
                        builder.Append(" rowHeight15px");
                        break;

                    case MinHeightType.Height_20px:
                        builder.Append(" rowHeight20px");
                        break;

                    case MinHeightType.Height_25px:
                        builder.Append(" rowHeight25px");
                        break;

                    case MinHeightType.Height_30px:
                        builder.Append(" rowHeight30px");
                        break;

                    case MinHeightType.Height_35px:
                        builder.Append(" rowHeight35px");
                        break;

                    case MinHeightType.Height_40px:
                        builder.Append(" rowHeight40px");
                        break;

                    case MinHeightType.Height_45px:
                        builder.Append(" rowHeight45px");
                        break;

                    case MinHeightType.Height_50px:
                        builder.Append(" rowHeight50px");
                        break;
                }
                return builder.ToString();
            }
        }

        [Browsable(false), Category("General"), Description("Class for column 1 hosting this control (overrides the default style).")]
        public virtual string GetClassForLabel
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                switch (this.AlignmentOfLabel)
                {
                    case AlignmentType.Left:
                        builder.Append(" cellAlignLeft");
                        break;

                    case AlignmentType.Right:
                        builder.Append(" cellAlignRight");
                        break;

                    case AlignmentType.Center:
                        builder.Append(" cellAlignCenter");
                        break;
                }
                switch (this.FontOfLabel)
                {
                    case FontType.Arial_12px:
                        builder.Append(" cellFontArial12px");
                        break;

                    case FontType.Arial_14px:
                        builder.Append(" cellFontArial14px");
                        break;

                    case FontType.Arial_16px:
                        builder.Append(" cellFontArial16px");
                        break;

                    case FontType.Arial_20px:
                        builder.Append(" cellFontArial20px");
                        break;

                    case FontType.Arial_24px:
                        builder.Append(" cellFontArial24px");
                        break;

                    case FontType.Arial_30px:
                        builder.Append(" cellFontArial30px");
                        break;

                    case FontType.ArialBold_12px:
                        builder.Append(" cellFontArialBold12px");
                        break;

                    case FontType.ArialBold_14px:
                        builder.Append(" cellFontArialBold14px");
                        break;

                    case FontType.ArialBold_16px:
                        builder.Append(" cellFontArialBold16px");
                        break;

                    case FontType.ArialBold_20px:
                        builder.Append(" cellFontArialBold20px");
                        break;

                    case FontType.ArialBold_24px:
                        builder.Append(" cellFontArialBold24px");
                        break;

                    case FontType.ArialBold_30px:
                        builder.Append(" cellFontArialBold30px");
                        break;
                }
                return builder.ToString();
            }
        }

        [Browsable(false), Category("General"), Description("Class for column 2 hosting this control (overrides the default style).")]
        public virtual string GetClassForControl
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                switch (this.AlignmentOfControl)
                {
                    case AlignmentType.Left:
                        builder.Append(" cellAlignLeft");
                        break;

                    case AlignmentType.Right:
                        builder.Append(" cellAlignRight");
                        break;

                    case AlignmentType.Center:
                        builder.Append(" cellAlignCenter");
                        break;
                }
                builder.Append(this.GetFontClassForControl);
                return builder.ToString();
            }
        }

        [Browsable(false), Category("General"), Description("Font calls for column 2 hosting this control (overrides the default style).")]
        public virtual string GetFontClassForControl
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                switch (this.FontOfControl)
                {
                    case FontType.Arial_12px:
                        builder.Append(" cellFontArial12px");
                        break;

                    case FontType.Arial_14px:
                        builder.Append(" cellFontArial14px");
                        break;

                    case FontType.Arial_16px:
                        builder.Append(" cellFontArial16px");
                        break;

                    case FontType.Arial_20px:
                        builder.Append(" cellFontArial20px");
                        break;

                    case FontType.Arial_24px:
                        builder.Append(" cellFontArial24px");
                        break;

                    case FontType.Arial_30px:
                        builder.Append(" cellFontArial30px");
                        break;

                    case FontType.ArialBold_12px:
                        builder.Append(" cellFontArialBold12px");
                        break;

                    case FontType.ArialBold_14px:
                        builder.Append(" cellFontArialBold14px");
                        break;

                    case FontType.ArialBold_16px:
                        builder.Append(" cellFontArialBold16px");
                        break;

                    case FontType.ArialBold_20px:
                        builder.Append(" cellFontArialBold20px");
                        break;

                    case FontType.ArialBold_24px:
                        builder.Append(" cellFontArialBold24px");
                        break;

                    case FontType.ArialBold_30px:
                        builder.Append(" cellFontArialBold30px");
                        break;
                }
                return builder.ToString();
            }
        }

        [Browsable(false), Category("General"), Description("Parent workflow for this control.")]
        public virtual CustomCCSDTWorkflowBase GetParentWorkflow
        {
            get
            {
                Activity parent = base.Parent;
                while ((parent != null) && !(parent is CustomCCSDTWorkflowBase))
                {
                    parent = parent.Parent;
                }
                if (parent is CustomCCSDTWorkflowBase)
                {
                    return (CustomCCSDTWorkflowBase) parent;
                }
                return null;
            }
        }
    }
}

