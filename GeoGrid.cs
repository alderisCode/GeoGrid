using System.Windows.Forms;

namespace GeoGrid_test
{
    public class GeoGrid : System.Windows.Forms.DataGridView
    {

        public bool FixedRowsCount = false;

        public GeoGrid()
        {
            
        }

        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {
            base.OnCellEndEdit(e);
            
            if (e.ColumnIndex <= this.ColumnCount)  //jeśli to nie ostatnia kolumna
            {
                this.CurrentCell = this[e.ColumnIndex+1, e.RowIndex];
            }

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
