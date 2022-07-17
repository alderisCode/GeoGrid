using System;
using System.Windows.Forms;

namespace GeoGrid_test
{
    public class GeoGrid : System.Windows.Forms.DataGridView
    {

        public bool FixedRowsCount = false;


        // Źródło: https://social.msdn.microsoft.com/Forums/en-US/359fb658-57ae-438c-b6c8-4be213a20dd5/change-default-quotenterquot-key-behavior-in-datagridview?forum=csharplanguage
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.CurrentCell.ColumnIndex < ColumnCount - 1)
                {
                    this.CurrentCell = this.Rows[this.CurrentCell.RowIndex].Cells[this.CurrentCell.ColumnIndex + 1];
                    return true;
                }
                else
                {
                    try
                    {
                        this.CurrentCell = this.Rows[this.CurrentCell.RowIndex + 1].Cells[0];
                        return true;
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        return true;
                    }

                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        public void SetFixedRows(int rCount)
        {
            this.Rows.Clear();
            for (int i = 0; i<rCount; i++)
            {
                this.Rows.Add("");
            }
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = false;

            FixedRowsCount = true;
        }

        
    }
}
