using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reporte1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gestionBDDataSet7.ReportesReque5' table. You can move, or remove it, as needed.
            this.reportesReque5TableAdapter.Fill(this.gestionBDDataSet7.ReportesReque5);

            this.reportViewer1.RefreshReport();
        }
    }
}
