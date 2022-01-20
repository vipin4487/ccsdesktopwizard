namespace CCSDTWorkflowLibrary
{
    using Microsoft.VisualBasic.PowerPacks;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Workflow.ComponentModel;

    public class ParameterEditorDlg : Form
    {
        private CustomCCSDTWorkflowBase workflow;
        private bool outputParams = false;
        private ArrayList parameterList = null;
        private ArrayList curActivityList = new ArrayList();
        private ArrayList callVarList = new ArrayList();
        private IContainer components = null;
        private Button btnDelete;
        private Button btnAdd;
        private DataGridView dgvParameters;
        private Button btnCancel;
        private Button btnOK;
        private LineShape lineShape1;
        private ShapeContainer shapeContainer1;
        private Label lblErrorText;
        private HelpProvider helpProvider1;

        public ParameterEditorDlg(CustomCCSDTWorkflowBase curWorkflow, bool outputParameters)
        {
            this.InitializeComponent();
            this.workflow = curWorkflow;
            this.outputParams = outputParameters;
        }

        private void AddGridColumns()
        {
            this.dgvParameters.AutoGenerateColumns = false;
            this.dgvParameters.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvParameters.MultiSelect = false;
            this.dgvParameters.ShowCellToolTips = true;
            this.dgvParameters.AllowUserToResizeRows = false;
            this.dgvParameters.AllowUserToAddRows = false;
            this.dgvParameters.AllowUserToOrderColumns = false;
            this.dgvParameters.AllowUserToDeleteRows = true;
            this.dgvParameters.ShowRowErrors = true;
            this.dgvParameters.RowHeadersWidth = 0x19;
            DataGridViewTextBoxColumn dataGridViewColumn = new DataGridViewTextBoxColumn {
                HeaderText = "Name",
                Name = "parameterName",
                Width = 120,
                DataPropertyName = "ParameterName",
                ReadOnly = false
            };
            this.dgvParameters.Columns.Add(dataGridViewColumn);
            if (!this.outputParams)
            {
                DataGridViewComboBoxColumn column3 = new DataGridViewComboBoxColumn {
                    HeaderText = "Control Source",
                    Name = "activity",
                    Width = 120,
                    DataSource = this.curActivityList,
                    DataPropertyName = "ActivityName",
                    ReadOnly = false,
                    ValueType = typeof(string)
                };
                this.dgvParameters.Columns.Add(column3);
            }
            else
            {
                DataGridViewComboBoxColumn column4 = new DataGridViewComboBoxColumn {
                    HeaderText = "Destination Control",
                    Name = "destinationControl",
                    Width = 120,
                    DataSource = this.curActivityList,
                    DataPropertyName = "DestinationControl",
                    ReadOnly = false,
                    ValueType = typeof(string)
                };
                this.dgvParameters.Columns.Add(column4);
            }
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            if (this.outputParams)
            {
                column2.HeaderText = "Initial Value";
                column2.DataPropertyName = "InitialValue";
            }
            else
            {
                column2.HeaderText = "Static Value";
                column2.DataPropertyName = "StaticValue";
            }
            column2.Name = "value";
            column2.Width = 0x5e;
            column2.ReadOnly = false;
            this.dgvParameters.Columns.Add(column2);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ArrayList dataSource = (ArrayList) this.dgvParameters.DataSource;
            if (ReferenceEquals(dataSource, null))
            {
                dataSource = this.parameterList;
            }
            int num = -1;
            if (this.outputParams)
            {
                ValidateOutputParameter parameter = new ValidateOutputParameter {
                    ParameterName = "",
                    InitialValue = ""
                };
                num = dataSource.Add(parameter);
            }
            else
            {
                ValidateInputParameter parameter2 = new ValidateInputParameter {
                    ParameterName = "",
                    ActivityName = "{Static}",
                    StaticValue = "",
                    IsAStaticValue = true
                };
                num = dataSource.Add(parameter2);
            }
            this.dgvParameters.DataSource = null;
            this.dgvParameters.DataSource = dataSource;
            if (this.dgvParameters.Rows.Count > num)
            {
                this.dgvParameters.ClearSelection();
                this.dgvParameters.Rows[num].Cells[0].Selected = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvParameters.SelectedRows.Count > 0)
            {
                this.btnDelete.Enabled = false;
                ArrayList dataSource = (ArrayList) this.dgvParameters.DataSource;
                dataSource.RemoveAt(this.dgvParameters.SelectedRows[0].Index);
                this.dgvParameters.DataSource = null;
                this.dgvParameters.DataSource = dataSource;
            }
        }

        private void CreateActivityDataSource(ActivityCollection childActivites)
        {
            foreach (Activity activity in childActivites)
            {
                if (activity is GUIElement)
                {
                    this.curActivityList.Add(activity.Name);
                }
                else if ((activity is ButtonBase) && (activity is WarmConferenceButton))
                {
                    this.curActivityList.Add(activity.Name);
                }
                if (activity.GetType() == typeof(IfElseTest))
                {
                    IfElseTest test = (IfElseTest) activity;
                    this.CreateActivityDataSource(test.Activities);
                }
                else if (activity.GetType() == typeof(IfElseBranch))
                {
                    IfElseBranch branch = (IfElseBranch) activity;
                    this.CreateActivityDataSource(branch.Activities);
                }
            }
        }

        private void CreateCallVarDataSource()
        {
            this.callVarList.Clear();
            foreach (string str in this.workflow.CallVariableNames)
            {
                this.callVarList.Add(str);
            }
        }

        private void dgvParameters_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.lblErrorText.Text = e.Exception.Message;
        }

        private void dgvParameters_SelectionChanged(object sender, EventArgs e)
        {
            this.btnDelete.Enabled = !ReferenceEquals(this.dgvParameters.SelectedRows, null) ? (this.dgvParameters.SelectedRows.Count > 0) : false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnDelete = new Button();
            this.btnAdd = new Button();
            this.dgvParameters = new DataGridView();
            this.btnCancel = new Button();
            this.btnOK = new Button();
            this.lineShape1 = new LineShape();
            this.shapeContainer1 = new ShapeContainer();
            this.lblErrorText = new Label();
            this.helpProvider1 = new HelpProvider();
            ((ISupportInitialize) this.dgvParameters).BeginInit();
            base.SuspendLayout();
            this.helpProvider1.SetHelpString(this.btnDelete, "Click to delete the selected criteria from the list.");
            this.btnDelete.Location = new Point(0x5e, 10);
            this.btnDelete.Name = "btnDelete";
            this.helpProvider1.SetShowHelp(this.btnDelete, true);
            this.btnDelete.Size = new Size(0x4b, 0x17);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            this.helpProvider1.SetHelpString(this.btnAdd, "Click to add a new criteria to the list.");
            this.btnAdd.Location = new Point(10, 10);
            this.btnAdd.Name = "btnAdd";
            this.helpProvider1.SetShowHelp(this.btnAdd, true);
            this.btnAdd.Size = new Size(0x4b, 0x17);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            this.dgvParameters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParameters.Location = new Point(10, 0x27);
            this.dgvParameters.Name = "dgvParameters";
            this.dgvParameters.Size = new Size(0x169, 0x74);
            this.dgvParameters.TabIndex = 3;
            this.dgvParameters.DataError += new DataGridViewDataErrorEventHandler(this.dgvParameters_DataError);
            this.dgvParameters.SelectionChanged += new EventHandler(this.dgvParameters_SelectionChanged);
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(0x128, 0xb2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x4b, 0x17);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Location = new Point(0xd7, 0xb2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(0x4b, 0x17);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.lineShape1.set_Name("lineShape1");
            this.lineShape1.set_X1(-1);
            this.lineShape1.set_X2(0x19f);
            this.lineShape1.set_Y1(0xa8);
            this.lineShape1.set_Y2(0xa8);
            this.shapeContainer1.Location = new Point(0, 0);
            this.shapeContainer1.Margin = new Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            Shape[] shapeArray1 = new Shape[] { this.lineShape1 };
            this.shapeContainer1.get_Shapes().AddRange(shapeArray1);
            this.shapeContainer1.Size = new Size(0x17e, 0xd1);
            this.shapeContainer1.TabIndex = 11;
            this.shapeContainer1.TabStop = false;
            this.lblErrorText.AutoSize = true;
            this.lblErrorText.ForeColor = Color.Red;
            this.lblErrorText.Location = new Point(12, 0xb2);
            this.lblErrorText.Name = "lblErrorText";
            this.lblErrorText.Size = new Size(0, 13);
            this.lblErrorText.TabIndex = 12;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x17e, 0xd1);
            base.Controls.Add(this.lblErrorText);
            base.Controls.Add(this.btnDelete);
            base.Controls.Add(this.btnAdd);
            base.Controls.Add(this.dgvParameters);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.shapeContainer1);
            base.HelpButton = true;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "ParameterEditorDlg";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Parameter Editor";
            base.Load += new EventHandler(this.ParameterEditorDlg_Load);
            base.Resize += new EventHandler(this.ParameterEditorDlg_Resize);
            ((ISupportInitialize) this.dgvParameters).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void ParameterEditorDlg_Load(object sender, EventArgs e)
        {
            this.curActivityList.Add("{Static}");
            this.CreateActivityDataSource(this.workflow.Activities);
            this.CreateCallVarDataSource();
            this.AddGridColumns();
            if (ReferenceEquals(this.parameterList, null))
            {
                this.parameterList = new ArrayList();
            }
            else if (this.parameterList.Count > 0)
            {
                this.dgvParameters.DataSource = this.parameterList;
            }
            this.btnDelete.Enabled = this.dgvParameters.SelectedRows.Count > 0;
        }

        private void ParameterEditorDlg_Resize(object sender, EventArgs e)
        {
            if ((base.ClientSize.Width > (this.dgvParameters.Left + 10)) && (base.ClientSize.Height > (this.dgvParameters.Top + 10)))
            {
                this.dgvParameters.Height = base.ClientSize.Height - (this.dgvParameters.Top + 0x3a);
                this.dgvParameters.Width = base.ClientSize.Width - 20;
                this.lineShape1.set_X2(base.ClientSize.Width);
                this.lineShape1.set_Y1(this.dgvParameters.Bottom + 15);
                this.lineShape1.set_Y2(this.dgvParameters.Bottom + 15);
                this.btnCancel.Top = this.dgvParameters.Bottom + 0x19;
                this.btnCancel.Left = this.dgvParameters.Right - this.btnCancel.Width;
                this.btnOK.Top = this.dgvParameters.Bottom + 0x19;
                this.btnOK.Left = this.btnCancel.Left - (this.btnOK.Width + 6);
                this.lblErrorText.Top = this.lineShape1.get_Y1() + 10;
            }
        }

        public ArrayList ParameterList
        {
            get => 
                ((this.parameterList == null) || (this.parameterList.Count != 0)) ? this.parameterList : null;
            set
            {
                if (value != null)
                {
                    this.parameterList = new ArrayList();
                    foreach (object obj2 in value)
                    {
                        if (!(obj2.GetType() == typeof(ValidateInputParameter)))
                        {
                            ValidateOutputParameter parameter3 = (ValidateOutputParameter) obj2;
                            ValidateOutputParameter parameter4 = new ValidateOutputParameter {
                                DestinationControl = parameter3.DestinationControl,
                                InitialValue = parameter3.InitialValue,
                                ParameterName = parameter3.ParameterName
                            };
                            this.parameterList.Add(parameter4);
                            continue;
                        }
                        ValidateInputParameter parameter = (ValidateInputParameter) obj2;
                        ValidateInputParameter parameter2 = new ValidateInputParameter {
                            ActivityName = parameter.ActivityName,
                            IsAStaticValue = parameter.IsAStaticValue,
                            ParameterName = parameter.ParameterName,
                            StaticValue = parameter.StaticValue
                        };
                        this.parameterList.Add(parameter2);
                    }
                }
            }
        }
    }
}

