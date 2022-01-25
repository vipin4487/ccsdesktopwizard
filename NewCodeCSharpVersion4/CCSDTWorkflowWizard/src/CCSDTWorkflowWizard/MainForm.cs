namespace CCSDTWorkflowWizard
{
    using AxSHDocVw;
    using CCSDTWorkflowLibrary;
    using Microsoft.VisualBasic;
    using mshtml;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.ComponentModel.Design.Serialization;
    using System.Deployment.Application;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Reflection;
    using System.Text;
    using System.Web;
    using System.Windows.Forms;
    using System.Workflow.Activities;
    using System.Workflow.ComponentModel;
    using System.Workflow.ComponentModel.Compiler;
    using System.Workflow.ComponentModel.Design;
    using System.Workflow.ComponentModel.Serialization;
    using System.Workflow.Runtime;
    using System.Xml;
    using WWELib;

    public class MainForm : Form, ISite, IServiceProvider
    {
        private WorkflowView workflowView;
        private DesignSurface designSurface;
        private WorkflowLoader loader;
        private WorkflowCompilerResults compilerResults;
        private WorkflowRuntime workflowRuntime;
        private Activity currentWorkflow;
        private const string AdditionalAssembies = "CCSDTWorkflowLibrary.dll";
        private PreviewHelper prvhelper;
        public int redirect_id = 0;
        public int business_unit_display_id = 0;
        public int aux_code_id = 0;
        public int business_unit_id = 0;
        public string logFilePath;
        public List<string> vals;
        private string temp = null;
        private IContainer components = null;
        private SplitContainer splitWorkspace;
        private SplitContainer splitToolboxAndProperties;
        private PropertyGrid propertyGrid1;
        private ToolStrip toolStrip1;
        private ToolStripButton tsbGetXml;
        private ToolStripButton tsbLoadXml;
        private ToolStripButton tsbCompile;
        private ToolStripButton tsbGetHtml;
        private ToolStripButton tsbSave;
        private TabControl tcWorkflow;
        private TabPage tbpDesign;
        private TabPage tbpPreview;
        internal Label InfoLabel;
        internal AxWebBrowser WebBrowser;
        private Panel pnlCallVar;
        private CallVariablesGridView dgCurrentCallVariables;
        private Button btnUpdateCallData;
        private ToolStripDropDownButton tsbEdit;
        private ToolStripMenuItem tsmCut;
        private ToolStripMenuItem tsmCopy;
        private ToolStripMenuItem tsmPaste;
        private ToolStripMenuItem tsmDelete;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem tsmSelectAll;
        private ToolStripMenuItem tsmUndo;
        private ToolStripMenuItem tsmRedo;
        private ToolStripSeparator toolStripMenuItem2;
        private Button submitButton;
        private ToolStripDropDownButton tsbHelp;
        private ToolStripMenuItem tsbHelp_About;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem tsbHelp_ViewLogFile;
        private ToolStripMenuItem tsbHelp_CopyLogFiles;
        private ToolStripMenuItem tsbHelp_EmailLogFiles;

        public MainForm()
        {
            try
            {
                AppLogger.AddMsg("*************", AppLogger.LoggingLevelTypes.NormalDebug);
                AppLogger.AddMsg("************* VCC Desktop Workflow Wizard has started.", AppLogger.LoggingLevelTypes.NormalDebug);
                AppLogger.AddMsg("*************", AppLogger.LoggingLevelTypes.NormalDebug);
                this.InitializeComponent();
                AppLogger.AddMsg("************* Component intiation completed.", AppLogger.LoggingLevelTypes.NormalDebug);
                Toolbox toolbox = new Toolbox(this);
                this.splitToolboxAndProperties.Panel1.Controls.Add(toolbox);
                toolbox.Dock = DockStyle.Fill;
                toolbox.BackColor = this.BackColor;
                toolbox.Font = WorkflowTheme.CurrentTheme.AmbientTheme.Font;
                toolbox.BringToFront();
                WorkflowTheme.CurrentTheme.ReadOnly = false;
                WorkflowTheme.CurrentTheme.AmbientTheme.ShowConfigErrors = true;
                WorkflowTheme.CurrentTheme.ReadOnly = true;
                this.propertyGrid1.BackColor = this.BackColor;
                this.propertyGrid1.Font = WorkflowTheme.CurrentTheme.AmbientTheme.Font;
                this.propertyGrid1.Site = this;
                AppLogger.AddMsg("************* Mainform Completed VCC Desktop Workflow Wizard has started.", AppLogger.LoggingLevelTypes.NormalDebug);
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("************* Mainform Completed VCC Desktop Workflow Wizard has started." + exception.Message, AppLogger.LoggingLevelTypes.NormalDebug);
            }
        }

        private void btnUpdateCallData_Click(object sender, EventArgs e)
        {
            this.UpdateCallData();
        }

        private void changeService_ComponentAdded(object sender, ComponentEventArgs e)
        {
        }

        private void changeService_ComponentChanged(object sender, ComponentChangedEventArgs e)
        {
            try
            {
                IComponentChangeService ccs = (IComponentChangeService) this.GetService(typeof(IComponentChangeService));
                if ((ccs != null) && (e.Component is Activity))
                {
                    IDesignerHost host = (IDesignerHost) this.GetService(typeof(IDesignerHost));
                    if ((host != null) && (host.RootComponent > null))
                    {
                        CustomCCSDTWorkflowBase rootComponent = host.RootComponent as CustomCCSDTWorkflowBase;
                        if (rootComponent > null)
                        {
                            rootComponent.ControlPropertyChanged(ccs, (Activity) e.Component, e.Member, e.OldValue, e.NewValue);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (MainForm.changeService_ComponentChanged) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        private void changeService_ComponentRemoved(object sender, ComponentEventArgs e)
        {
            try
            {
                IComponentChangeService ccs = (IComponentChangeService) this.GetService(typeof(IComponentChangeService));
                if ((ccs != null) && (e.Component is Activity))
                {
                    IDesignerHost host = (IDesignerHost) this.GetService(typeof(IDesignerHost));
                    if ((host != null) && (host.RootComponent > null))
                    {
                        CustomCCSDTWorkflowBase rootComponent = host.RootComponent as CustomCCSDTWorkflowBase;
                        if (rootComponent > null)
                        {
                            rootComponent.ControlRemoved(ccs, (Activity) e.Component);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (MainForm.changeService_ComponentRemoved) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        private void changeService_ComponentRename(object sender, ComponentRenameEventArgs e)
        {
            try
            {
                IComponentChangeService ccs = (IComponentChangeService) this.GetService(typeof(IComponentChangeService));
                if ((ccs != null) && (e.Component is Activity))
                {
                    IDesignerHost host = (IDesignerHost) this.GetService(typeof(IDesignerHost));
                    if ((host != null) && (host.RootComponent > null))
                    {
                        CustomCCSDTWorkflowBase rootComponent = host.RootComponent as CustomCCSDTWorkflowBase;
                        if (rootComponent > null)
                        {
                            rootComponent.ControlNameChanged(ccs, (Activity) e.Component, e.OldName, e.NewName);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (MainForm.changeService_ComponentRename) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        public bool Compile()
        {
            return this.Compile(true);
        }

        public bool Compile(bool showMessage)
        {
            if (string.IsNullOrEmpty(this.XomlFile))
            {
                this.Save(false);
            }
            if (!File.Exists(this.XomlFile))
            {
                MessageBox.Show(this, "Cannot locate xoml file: " + Path.Combine(Path.GetDirectoryName(base.GetType().Assembly.Location), this.XomlFile), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            bool flag = true;
            Cursor cursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string[] assemblyNames = new string[] { "CCSDTWorkflowLibrary.dll" };
                WorkflowCompiler compiler = new WorkflowCompiler();
                WorkflowCompilerParameters parameters = new WorkflowCompilerParameters(assemblyNames) {
                    OutputAssembly = string.Format("{0}.dll", this.WorkflowName)
                };
                string[] files = new string[] { this.XomlFile };
                this.compilerResults = compiler.Compile(parameters, files);
                StringBuilder builder = new StringBuilder();
                foreach (CompilerError error in this.compilerResults.Errors)
                {
                    builder.Append(error.ToString() + "\n");
                }
                if (builder.Length != 0)
                {
                    MessageBox.Show(this, builder.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    flag = false;
                }
                else if (showMessage)
                {
                    MessageBox.Show(this, "Workflow compiled successfully. Compiled assembly:\n" + this.compilerResults.CompiledAssembly.GetName(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            finally
            {
                this.Cursor = cursor;
            }
            return flag;
        }

        public void CopyLogFiles()
        {
            try
            {
                string str = "apse9553";
                string hostNameOrAddress = "";
                IPHostEntry hostEntry = Dns.GetHostEntry("CCSDTtlogs");
                foreach (IPAddress address in hostEntry.AddressList)
                {
                    if (address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        hostNameOrAddress = address.ToString();
                    }
                }
                if (hostNameOrAddress.Length > 0)
                {
                    IPHostEntry entry2 = Dns.GetHostEntry(hostNameOrAddress);
                    if (entry2 > null)
                    {
                        string hostName = entry2.HostName;
                        if ((hostName != null) && (hostName.Length > 0))
                        {
                            if (hostName.Contains("."))
                            {
                                str = hostName.Substring(0, hostName.IndexOf("."));
                            }
                            else
                            {
                                str = hostName;
                            }
                        }
                    }
                }
                string[] textArray1 = new string[] { @"\\", str, @"\AgentLogs\", SystemInformation.UserName, "_", SystemInformation.UserDomainName, @"\" };
                string path = string.Concat(textArray1);
                string str4 = Path.Combine(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Application.CompanyName), Application.ProductName), Application.ProductVersion);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string[] files = Directory.GetFiles(str4, "*.*");
                foreach (string str6 in files)
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str6);
                    string extension = Path.GetExtension(str6);
                    if (fileNameWithoutExtension == "CCSDTesktop")
                    {
                        File.Copy(str6, path + "CCSDTesktop_" + Strings.Format(DateTime.Now, "MMddyyyyHHmmssffff") + extension);
                    }
                    else
                    {
                        try
                        {
                            File.Copy(str6, path + fileNameWithoutExtension + extension);
                        }
                        catch (IOException exception)
                        {
                            AppLogger.AddMsg("MainForm.CopyLogFiles: error File.Copy: " + exception.Message, AppLogger.LoggingLevelTypes.Warnings);
                        }
                    }
                }
                MessageBox.Show("Your log files were copied.\r\n\r\nThanks!", "Copy Log Files", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception2)
            {
                AppLogger.AddMsg("**** ERROR: (MainForm.CopyLogFiles) " + exception2.Message + "//" + exception2.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
                MessageBox.Show("An error occured: " + exception2.Message + "\r\n\r\nUnable to copy your log files at this time.", "Copy Log Files", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void DeleteSelected()
        {
            ISelectionService service = (ISelectionService) this.GetService(typeof(ISelectionService));
            if ((service > null) && (service.PrimarySelection is Activity))
            {
                Activity primarySelection = (Activity) service.PrimarySelection;
                if (primarySelection.Name != this.WorkflowName)
                {
                    primarySelection.Parent.Activities.Remove(primarySelection);
                    this.workflowView.Update();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components > null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void FitToPage()
        {
            this.workflowView.FitToScreenSize();
            this.workflowView.Update();
        }

        public string GetCurrentXoml()
        {
            IDesignerHost service = (IDesignerHost) this.GetService(typeof(IDesignerHost));
            if ((service != null) && (service.RootComponent > null))
            {
                Activity rootComponent = service.RootComponent as Activity;
                if (rootComponent > null)
                {
                    using (StringWriter writer = new StringWriter())
                    {
                        using (XmlWriter writer2 = XmlWriter.Create(writer))
                        {
                            new WorkflowMarkupSerializer().Serialize(writer2, rootComponent);
                        }
                        return writer.ToString();
                    }
                }
            }
            return "";
        }

        public object GetService(Type serviceType)
        {
            AppLogger.AddMsg("************* GetSevcice is called.", AppLogger.LoggingLevelTypes.NormalDebug);
            return ((this.workflowView != null) ? ((IServiceProvider) this.workflowView).GetService(serviceType) : null);
        }

        private string GetWorkflowXoml(Type workflowType)
        {
            WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();
            StringWriter output = new StringWriter();
            XmlWriter writer = XmlWriter.Create(output);
            try
            {
                Activity activity = (Activity) Activator.CreateInstance(workflowType);
                serializer.Serialize(writer, activity);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                this.workflowRuntime.StopRuntime();
                output.Close();
            }
            return output.ToString();
        }

        private void InitializeComponent()
        {
            try
            {
                AppLogger.AddMsg("************* InitializeComponent Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                ComponentResourceManager manager = new ComponentResourceManager(typeof(MainForm));
                this.splitWorkspace = new SplitContainer();
                this.tcWorkflow = new TabControl();
                this.tbpDesign = new TabPage();
                this.tbpPreview = new TabPage();
                this.submitButton = new Button();
                this.InfoLabel = new Label();
                this.WebBrowser = new AxWebBrowser();
                this.toolStrip1 = new ToolStrip();
                this.tsbGetXml = new ToolStripButton();
                this.tsbLoadXml = new ToolStripButton();
                this.tsbCompile = new ToolStripButton();
                this.tsbGetHtml = new ToolStripButton();
                this.tsbSave = new ToolStripButton();
                this.tsbEdit = new ToolStripDropDownButton();
                this.tsmUndo = new ToolStripMenuItem();
                this.tsmRedo = new ToolStripMenuItem();
                this.toolStripMenuItem1 = new ToolStripSeparator();
                this.tsmCut = new ToolStripMenuItem();
                this.tsmCopy = new ToolStripMenuItem();
                this.tsmPaste = new ToolStripMenuItem();
                this.tsmDelete = new ToolStripMenuItem();
                this.toolStripMenuItem2 = new ToolStripSeparator();
                this.tsmSelectAll = new ToolStripMenuItem();
                this.tsbHelp = new ToolStripDropDownButton();
                this.tsbHelp_About = new ToolStripMenuItem();
                this.toolStripMenuItem3 = new ToolStripSeparator();
                this.tsbHelp_ViewLogFile = new ToolStripMenuItem();
                this.tsbHelp_CopyLogFiles = new ToolStripMenuItem();
                this.tsbHelp_EmailLogFiles = new ToolStripMenuItem();
                this.splitToolboxAndProperties = new SplitContainer();
                this.pnlCallVar = new Panel();
                this.dgCurrentCallVariables = new CallVariablesGridView();
                this.btnUpdateCallData = new Button();
                this.propertyGrid1 = new PropertyGrid();
                this.splitWorkspace.Panel1.SuspendLayout();
                this.splitWorkspace.Panel2.SuspendLayout();
                this.splitWorkspace.SuspendLayout();
                this.tcWorkflow.SuspendLayout();
                this.tbpPreview.SuspendLayout();
                this.WebBrowser.BeginInit();
                this.toolStrip1.SuspendLayout();
                this.splitToolboxAndProperties.Panel1.SuspendLayout();
                this.splitToolboxAndProperties.Panel2.SuspendLayout();
                this.splitToolboxAndProperties.SuspendLayout();
                this.pnlCallVar.SuspendLayout();
                ((ISupportInitialize) this.dgCurrentCallVariables).BeginInit();
                base.SuspendLayout();
                AppLogger.AddMsg("************* After Suspend Layout.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.splitWorkspace.Dock = DockStyle.Fill;
                this.splitWorkspace.Location = new Point(0, 0);
                this.splitWorkspace.Name = "splitWorkspace";
                AppLogger.AddMsg("************* splitWorkspace Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.splitWorkspace.Panel1.Controls.Add(this.tcWorkflow);
                this.splitWorkspace.Panel1.Controls.Add(this.toolStrip1);
                AppLogger.AddMsg("************* splitWorkspace.Panel1 Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.splitWorkspace.Panel2.Controls.Add(this.splitToolboxAndProperties);
                this.splitWorkspace.Size = new Size(0x233, 390);
                this.splitWorkspace.SplitterDistance = 0x18a;
                this.splitWorkspace.TabIndex = 0;
                AppLogger.AddMsg("************* splitWorkspace.Panel2 Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tcWorkflow.Controls.Add(this.tbpDesign);
                this.tcWorkflow.Controls.Add(this.tbpPreview);
                this.tcWorkflow.Dock = DockStyle.Fill;
                this.tcWorkflow.Location = new Point(0, 0x19);
                this.tcWorkflow.Name = "tcWorkflow";
                this.tcWorkflow.SelectedIndex = 0;
                this.tcWorkflow.Size = new Size(0x18a, 0x16d);
                this.tcWorkflow.TabIndex = 1;
                this.tcWorkflow.SelectedIndexChanged += new EventHandler(this.tcWorkflow_SelectedIndexChanged);
                this.tcWorkflow.Selected += new TabControlEventHandler(this.tcWorkflow_Selected);
                AppLogger.AddMsg("************* tcWorkflow Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tbpDesign.AllowDrop = true;
                this.tbpDesign.Location = new Point(4, 0x16);
                this.tbpDesign.Name = "tbpDesign";
                this.tbpDesign.Padding = new Padding(3);
                this.tbpDesign.Size = new Size(0x182, 0x153);
                this.tbpDesign.TabIndex = 0;
                this.tbpDesign.Text = "Design";
                this.tbpDesign.UseVisualStyleBackColor = true;
                AppLogger.AddMsg("************* tbpDesign Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tbpPreview.Controls.Add(this.submitButton);
                this.tbpPreview.Controls.Add(this.InfoLabel);
                this.tbpPreview.Controls.Add(this.WebBrowser);
                this.tbpPreview.Location = new Point(4, 0x16);
                this.tbpPreview.Name = "tbpPreview";
                this.tbpPreview.Padding = new Padding(3);
                this.tbpPreview.Size = new Size(0x182, 0x153);
                this.tbpPreview.TabIndex = 1;
                this.tbpPreview.Text = "Preview";
                this.tbpPreview.UseVisualStyleBackColor = true;
                AppLogger.AddMsg("************* tbpPreview Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.submitButton.Location = new Point(0x131, 0x13b);
                this.submitButton.Name = "submitButton";
                this.submitButton.Size = new Size(0x4e, 0x19);
                this.submitButton.TabIndex = 13;
                this.submitButton.Text = "Submit";
                this.submitButton.UseVisualStyleBackColor = true;
                this.submitButton.Click += new EventHandler(this.submitButton_Click);
                AppLogger.AddMsg("************* submitButton Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.InfoLabel.BackColor = Color.FromArgb(0xff, 0xff, 0xc0);
                this.InfoLabel.Dock = DockStyle.Bottom;
                this.InfoLabel.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
                this.InfoLabel.Location = new Point(3, 0x139);
                this.InfoLabel.Name = "InfoLabel";
                this.InfoLabel.Size = new Size(380, 0x17);
                this.InfoLabel.TabIndex = 11;
                AppLogger.AddMsg("************* InfoLabel Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.WebBrowser.Dock = DockStyle.Top;
                this.WebBrowser.Enabled = true;
                this.WebBrowser.Location = new Point(3, 3);
                this.WebBrowser.OcxState = (AxHost.State) manager.GetObject("WebBrowser.OcxState");
                this.WebBrowser.Size = new Size(380, 0x14d);
                this.WebBrowser.TabIndex = 10;
                AppLogger.AddMsg("************* WebBrowser Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                ToolStripItem[] toolStripItems = new ToolStripItem[] { this.tsbGetXml, this.tsbLoadXml, this.tsbCompile, this.tsbGetHtml, this.tsbSave, this.tsbEdit, this.tsbHelp };
                this.toolStrip1.Items.AddRange(toolStripItems);
                this.toolStrip1.Location = new Point(0, 0);
                this.toolStrip1.Name = "toolStrip1";
                this.toolStrip1.Size = new Size(0x18a, 0x19);
                this.toolStrip1.TabIndex = 0;
                this.toolStrip1.Text = "toolStrip1";
                AppLogger.AddMsg("************* toolStrip1 Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsbGetXml.DisplayStyle = ToolStripItemDisplayStyle.Text;
                this.tsbGetXml.Image = (Image) manager.GetObject("tsbGetXml.Image");
                this.tsbGetXml.ImageTransparentColor = Color.Magenta;
                this.tsbGetXml.Name = "tsbGetXml";
                this.tsbGetXml.Size = new Size(0x35, 0x16);
                this.tsbGetXml.Text = "Get Xml";
                this.tsbGetXml.Visible = false;
                this.tsbGetXml.Click += new EventHandler(this.tsbGetXml_Click);
                AppLogger.AddMsg("************* tsbGetXml Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsbLoadXml.DisplayStyle = ToolStripItemDisplayStyle.Text;
                this.tsbLoadXml.Image = (Image) manager.GetObject("tsbLoadXml.Image");
                this.tsbLoadXml.ImageTransparentColor = Color.Magenta;
                this.tsbLoadXml.Name = "tsbLoadXml";
                this.tsbLoadXml.Size = new Size(0x3d, 0x16);
                this.tsbLoadXml.Text = "Load Xml";
                this.tsbLoadXml.Visible = false;
                this.tsbLoadXml.Click += new EventHandler(this.tsbLoadXml_Click);
                AppLogger.AddMsg("************* tsbLoadXml Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsbCompile.DisplayStyle = ToolStripItemDisplayStyle.Text;
                this.tsbCompile.Image = (Image) manager.GetObject("tsbCompile.Image");
                this.tsbCompile.ImageTransparentColor = Color.Magenta;
                this.tsbCompile.Name = "tsbCompile";
                this.tsbCompile.Size = new Size(0x38, 0x16);
                this.tsbCompile.Text = "Compile";
                this.tsbCompile.Visible = false;
                this.tsbCompile.Click += new EventHandler(this.tsbCompile_Click);
                AppLogger.AddMsg("************* tsbCompile Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsbGetHtml.DisplayStyle = ToolStripItemDisplayStyle.Text;
                this.tsbGetHtml.Image = (Image) manager.GetObject("tsbGetHtml.Image");
                this.tsbGetHtml.ImageTransparentColor = Color.Magenta;
                this.tsbGetHtml.Name = "tsbGetHtml";
                this.tsbGetHtml.Size = new Size(0x38, 0x16);
                this.tsbGetHtml.Text = "GetHtml";
                this.tsbGetHtml.Visible = false;
                this.tsbGetHtml.Click += new EventHandler(this.tsbGetHtml_Click);
                AppLogger.AddMsg("************* tsbGetHtml Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsbSave.DisplayStyle = ToolStripItemDisplayStyle.Text;
                this.tsbSave.Image = (Image) manager.GetObject("tsbSave.Image");
                this.tsbSave.ImageTransparentColor = Color.Magenta;
                this.tsbSave.Name = "tsbSave";
                this.tsbSave.Size = new Size(0x23, 0x16);
                this.tsbSave.Text = "Save";
                this.tsbSave.Click += new EventHandler(this.tsbSave_Click);
                AppLogger.AddMsg("************* tsbSave Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsbEdit.DisplayStyle = ToolStripItemDisplayStyle.Text;
                ToolStripItem[] itemArray2 = new ToolStripItem[] { this.tsmUndo, this.tsmRedo, this.toolStripMenuItem1, this.tsmCut, this.tsmCopy, this.tsmPaste, this.tsmDelete, this.toolStripMenuItem2, this.tsmSelectAll };
                this.tsbEdit.DropDownItems.AddRange(itemArray2);
                this.tsbEdit.Image = (Image) manager.GetObject("tsbEdit.Image");
                this.tsbEdit.ImageTransparentColor = Color.Magenta;
                this.tsbEdit.Name = "tsbEdit";
                this.tsbEdit.Size = new Size(40, 0x16);
                this.tsbEdit.Text = "Edit";
                this.tsbEdit.ToolTipText = "Edit the Workflow";
                this.tsbEdit.DropDownOpening += new EventHandler(this.tsbEdit_DropDownOpening);
                AppLogger.AddMsg("************* tsbEdit Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsmUndo.Name = "tsmUndo";
                this.tsmUndo.ShortcutKeys = Keys.Control | Keys.Z;
                this.tsmUndo.Size = new Size(0xa4, 0x16);
                this.tsmUndo.Text = "&Undo";
                this.tsmUndo.Click += new EventHandler(this.tsmUndo_Click);
                AppLogger.AddMsg("************* tsmUndo Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsmRedo.Name = "tsmRedo";
                this.tsmRedo.ShortcutKeys = Keys.Control | Keys.Y;
                this.tsmRedo.Size = new Size(0xa4, 0x16);
                this.tsmRedo.Text = "&Redo";
                this.tsmRedo.Click += new EventHandler(this.tsmRedo_Click);
                AppLogger.AddMsg("************* tsmRedo Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.toolStripMenuItem1.Name = "toolStripMenuItem1";
                this.toolStripMenuItem1.Size = new Size(0xa1, 6);
                AppLogger.AddMsg("************* toolStripMenuItem1 Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsmCut.Name = "tsmCut";
                this.tsmCut.ShortcutKeys = Keys.Control | Keys.X;
                this.tsmCut.Size = new Size(0xa4, 0x16);
                this.tsmCut.Text = "Cu&t";
                this.tsmCut.Click += new EventHandler(this.tsmCut_Click);
                AppLogger.AddMsg("************* tsmCut Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsmCopy.Name = "tsmCopy";
                this.tsmCopy.ShortcutKeys = Keys.Control | Keys.C;
                this.tsmCopy.Size = new Size(0xa4, 0x16);
                this.tsmCopy.Text = "&Copy";
                this.tsmCopy.Click += new EventHandler(this.tsmCopy_Click);
                AppLogger.AddMsg("************* tsmCopy Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsmPaste.Name = "tsmPaste";
                this.tsmPaste.ShortcutKeys = Keys.Control | Keys.V;
                this.tsmPaste.Size = new Size(0xa4, 0x16);
                this.tsmPaste.Text = "&Paste";
                this.tsmPaste.Click += new EventHandler(this.tsmPaste_Click);
                AppLogger.AddMsg("************* tsmPaste Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsmDelete.Name = "tsmDelete";
                this.tsmDelete.ShortcutKeys = Keys.Delete;
                this.tsmDelete.Size = new Size(0xa4, 0x16);
                this.tsmDelete.Text = "&Delete";
                this.tsmDelete.Click += new EventHandler(this.tsmDelete_Click);
                AppLogger.AddMsg("************* tsmDelete Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.toolStripMenuItem2.Name = "toolStripMenuItem2";
                this.toolStripMenuItem2.Size = new Size(0xa1, 6);
                AppLogger.AddMsg("************* toolStripMenuItem2 Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsmSelectAll.Name = "tsmSelectAll";
                this.tsmSelectAll.ShortcutKeys = Keys.Control | Keys.A;
                this.tsmSelectAll.Size = new Size(0xa4, 0x16);
                this.tsmSelectAll.Text = "Select &All";
                this.tsmSelectAll.Click += new EventHandler(this.tsmSelectAll_Click);
                AppLogger.AddMsg("************* tsmSelectAll Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsbHelp.DisplayStyle = ToolStripItemDisplayStyle.Text;
                ToolStripItem[] itemArray3 = new ToolStripItem[] { this.tsbHelp_About, this.toolStripMenuItem3, this.tsbHelp_ViewLogFile, this.tsbHelp_CopyLogFiles, this.tsbHelp_EmailLogFiles };
                this.tsbHelp.DropDownItems.AddRange(itemArray3);
                this.tsbHelp.Image = (Image) manager.GetObject("tsbHelp.Image");
                this.tsbHelp.ImageTransparentColor = Color.Magenta;
                this.tsbHelp.Name = "tsbHelp";
                this.tsbHelp.Size = new Size(0x2d, 0x16);
                this.tsbHelp.Text = "Help";
                this.tsbHelp.ToolTipText = "Display the About dialog.";
                AppLogger.AddMsg("************* tsbHelp Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsbHelp_About.Name = "tsbHelp_About";
                this.tsbHelp_About.Size = new Size(0x98, 0x16);
                this.tsbHelp_About.Text = "About";
                this.tsbHelp_About.Click += new EventHandler(this.tsbHelp_About_Click);
                AppLogger.AddMsg("************* tsbHelp_About Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.toolStripMenuItem3.Name = "toolStripMenuItem3";
                this.toolStripMenuItem3.Size = new Size(0x95, 6);
                AppLogger.AddMsg("************* toolStripMenuItem3 Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsbHelp_ViewLogFile.Name = "tsbHelp_ViewLogFile";
                this.tsbHelp_ViewLogFile.Size = new Size(0x98, 0x16);
                this.tsbHelp_ViewLogFile.Text = "View Log File";
                this.tsbHelp_ViewLogFile.Click += new EventHandler(this.tsbHelp_ViewLogFile_Click);
                AppLogger.AddMsg("************* tsbHelp_ViewLogFile Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsbHelp_CopyLogFiles.Name = "tsbHelp_CopyLogFiles";
                this.tsbHelp_CopyLogFiles.Size = new Size(0x98, 0x16);
                this.tsbHelp_CopyLogFiles.Text = "Copy Log Files";
                this.tsbHelp_CopyLogFiles.Click += new EventHandler(this.tsbHelp_CopyLogFiles_Click);
                AppLogger.AddMsg("************* tsbHelp_CopyLogFiles Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.tsbHelp_EmailLogFiles.Name = "tsbHelp_EmailLogFiles";
                this.tsbHelp_EmailLogFiles.Size = new Size(0x98, 0x16);
                this.tsbHelp_EmailLogFiles.Text = "Email Log Files";
                this.tsbHelp_EmailLogFiles.Click += new EventHandler(this.tsbHelp_EmailLogFiles_Click);
                AppLogger.AddMsg("************* tsbHelp_EmailLogFiles Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.splitToolboxAndProperties.Dock = DockStyle.Fill;
                this.splitToolboxAndProperties.Location = new Point(0, 0);
                this.splitToolboxAndProperties.Name = "splitToolboxAndProperties";
                this.splitToolboxAndProperties.Orientation = Orientation.Horizontal;
                AppLogger.AddMsg("************* splitToolboxAndProperties Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.splitToolboxAndProperties.Panel1.Controls.Add(this.pnlCallVar);
                AppLogger.AddMsg("************* splitToolboxAndProperties.Panel1 Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.splitToolboxAndProperties.Panel2.Controls.Add(this.propertyGrid1);
                this.splitToolboxAndProperties.Size = new Size(0xa5, 390);
                this.splitToolboxAndProperties.SplitterDistance = 0xbb;
                this.splitToolboxAndProperties.TabIndex = 0;
                AppLogger.AddMsg("************* splitToolboxAndProperties.Panel2 Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.pnlCallVar.Controls.Add(this.dgCurrentCallVariables);
                this.pnlCallVar.Controls.Add(this.btnUpdateCallData);
                this.pnlCallVar.Dock = DockStyle.Fill;
                this.pnlCallVar.Location = new Point(0, 0);
                this.pnlCallVar.Name = "pnlCallVar";
                this.pnlCallVar.Size = new Size(0xa5, 0xbb);
                this.pnlCallVar.TabIndex = 0;
                AppLogger.AddMsg("************* pnlCallVar Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.dgCurrentCallVariables.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dgCurrentCallVariables.Dock = DockStyle.Fill;
                this.dgCurrentCallVariables.Location = new Point(0, 0x17);
                this.dgCurrentCallVariables.Name = "dgCurrentCallVariables";
                this.dgCurrentCallVariables.RowHeadersVisible = false;
                this.dgCurrentCallVariables.Size = new Size(0xa5, 0xa4);
                this.dgCurrentCallVariables.TabIndex = 1;
                AppLogger.AddMsg("************* dgCurrentCallVariables Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.btnUpdateCallData.Dock = DockStyle.Top;
                this.btnUpdateCallData.Location = new Point(0, 0);
                this.btnUpdateCallData.Name = "btnUpdateCallData";
                this.btnUpdateCallData.Size = new Size(0xa5, 0x17);
                this.btnUpdateCallData.TabIndex = 0;
                this.btnUpdateCallData.Text = "Update Call Variables";
                this.btnUpdateCallData.UseVisualStyleBackColor = true;
                this.btnUpdateCallData.Click += new EventHandler(this.btnUpdateCallData_Click);
                AppLogger.AddMsg("************* btnUpdateCallData Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                this.propertyGrid1.Dock = DockStyle.Fill;
                this.propertyGrid1.Location = new Point(0, 0);
                this.propertyGrid1.Name = "propertyGrid1";
                this.propertyGrid1.Size = new Size(0xa5, 0xc7);
                this.propertyGrid1.TabIndex = 0;
                AppLogger.AddMsg("************* propertyGrid1 Called.", AppLogger.LoggingLevelTypes.NormalDebug);
                base.AutoScaleDimensions = new SizeF(6f, 13f);
                base.AutoScaleMode = AutoScaleMode.Font;
                base.ClientSize = new Size(0x233, 390);
                base.Controls.Add(this.splitWorkspace);
                base.Icon = (Icon) manager.GetObject("$this.Icon");
                base.Name = "MainForm";
                this.Text = "CCS Desktop Omni Workflow Wizard";
                base.FormClosed += new FormClosedEventHandler(this.MainForm_FormClosed);
                base.Load += new EventHandler(this.MainForm_Load);
                base.Resize += new EventHandler(this.MainForm_Resize);
                this.splitWorkspace.Panel1.ResumeLayout(false);
                this.splitWorkspace.Panel1.PerformLayout();
                this.splitWorkspace.Panel2.ResumeLayout(false);
                this.splitWorkspace.ResumeLayout(false);
                this.tcWorkflow.ResumeLayout(false);
                this.tbpPreview.ResumeLayout(false);
                this.WebBrowser.EndInit();
                this.toolStrip1.ResumeLayout(false);
                this.toolStrip1.PerformLayout();
                this.splitToolboxAndProperties.Panel1.ResumeLayout(false);
                this.splitToolboxAndProperties.Panel2.ResumeLayout(false);
                this.splitToolboxAndProperties.ResumeLayout(false);
                this.pnlCallVar.ResumeLayout(false);
                ((ISupportInitialize) this.dgCurrentCallVariables).EndInit();
                base.ResumeLayout(false);
                AppLogger.AddMsg("************* InitiationCompleted Called.", AppLogger.LoggingLevelTypes.NormalDebug);
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("************* Initiation Failed ." + exception.Message, AppLogger.LoggingLevelTypes.NormalDebug);
            }
        }

        private void LoadAssemblyWorkflows(string assemblyPath)
        {
            Assembly assembly = Assembly.LoadFile(assemblyPath);
            if (assembly == null)
            {
                MessageBox.Show("Cannot load assembly", "WFPad", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                List<Type> list = new List<Type>();
                foreach (Type type2 in assembly.GetTypes())
                {
                    if (type2.IsSubclassOf(typeof(SequentialWorkflowActivity)) || type2.IsSubclassOf(typeof(StateMachineWorkflowActivity)))
                    {
                        list.Add(type2);
                    }
                }
                if (list.Count == 0)
                {
                    MessageBox.Show("Could not find any workflows in this assembly", "WFPad", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    Type workflowType = list[0];
                    if (list.Count > 1)
                    {
                    }
                    ICollection is2 = this.LoadWorkflow(workflowType);
                    if (is2 > null)
                    {
                        StringBuilder builder = new StringBuilder();
                        builder.Append("Could not load workflow:\n\n");
                        foreach (Exception exception in is2)
                        {
                            builder.Append(exception.Message);
                        }
                        MessageBox.Show(builder.ToString(), "WFPad", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }

        public void LoadExistingWorkflow()
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = "xoml files (*.xoml)|*.xoml|Assemblies (*.exe;*.dll)|*.exe;*.dll|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if ((Path.GetExtension(dialog.FileName) == ".exe") || (Path.GetExtension(dialog.FileName) == ".dll"))
                {
                    this.LoadAssemblyWorkflows(dialog.FileName);
                }
                else
                {
                    using (XmlReader reader = XmlReader.Create(dialog.FileName))
                    {
                        WorkflowMarkupSerializer serializer = new WorkflowMarkupSerializer();
                        this.currentWorkflow = (SequentialWorkflowActivity) serializer.Deserialize(reader);
                        this.LoadWorkflow();
                        this.XomlFile = dialog.FileName;
                        this.Text = "WFPad -- [" + dialog.FileName + "]";
                    }
                }
            }
        }

        public void LoadNewSequentialWorkflow()
        {
            string str = string.Empty;
            str = this.LoadWorkFlowType();
            AppLogger.AddMsg("************* LoadNewSequentialWorkflow is  started.", AppLogger.LoggingLevelTypes.NormalDebug);
            switch (str)
            {
                case "SmartRedirect":
                    break;

                case "ScreenPop":
                {
                    this.currentWorkflow = new ScreenPopWorkflow();
                    BUSINESS_UNIT_DISPLAY screenPopDefinition = new ScreenPopDBConnection().GetScreenPopDefinition(this.business_unit_display_id);
                    if (screenPopDefinition > null)
                    {
                        AppLogger.AddMsg("************* Before Xoml is assigned.", AppLogger.LoggingLevelTypes.NormalDebug);
                        this.Xoml = screenPopDefinition.screenpop_script_xoml;
                        AppLogger.AddMsg("************* Afterxoml is assigned." + this.Xoml, AppLogger.LoggingLevelTypes.NormalDebug);
                        this.Text = this.Text + " - " + screenPopDefinition.display_tag;
                    }
                    break;
                }
                default:
                    MessageBox.Show("Invalid Parameters for the WorkFlow. Cannot proceed further.", "Invalid WorkFlow", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    base.Close();
                    return;
            }
            this.currentWorkflow.Name = "Workflow";
            if ((this.Xoml == null) || (this.Xoml.Length == 0))
            {
                this.LoadWorkflow();
            }
        }

        public void LoadNewStateMachineWorkflow()
        {
            this.currentWorkflow = new StateMachineWorkflowActivity();
            this.currentWorkflow.Name = "CustomStateMachineWorkflow";
            this.LoadWorkflow();
        }

        private void LoadWorkflow()
        {
            using (StringWriter writer = new StringWriter())
            {
                using (XmlWriter writer2 = XmlWriter.Create(writer))
                {
                    new WorkflowMarkupSerializer().Serialize(writer2, this.currentWorkflow);
                    this.Xoml = writer.ToString();
                }
            }
        }

        private ICollection LoadWorkflow(WorkflowLoader loader)
        {
            base.SuspendLayout();
            DesignSurface surface = new DesignSurface();
            surface.BeginLoad(loader);
            if (surface.LoadErrors.Count > 0)
            {
                return surface.LoadErrors;
            }
            IDesignerHost provider = surface.GetService(typeof(IDesignerHost)) as IDesignerHost;
            if ((provider != null) && (provider.RootComponent > null))
            {
                IRootDesigner designer = provider.GetDesigner(provider.RootComponent) as IRootDesigner;
                if (designer > null)
                {
                    this.UnloadWorkflow();
                    this.designSurface = surface;
                    this.loader = loader;
                    this.workflowView = designer.GetView(ViewTechnology.Default) as WorkflowView;
                    this.tbpDesign.Controls.Add(this.workflowView);
                    this.workflowView.Dock = DockStyle.Fill;
                    this.workflowView.TabIndex = 1;
                    this.workflowView.TabStop = true;
                    this.workflowView.HScrollBar.TabStop = false;
                    this.workflowView.VScrollBar.TabStop = false;
                    this.workflowView.Focus();
                    this.propertyGrid1.Site = provider.RootComponent.Site;
                    ISelectionService service = this.GetService(typeof(ISelectionService)) as ISelectionService;
                    IComponentChangeService service2 = this.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
                    ComponentSerializationService service3 = this.GetService(typeof(ComponentSerializationService)) as ComponentSerializationService;
                    if (service > null)
                    {
                        service.SelectionChanged += new EventHandler(this.OnSelectionChanged);
                    }
                    if (service2 > null)
                    {
                        service2.ComponentAdded += new ComponentEventHandler(this.changeService_ComponentAdded);
                        service2.ComponentChanged += new ComponentChangedEventHandler(this.changeService_ComponentChanged);
                        service2.ComponentRemoved += new ComponentEventHandler(this.changeService_ComponentRemoved);
                        service2.ComponentRename += new ComponentRenameEventHandler(this.changeService_ComponentRename);
                    }
                    WorkflowMenuCommandService service4 = (WorkflowMenuCommandService) this.GetService(typeof(IMenuCommandService));
                    WorkflowUndoEngine serviceInstance = new WorkflowUndoEngine(provider);
                    provider.AddService(typeof(UndoEngine), serviceInstance);
                    if ((service4 != null) && (serviceInstance > null))
                    {
                        service4.AddCommand(new MenuCommand(new EventHandler(serviceInstance.OnUndo), StandardCommands.Undo));
                        service4.AddCommand(new MenuCommand(new EventHandler(serviceInstance.OnRedo), StandardCommands.Redo));
                        serviceInstance.Enabled = true;
                    }
                }
            }
            base.ResumeLayout(true);
            return null;
        }

        private ICollection LoadWorkflow(string xoml)
        {
            WorkflowLoader loader = new WorkflowLoader(this.propertyGrid1) {
                Xoml = xoml
            };
            return this.LoadWorkflow(loader);
        }

        private ICollection LoadWorkflow(Type workflowType)
        {
            WorkflowLoader loader = new WorkflowLoader(this.propertyGrid1) {
                WorkflowType = workflowType
            };
            return this.LoadWorkflow(loader);
        }

        private string LoadWorkFlowType()
        {
            string str = string.Empty;
            NameValueCollection values = new NameValueCollection();
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                string query = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
                values = HttpUtility.ParseQueryString(query);
                if (query.IndexOf("redirect_id") >= 0)
                {
                    this.redirect_id = Convert.ToInt32(values["redirect_id"]);
                    this.business_unit_id = Convert.ToInt32(values["business_unit_id"]);
                    return "SmartRedirect";
                }
                if (query.IndexOf("business_unit_display_id") >= 0)
                {
                    this.business_unit_display_id = Convert.ToInt32(values["business_unit_display_id"]);
                    this.business_unit_id = Convert.ToInt32(values["business_unit_id"]);
                    return "ScreenPop";
                }
                if (query.IndexOf("aux_code_id") >= 0)
                {
                    this.aux_code_id = Convert.ToInt32(values["aux_code_id"]);
                    this.business_unit_id = Convert.ToInt32(values["business_unit_id"]);
                    str = "AuxCodePop";
                }
                return str;
            }
            if (this.redirect_id > 0)
            {
                return "SmartRedirect";
            }
            if (this.business_unit_display_id > 0)
            {
                return "ScreenPop";
            }
            if (this.aux_code_id > 0)
            {
                str = "AuxCodePop";
            }
            return str;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppLogger.AddMsg("*************", AppLogger.LoggingLevelTypes.NormalDebug);
            AppLogger.AddMsg("************* VCC Desktop Workflow Wizard is exiting.", AppLogger.LoggingLevelTypes.NormalDebug);
            AppLogger.AddMsg("*************", AppLogger.LoggingLevelTypes.NormalDebug);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AppLogger.AddMsg("************* mainform load event.", AppLogger.LoggingLevelTypes.NormalDebug);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            try
            {
                this.WebBrowser.Height = this.tbpPreview.ClientSize.Height - this.InfoLabel.Height;
                if (this.redirect_id > 0)
                {
                    this.submitButton.Visible = false;
                }
                else
                {
                    this.submitButton.Left = (this.tbpPreview.Width - this.submitButton.Width) - 3;
                    this.submitButton.Top = this.tbpPreview.Height - this.submitButton.Height;
                }
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (MainForm.MainForm_Resize) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AppLogger.AddMsg("************* OnLoadEvnt is fired.", AppLogger.LoggingLevelTypes.NormalDebug);
            this.LoadNewSequentialWorkflow();
            AppLogger.AddMsg("************* OnLoadEvnt is Completed.", AppLogger.LoggingLevelTypes.NormalDebug);
        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            ISelectionService service = this.GetService(typeof(ISelectionService)) as ISelectionService;
            if (service > null)
            {
                this.propertyGrid1.SelectedObjects = new ArrayList(service.GetSelectedComponents()).ToArray();
            }
        }

        public void ProcessZoom(int zoomFactor)
        {
            this.workflowView.Zoom = zoomFactor;
            this.workflowView.Update();
        }

        public bool Run()
        {
            if ((this.compilerResults == null) && !this.Compile(false))
            {
                return false;
            }
            if (this.workflowRuntime == null)
            {
                this.workflowRuntime = new WorkflowRuntime();
            }
            this.workflowRuntime.StartRuntime();
            this.workflowRuntime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(this.workflowRuntime_WorkflowCompleted);
            this.workflowRuntime.CreateWorkflow(this.compilerResults.CompiledAssembly.GetType(string.Format("{0}.{1}", base.GetType().Namespace, this.WorkflowName))).Start();
            return true;
        }

        public bool Save()
        {
            return this.Save(true);
        }

        public bool Save(bool showMessage)
        {
            Cursor cursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            bool flag = true;
            try
            {
                this.SaveFile();
                XmlDocument document = new XmlDocument();
                document.Load(this.XomlFile);
                XmlAttribute node = document.CreateAttribute("x", "Class", "http://schemas.microsoft.com/winfx/2006/xaml");
                node.Value = string.Format("{0}.{1}", base.GetType().Namespace, this.WorkflowName);
                document.DocumentElement.Attributes.Append(node);
                document.Save(this.XomlFile);
                if (showMessage)
                {
                    MessageBox.Show(this, "Workflow generated successfully. Generated xoml file:\n" + Path.Combine(Path.GetDirectoryName(base.GetType().Assembly.Location), this.XomlFile), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
                flag = false;
            }
            finally
            {
                this.Cursor = cursor;
            }
            return flag;
        }

        internal void SaveExistingWorkflow(string filePath)
        {
            if ((this.designSurface != null) && (this.loader > null))
            {
                this.XomlFile = filePath;
                this.loader.PerformFlush();
            }
        }

        public void SaveFile()
        {
            if (this.XomlFile.Length != 0)
            {
                this.SaveExistingWorkflow(this.XomlFile);
            }
            else
            {
                SaveFileDialog dialog = new SaveFileDialog {
                    Filter = "xoml files (*.xoml)|*.xoml|All files (*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.SaveExistingWorkflow(dialog.FileName);
                    this.Text = "Designer Hosting Sample -- [" + dialog.FileName + "]";
                }
            }
        }

        private void ShowPreview()
        {
            try
            {
                IDesignerHost service = (IDesignerHost) this.GetService(typeof(IDesignerHost));
                if ((service != null) && (service.RootComponent > null))
                {
                    CustomCCSDTWorkflowBase rootComponent = service.RootComponent as CustomCCSDTWorkflowBase;
                    if (rootComponent > null)
                    {
                        if (this.prvhelper == null)
                        {
                            this.prvhelper = new PreviewHelper(rootComponent);
                        }
                        this.prvhelper.DisplayPreview(this.WebBrowser, this.pnlCallVar, this.dgCurrentCallVariables, this.btnUpdateCallData);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error previewing Workflow" + Environment.NewLine + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.WebBrowser.Height = this.tbpPreview.ClientSize.Height - this.InfoLabel.Height;
                HTMLDocument document = this.WebBrowser.get_Document() as HTMLDocument;
                IHTMLWindow2 parentWindow = document.parentWindow;
                if (parentWindow > null)
                {
                    string language = "javascript";
                    string str4 = "testClosingCriteria";
                    string[] textArray1 = new string[] { "if (window.", str4, ") {", str4, "();};" };
                    string code = string.Concat(textArray1);
                    try
                    {
                        parentWindow.execScript(code, language);
                    }
                    catch (Exception exception)
                    {
                        AppLogger.AddMsg("ERROR: (HTMLScreenPop.SubmitButton_Click.execScript) " + exception.Message, AppLogger.LoggingLevelTypes.Errors);
                    }
                }
                string str = null;
                string text = null;
                HTMLInputElement element = document.getElementById("FormValidatedForClose") as HTMLInputElement;
                if (element != null)
                {
                    str = element.value;
                    HTMLInputElement element2 = document.getElementById("ErrorMessageOnClose") as HTMLInputElement;
                    if (element2 > null)
                    {
                        text = element2.value;
                    }
                }
                if (str == "0")
                {
                    if ((text == null) || (text.Length == 0))
                    {
                        MessageBox.Show("Please complete the form before closing.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show(text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("You have satisified the closing criteria!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception exception2)
            {
                AppLogger.AddMsg("**** ERROR: (MainForm.submitButton_Click) " + exception2.Message + "//" + exception2.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        private void tcWorkflow_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 0)
            {
                this.dgCurrentCallVariables.EndEdit();
                this.pnlCallVar.SendToBack();
            }
            else if (e.TabPageIndex == 1)
            {
                this.pnlCallVar.BringToFront();
                this.ShowPreview();
            }
        }

        private void tcWorkflow_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.WebBrowser.Height = this.tbpPreview.ClientSize.Height - this.InfoLabel.Height;
                if (this.redirect_id > 0)
                {
                    this.submitButton.Visible = false;
                }
                else
                {
                    this.submitButton.Left = (this.tbpPreview.Width - this.submitButton.Width) - 3;
                    this.submitButton.Top = this.tbpPreview.Height - this.submitButton.Height;
                }
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (MainForm.tcWorkflow_SelectedIndexChanged) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        private void tsbCompile_Click(object sender, EventArgs e)
        {
            this.Compile();
        }

        private void tsbEdit_DropDownOpening(object sender, EventArgs e)
        {
            try
            {
                bool canUndo = false;
                bool canRedo = false;
                WorkflowUndoEngine engine = (WorkflowUndoEngine) this.GetService(typeof(UndoEngine));
                if (engine > null)
                {
                    canUndo = engine.CanUndo;
                    canRedo = engine.CanRedo;
                }
                this.tsmUndo.Enabled = canUndo;
                this.tsmRedo.Enabled = canRedo;
                WorkflowMenuCommandService service = (WorkflowMenuCommandService) this.GetService(typeof(IMenuCommandService));
                if (service > null)
                {
                    bool flag5 = false;
                    if (this.workflowView > null)
                    {
                        Activity[] activityArray = CompositeActivityDesigner.DeserializeActivitiesFromDataObject(this.workflowView, Clipboard.GetDataObject());
                        if ((activityArray != null) && (activityArray.Length != 0))
                        {
                            flag5 = true;
                        }
                    }
                    this.tsmPaste.Enabled = flag5;
                    if (this.tsmCut.Image == null)
                    {
                        this.tsmCut.Image = service.bmpCut;
                        this.tsmCopy.Image = service.bmpCopy;
                        this.tsmPaste.Image = service.bmpPaste;
                        this.tsmDelete.Image = service.bmpDelete;
                    }
                }
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (MainForm.tsbEdit_DropDownOpening) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        private void tsbGetHtml_Click(object sender, EventArgs e)
        {
            IDesignerHost service = (IDesignerHost) this.GetService(typeof(IDesignerHost));
            if ((service != null) && (service.RootComponent > null))
            {
                CustomCCSDTWorkflowBase rootComponent = service.RootComponent as CustomCCSDTWorkflowBase;
                if (rootComponent > null)
                {
                    string getHtml = rootComponent.GetHtml;
                    MessageBox.Show(getHtml);
                    Clipboard.SetData(DataFormats.Text, getHtml);
                }
            }
        }

        private void tsbGetXml_Click(object sender, EventArgs e)
        {
            this.temp = this.GetCurrentXoml();
            MessageBox.Show(this.temp);
        }

        private void tsbHelp_About_Click(object sender, EventArgs e)
        {
            try
            {
                new AboutBox().ShowDialog(this);
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (MainForm.tsbAbout_Click) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        private void tsbHelp_CopyLogFiles_Click(object sender, EventArgs e)
        {
            this.CopyLogFiles();
        }

        private void tsbHelp_EmailLogFiles_Click(object sender, EventArgs e)
        {
            try
            {
                string str = this.logFilePath.Substring(0, this.logFilePath.LastIndexOf(@"\"));
                string text = "";
                if ((text != null) && (text.Length > 0))
                {
                    DialogResult result = MessageBox.Show(text, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (VCCPhone.EmailLogFilesToolStripMenuItem_Click) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        private void tsbHelp_ViewLogFile_Click(object sender, EventArgs e)
        {
            try
            {
                Interaction.Shell("Notepad " + this.logFilePath, AppWinStyle.NormalFocus, false, -1);
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (MainForm.tsbHelp_ViewLogFile_Click) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        private void tsbLoadXml_Click(object sender, EventArgs e)
        {
            this.Xoml = this.temp;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            try
            {
                IDesignerHost service = (IDesignerHost) this.GetService(typeof(IDesignerHost));
                if ((service != null) && (service.RootComponent > null))
                {
                    CustomCCSDTWorkflowBase rootComponent = service.RootComponent as CustomCCSDTWorkflowBase;
                    if (rootComponent > null)
                    {
                        string getHtml = rootComponent.GetHtml;
                        new ScreenPopDBConnection().UpdateScreenPop(this.business_unit_display_id, getHtml, this.GetCurrentXoml());
                    }
                }
                MessageBox.Show("Workflow saved.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error saving Workflow" + Environment.NewLine + exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void tsmCopy_Click(object sender, EventArgs e)
        {
            try
            {
                IMenuCommandService service = (IMenuCommandService) this.GetService(typeof(IMenuCommandService));
                if (service > null)
                {
                    service.GlobalInvoke(StandardCommands.Copy);
                }
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (MainForm.tsmCopy_Click) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        private void tsmCut_Click(object sender, EventArgs e)
        {
            try
            {
                IMenuCommandService service = (IMenuCommandService) this.GetService(typeof(IMenuCommandService));
                if (service > null)
                {
                    service.GlobalInvoke(StandardCommands.Cut);
                }
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (MainForm.tsmCut_Click) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            try
            {
                IMenuCommandService service = (IMenuCommandService) this.GetService(typeof(IMenuCommandService));
                if (service > null)
                {
                    service.GlobalInvoke(StandardCommands.Delete);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void tsmPaste_Click(object sender, EventArgs e)
        {
            try
            {
                IMenuCommandService service = (IMenuCommandService) this.GetService(typeof(IMenuCommandService));
                if (service > null)
                {
                    service.GlobalInvoke(StandardCommands.Paste);
                }
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (MainForm.tsmPaste_Click) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        private void tsmRedo_Click(object sender, EventArgs e)
        {
            try
            {
                IMenuCommandService service = (IMenuCommandService) this.GetService(typeof(IMenuCommandService));
                if (service > null)
                {
                    service.GlobalInvoke(StandardCommands.Redo);
                }
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (MainForm.tsmRedo_Click) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        private void tsmSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                IMenuCommandService service = (IMenuCommandService) this.GetService(typeof(IMenuCommandService));
                if (service > null)
                {
                    service.GlobalInvoke(StandardCommands.SelectAll);
                }
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (MainForm.tsmSelectAll_Click) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        private void tsmUndo_Click(object sender, EventArgs e)
        {
            try
            {
                WorkflowMenuCommandService service = (WorkflowMenuCommandService) this.GetService(typeof(IMenuCommandService));
                WorkflowUndoEngine engine = (WorkflowUndoEngine) this.GetService(typeof(UndoEngine));
                if (service > null)
                {
                    service.GlobalInvoke(StandardCommands.Undo);
                }
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (MainForm.tsmUndo_Click) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        private void UnloadWorkflow()
        {
            IDesignerHost service = this.GetService(typeof(IDesignerHost)) as IDesignerHost;
            if ((service != null) && (service.Container.Components.Count > 0))
            {
                WorkflowLoader.DestroyObjectGraphFromDesignerHost(service, service.RootComponent as Activity);
            }
            if (this.designSurface > null)
            {
                this.designSurface.Dispose();
                this.designSurface = null;
            }
            if (this.workflowView > null)
            {
                base.Controls.Remove(this.workflowView);
                this.workflowView.Dispose();
                this.workflowView = null;
            }
        }

        private void UpdateCallData()
        {
        }

        private void workflowRuntime_WorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            this.workflowRuntime.StopRuntime();
            this.workflowRuntime.Dispose();
            this.workflowRuntime = null;
        }

        public List<string> Vals
        {
            get
            {
                return this.vals;
            }
            set
            {
                this.vals = value;
            }
        }

        public string XomlFile
        {
            get
            {
                return this.loader.XomlFile;
            }
            set
            {
                this.loader.XomlFile = value;
            }
        }

        public string Xoml
        {
            get
            {
                string xoml = string.Empty;
                if (this.loader > null)
                {
                    try
                    {
                        this.loader.Flush();
                        xoml = this.loader.Xoml;
                    }
                    catch
                    {
                    }
                }
                return xoml;
            }
            set
            {
                try
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        this.LoadWorkflow(value);
                    }
                }
                catch
                {
                }
            }
        }

        public string WorkflowName
        {
            get
            {
                return ((this.currentWorkflow == null) ? string.Empty : this.currentWorkflow.Name);
            }
        }

        public override ISite Site
        {
            get
            {
                return base.Site;
            }
            set
            {
                base.Site = value;
            }
        }

        public IComponent Component
        {
            get
            {
                return this;
            }
        }

        public bool DesignMode
        {
            get
            {
                return true;
            }
        }

        IContainer ISite.Container
        {
            get
            {
                return base.Container;
            }
        }

        string ISite.Name
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
    }
}

