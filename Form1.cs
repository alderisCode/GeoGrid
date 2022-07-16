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

            geoGrid1.SetFixedRows(3);

        }
    }
}
