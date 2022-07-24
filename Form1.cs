using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoGrid_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //GeoGrid gg = new GeoGrid();
            //gg.Parent = splitContainer1.Panel1;
            //gg.Dock = DockStyle.Fill;

            //geoGrid1.SetFixedRows(3);
            geoGrid1.ReadOnlyColumnBackground = Color.LavenderBlush;
            geoGrid1.Columns[4].DefaultCellStyle.BackColor = Color.LightSteelBlue;

        }

        void getCellCoords()
        {
            lbRow.Text = geoGrid1.CurrentCell.RowIndex.ToString();
            lbCol.Text = geoGrid1.CurrentCell.ColumnIndex.ToString();
            Application.DoEvents();
        }


        private void geoGrid1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //getCellCoords();
        }

        private void geoGrid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //getCellCoords();
        }

        private void geoGrid1_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //getCellCoords();
        }

        private void geoGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            //getCellCoords();
        }

        private void geoGrid1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //
        }
    }
}
