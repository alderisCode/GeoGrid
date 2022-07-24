using System;
using System.Drawing;
using System.Windows.Forms;

namespace GeoGrid_test
{
    public class GeoGrid : System.Windows.Forms.DataGridView
    {

        public bool FixedRowsCount = false;
        public Color ReadOnlyColumnBackground = Color.LightGray;


        // Źródło: https://social.msdn.microsoft.com/Forums/en-US/359fb658-57ae-438c-b6c8-4be213a20dd5/change-default-quotenterquot-key-behavior-in-datagridview?forum=csharplanguage
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.CurrentCell.ColumnIndex < ColumnCount - 1)
                {
                    for (int i=this.CurrentCell.ColumnIndex+1; i<ColumnCount; i++)
                    {
                        if (!this.Rows[this.CurrentCell.RowIndex].Cells[i].ReadOnly)
                        {
                            this.CurrentCell = this.Rows[this.CurrentCell.RowIndex].Cells[i];
                            return true;
                        }
                    }
                }
                
                try
                {
                    for (int i = 0; i < ColumnCount; i++)
                    {
                        if (!this.Rows[this.CurrentCell.RowIndex + 1].Cells[i].ReadOnly)
                        {
                            this.CurrentCell = this.Rows[this.CurrentCell.RowIndex + 1].Cells[i];
                            return true;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    return true;
                }

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            base.OnCellFormatting(e);

            // format kolumn readOnly
            for (int i = 0; i < this.ColumnCount; i++)
            {
                if (this.Columns[i].ReadOnly)
                {
                    this.Columns[i].DefaultCellStyle.BackColor = ReadOnlyColumnBackground;
                }
            }
        }

        protected override void OnRowEnter(DataGridViewCellEventArgs e)
        {
            base.OnRowEnter(e);
            if (this.Columns[e.ColumnIndex].ReadOnly)

            {
                SendKeys.Send("{ENTER}");
            }

        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            //if (this.CurrentCell.ReadOnly)
            //{
            //    SendKeys.Send("{ENTER}");
            //}
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
