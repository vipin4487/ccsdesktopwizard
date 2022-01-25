namespace CCSDTWorkflowLibrary
{
    using Microsoft.VisualBasic.PowerPacks;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Workflow.Activities;
    using System.Workflow.ComponentModel;

    public class CriteriaEditorDlg : Form
    {
        private SequentialWorkflowActivity workflow;
        private ArrayList criteriaList = null;
        private ArrayList curActivityList = new ArrayList();
        private ArrayList conditionalList = new ArrayList();
        private ArrayList operatorList = new ArrayList();
        private IContainer components = null;
        private Button btnOK;
        private Button btnCancel;
        private DataGridView dgvCriteria;
        private ShapeContainer shapeContainer1;
        private LineShape lineShape1;
        private Button btnAdd;
        private Button btnDelete;
        private Label lblErrorText;
        private HelpProvider helpProvider1;

        public CriteriaEditorDlg(SequentialWorkflowActivity curWorkflow)
        {
            this.InitializeComponent();
            this.workflow = curWorkflow;
        }

        private void AddGridColumns()
        {
            this.dgvCriteria.AutoGenerateColumns = false;
            this.dgvCriteria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCriteria.MultiSelect = false;
            this.dgvCriteria.ShowCellToolTips = true;
            this.dgvCriteria.AllowUserToResizeRows = false;
            this.dgvCriteria.AllowUserToAddRows = false;
            this.dgvCriteria.AllowUserToOrderColumns = false;
            this.dgvCriteria.AllowUserToDeleteRows = true;
            this.dgvCriteria.ShowRowErrors = true;
            this.dgvCriteria.RowHeadersWidth = 0x19;
            DataGridViewComboBoxColumn dataGridViewColumn = new DataGridViewComboBoxColumn {
                HeaderText = "Control To Test",
                Name = "activity",
                Width = 130,
                DataSource = this.curActivityList,
                DataPropertyName = "ActivityName",
                ReadOnly = false,
                ValueType = typeof(string)
            };
            this.dgvCriteria.Columns.Add(dataGridViewColumn);
            DataGridViewComboBoxColumn column2 = new DataGridViewComboBoxColumn {
                HeaderText = "Condition",
                Name = "condition",
                Width = 100,
                DataSource = this.conditionalList,
                DataPropertyName = "Conditional",
                DisplayMember = "DisplayedText",
                ValueMember = "NumericValue",
                ReadOnly = false,
                ValueType = typeof(ConditionalType)
            };
            this.dgvCriteria.Columns.Add(column2);
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn {
                HeaderText = "Value",
                Name = "value",
                Width = 80,
                DataPropertyName = "ValueToTest",
                ReadOnly = false
            };
            this.dgvCriteria.Columns.Add(column3);
            DataGridViewComboBoxColumn column4 = new DataGridViewComboBoxColumn {
                HeaderText = "Operator",
                Name = "operator",
                Width = 0x35,
                DataSource = this.operatorList,
                DataPropertyName = "Operator",
                DisplayMember = "DisplayedText",
                ValueMember = "NumericValue",
                ReadOnly = false,
                ValueType = typeof(OperatorType)
            };
            this.dgvCriteria.Columns.Add(column4);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ArrayList dataSource = (ArrayList) this.dgvCriteria.DataSource;
            if (dataSource == null)
            {
                dataSource = this.criteriaList;
            }
            IfElseCriteria criteria = new IfElseCriteria("Please Select") {
                Conditional = ConditionalType.Equals,
                ValueToTest = "",
                Operator = OperatorType.And
            };
            int num = dataSource.Add(criteria);
            this.dgvCriteria.DataSource = null;
            this.dgvCriteria.DataSource = dataSource;
            if (this.dgvCriteria.Rows.Count > num)
            {
                this.dgvCriteria.ClearSelection();
                this.dgvCriteria.Rows[num].Cells[0].Selected = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvCriteria.SelectedRows.Count > 0)
            {
                this.btnDelete.Enabled = false;
                int index = this.dgvCriteria.SelectedRows[0].Index;
                ArrayList dataSource = (ArrayList) this.dgvCriteria.DataSource;
                dataSource.RemoveAt(index);
                this.dgvCriteria.DataSource = null;
                this.dgvCriteria.DataSource = dataSource;
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
                else if (activity is ValidateButton)
                {
                    ValidateButton button = activity as ValidateButton;
                    if ((button != null) && (button.OutputParameters > null))
                    {
                        foreach (ValidateOutputParameter parameter in button.OutputParameters)
                        {
                            if ((parameter.ParameterName != null) && (parameter.ParameterName.Length > 0))
                            {
                                this.curActivityList.Add(activity.Name + "_" + parameter.ParameterName);
                            }
                        }
                    }
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

        private void CreateCondionalDataSource()
        {
            this.conditionalList.Clear();
            foreach (ConditionalType type in Enum.GetValues(typeof(ConditionalType)))
            {
                this.conditionalList.Add(new ConditionalDropdownListObj(type, type.ToString()));
            }
        }

        private void CreateOperatorDataSource()
        {
            this.operatorList.Clear();
            foreach (OperatorType type in Enum.GetValues(typeof(OperatorType)))
            {
                this.operatorList.Add(new OperatorDropdownListObj(type, type.ToString()));
            }
        }

        private void CriteriaEditorDlg_Load(object sender, EventArgs e)
        {
            this.curActivityList.Add("Please Select");
            this.CreateActivityDataSource(this.workflow.Activities);
            this.CreateCondionalDataSource();
            this.CreateOperatorDataSource();
            this.AddGridColumns();
            if (this.criteriaList == null)
            {
                this.criteriaList = new ArrayList();
            }
            else if (this.criteriaList.Count > 0)
            {
                this.dgvCriteria.DataSource = this.criteriaList;
            }
            this.btnDelete.Enabled = this.dgvCriteria.SelectedRows.Count > 0;
        }

        private void CriteriaEditorDlg_Resize(object sender, EventArgs e)
        {
            if ((base.ClientSize.Width > (this.dgvCriteria.Left + 10)) && (base.ClientSize.Height > (this.dgvCriteria.Top + 10)))
            {
                this.dgvCriteria.Height = base.ClientSize.Height - (this.dgvCriteria.Top + 0x3a);
                this.dgvCriteria.Width = base.ClientSize.Width - 20;
                this.lineShape1.set_X2(base.ClientSize.Width);
                this.lineShape1.set_Y1(this.dgvCriteria.Bottom + 15);
                this.lineShape1.set_Y2(this.dgvCriteria.Bottom + 15);
                this.btnCancel.Top = this.dgvCriteria.Bottom + 0x19;
                this.btnCancel.Left = this.dgvCriteria.Right - this.btnCancel.Width;
                this.btnOK.Top = this.dgvCriteria.Bottom + 0x19;
                this.btnOK.Left = this.btnCancel.Left - (this.btnOK.Width + 6);
                this.lblErrorText.Top = this.lineShape1.get_Y1() + 10;
            }
        }

        private void dgvCriteria_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.lblErrorText.Text = e.Exception.Message;
        }

        private void dgvCriteria_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvCriteria.SelectedRows == null)
            {
                this.btnDelete.Enabled = false;
            }
            else
            {
                this.btnDelete.Enabled = this.dgvCriteria.SelectedRows.Count > 0;
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

        private void InitializeComponent()
        {
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.dgvCriteria = new DataGridView();
            this.shapeContainer1 = new ShapeContainer();
            this.lineShape1 = new LineShape();
            this.btnAdd = new Button();
            this.btnDelete = new Button();
            this.lblErrorText = new Label();
            this.helpProvider1 = new HelpProvider();
            ((ISupportInitialize) this.dgvCriteria).BeginInit();
            base.SuspendLayout();
            this.btnOK.DialogResult = DialogResult.OK;
            this.helpProvider1.SetHelpString(this.btnOK, "Click to close the editor, saving any changes.");
            this.btnOK.Location = new Point(0xf6, 0xb2);
            this.btnOK.Name = "btnOK";
            this.helpProvider1.SetShowHelp(this.btnOK, true);
            this.btnOK.Size = new Size(0x4b, 0x17);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.helpProvider1.SetHelpString(this.btnCancel, "Click to close the editor, without saving changes.");
            this.btnCancel.Location = new Point(0x147, 0xb2);
            this.btnCancel.Name = "btnCancel";
            this.helpProvider1.SetShowHelp(this.btnCancel, true);
            this.btnCancel.Size = new Size(0x4b, 0x17);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.dgvCriteria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.helpProvider1.SetHelpString(this.dgvCriteria, "List of criteria to test for the IfElseBranch.  ");
            this.dgvCriteria.Location = new Point(10, 0x27);
            this.dgvCriteria.Name = "dgvCriteria";
            this.helpProvider1.SetShowHelp(this.dgvCriteria, true);
            this.dgvCriteria.Size = new Size(390, 0x74);
            this.dgvCriteria.TabIndex = 3;
            this.dgvCriteria.DataError += new DataGridViewDataErrorEventHandler(this.dgvCriteria_DataError);
            this.dgvCriteria.SelectionChanged += new EventHandler(this.dgvCriteria_SelectionChanged);
            this.shapeContainer1.Location = new Point(0, 0);
            this.shapeContainer1.Margin = new Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            Shape[] shapeArray1 = new Shape[] { this.lineShape1 };
            this.shapeContainer1.get_Shapes().AddRange(shapeArray1);
            this.shapeContainer1.Size = new Size(0x19c, 210);
            this.shapeContainer1.TabIndex = 4;
            this.shapeContainer1.TabStop = false;
            this.lineShape1.set_Name("lineShape1");
            this.lineShape1.set_X1(0);
            this.lineShape1.set_X2(0x1a0);
            this.lineShape1.set_Y1(0xa8);
            this.lineShape1.set_Y2(0xa8);
            this.helpProvider1.SetHelpString(this.btnAdd, "Click to add a new criteria to the list.");
            this.btnAdd.Location = new Point(10, 10);
            this.btnAdd.Name = "btnAdd";
            this.helpProvider1.SetShowHelp(this.btnAdd, true);
            this.btnAdd.Size = new Size(0x4b, 0x17);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            this.helpProvider1.SetHelpString(this.btnDelete, "Click to delete the selected criteria from the list.");
            this.btnDelete.Location = new Point(0x5e, 10);
            this.btnDelete.Name = "btnDelete";
            this.helpProvider1.SetShowHelp(this.btnDelete, true);
            this.btnDelete.Size = new Size(0x4b, 0x17);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            this.lblErrorText.AutoSize = true;
            this.lblErrorText.ForeColor = Color.Red;
            this.lblErrorText.Location = new Point(12, 0xb2);
            this.lblErrorText.Name = "lblErrorText";
            this.lblErrorText.Size = new Size(0, 13);
            this.lblErrorText.TabIndex = 7;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x19c, 210);
            base.Controls.Add(this.lblErrorText);
            base.Controls.Add(this.btnDelete);
            base.Controls.Add(this.btnAdd);
            base.Controls.Add(this.dgvCriteria);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.shapeContainer1);
            base.HelpButton = true;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            this.MinimumSize = new Size(300, 200);
            base.Name = "CriteriaEditorDlg";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Criteria Editor";
            base.Load += new EventHandler(this.CriteriaEditorDlg_Load);
            base.Resize += new EventHandler(this.CriteriaEditorDlg_Resize);
            ((ISupportInitialize) this.dgvCriteria).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        public ArrayList CriteriaList
        {
            get
            {
                if ((this.criteriaList != null) && (this.criteriaList.Count == 0))
                {
                    return null;
                }
                return this.criteriaList;
            }
            set
            {
                if (value > null)
                {
                    this.criteriaList = new ArrayList();
                    foreach (IfElseCriteria criteria in value)
                    {
                        IfElseCriteria criteria2 = new IfElseCriteria {
                            ActivityName = criteria.ActivityName,
                            Conditional = criteria.Conditional,
                            Operator = criteria.Operator,
                            ValueToTest = criteria.ValueToTest
                        };
                        this.criteriaList.Add(criteria2);
                    }
                }
            }
        }
    }
}

