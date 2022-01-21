namespace CCSDTWorkflowWizard
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    internal class AboutBox : Form
    {
        private IContainer components = null;
        private TableLayoutPanel tableLayoutPanel;
        private PictureBox logoPictureBox;
        private Label labelProductName;
        private Label labelVersion;
        private Label labelCopyright;
        private Label labelCompanyName;
        private TextBox textBoxDescription;
        private Button okButton;

        public AboutBox()
        {
            this.InitializeComponent();
            this.Text = $"About {this.AssemblyTitle}";
            this.labelProductName.Text = this.AssemblyProduct;
            this.labelVersion.Text = $"Version {this.AssemblyVersion}";
            this.labelCopyright.Text = this.AssemblyCopyright;
            this.labelCompanyName.Text = this.AssemblyCompany;
            this.textBoxDescription.Text = this.AssemblyDescription;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components > null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(AboutBox));
            this.tableLayoutPanel = new TableLayoutPanel();
            this.logoPictureBox = new PictureBox();
            this.labelProductName = new Label();
            this.labelVersion = new Label();
            this.labelCopyright = new Label();
            this.labelCompanyName = new Label();
            this.textBoxDescription = new TextBox();
            this.okButton = new Button();
            this.tableLayoutPanel.SuspendLayout();
            ((ISupportInitialize) this.logoPictureBox).BeginInit();
            base.SuspendLayout();
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
            this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67f));
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.okButton, 1, 5);
            this.tableLayoutPanel.Dock = DockStyle.Fill;
            this.tableLayoutPanel.Location = new Point(14, 14);
            this.tableLayoutPanel.Margin = new Padding(4, 5, 4, 5);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
            this.tableLayoutPanel.Size = new Size(0x270, 0x197);
            this.tableLayoutPanel.TabIndex = 0;
            this.logoPictureBox.Dock = DockStyle.Fill;
            this.logoPictureBox.Image = (Image) manager.GetObject("logoPictureBox.Image");
            this.logoPictureBox.Location = new Point(4, 5);
            this.logoPictureBox.Margin = new Padding(4, 5, 4, 5);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
            this.logoPictureBox.Size = new Size(0xc5, 0x18d);
            this.logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            this.labelProductName.Dock = DockStyle.Fill;
            this.labelProductName.Location = new Point(0xd6, 0);
            this.labelProductName.Margin = new Padding(9, 0, 4, 0);
            this.labelProductName.MaximumSize = new Size(0, 0x1a);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new Size(0x196, 0x1a);
            this.labelProductName.TabIndex = 0x13;
            this.labelProductName.Text = "Product Name";
            this.labelProductName.TextAlign = ContentAlignment.MiddleLeft;
            this.labelVersion.Dock = DockStyle.Fill;
            this.labelVersion.Location = new Point(0xd6, 40);
            this.labelVersion.Margin = new Padding(9, 0, 4, 0);
            this.labelVersion.MaximumSize = new Size(0, 0x1a);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new Size(0x196, 0x1a);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = ContentAlignment.MiddleLeft;
            this.labelCopyright.Dock = DockStyle.Fill;
            this.labelCopyright.Location = new Point(0xd6, 80);
            this.labelCopyright.Margin = new Padding(9, 0, 4, 0);
            this.labelCopyright.MaximumSize = new Size(0, 0x1a);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new Size(0x196, 0x1a);
            this.labelCopyright.TabIndex = 0x15;
            this.labelCopyright.Text = "Copyright";
            this.labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
            this.labelCompanyName.Dock = DockStyle.Fill;
            this.labelCompanyName.Location = new Point(0xd6, 120);
            this.labelCompanyName.Margin = new Padding(9, 0, 4, 0);
            this.labelCompanyName.MaximumSize = new Size(0, 0x1a);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new Size(0x196, 0x1a);
            this.labelCompanyName.TabIndex = 0x16;
            this.labelCompanyName.Text = "Company Name";
            this.labelCompanyName.TextAlign = ContentAlignment.MiddleLeft;
            this.textBoxDescription.Dock = DockStyle.Fill;
            this.textBoxDescription.Location = new Point(0xd6, 0xa5);
            this.textBoxDescription.Margin = new Padding(9, 5, 4, 5);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = ScrollBars.Both;
            this.textBoxDescription.Size = new Size(0x196, 0xc1);
            this.textBoxDescription.TabIndex = 0x17;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = "Description";
            this.okButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.okButton.DialogResult = DialogResult.Cancel;
            this.okButton.Location = new Point(0x1fc, 0x170);
            this.okButton.Margin = new Padding(4, 5, 4, 5);
            this.okButton.Name = "okButton";
            this.okButton.Size = new Size(0x70, 0x22);
            this.okButton.TabIndex = 0x18;
            this.okButton.Text = "&OK";
            base.AcceptButton = this.okButton;
            base.AutoScaleDimensions = new SizeF(9f, 20f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x28c, 0x1b3);
            base.Controls.Add(this.tableLayoutPanel);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.Margin = new Padding(4, 5, 4, 5);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "AboutBox";
            base.Padding = new Padding(14, 14, 14, 14);
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "AboutBox1";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((ISupportInitialize) this.logoPictureBox).EndInit();
            base.ResumeLayout(false);
        }

        public string AssemblyTitle
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (customAttributes.Length != 0)
                {
                    AssemblyTitleAttribute attribute = (AssemblyTitleAttribute) customAttributes[0];
                    if (attribute.Title != "")
                    {
                        return attribute.Title;
                    }
                }
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion =>
            Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public string AssemblyDescription
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (customAttributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute) customAttributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (customAttributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute) customAttributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (customAttributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute) customAttributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (customAttributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute) customAttributes[0]).Company;
            }
        }
    }
}

