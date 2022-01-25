namespace WWELib
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class CallVariablesGridView : DataGridView
    {
        public void SetCallVariablesGridColumns()
        {
            try
            {
                base.Columns.Clear();
                base.CausesValidation = false;
                base.EnableHeadersVisualStyles = false;
                base.MultiSelect = false;
                int num = base.Columns.Add("variableName", "Variable Name");
                base.Columns[num].Visible = true;
                base.Columns[num].Width = 100;
                base.Columns[num].ReadOnly = true;
                base.Columns[num].SortMode = DataGridViewColumnSortMode.NotSortable;
                base.Columns[num].Resizable = DataGridViewTriState.True;
                int num2 = base.Columns.Add("variableValue", "Value");
                base.Columns[num2].Visible = true;
                base.Columns[num2].Width = 200;
                base.Columns[num2].SortMode = DataGridViewColumnSortMode.NotSortable;
                base.Columns[num2].Resizable = DataGridViewTriState.True;
                base.ColumnHeadersDefaultCellStyle.Font = new Font(this.Font, FontStyle.Bold);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

