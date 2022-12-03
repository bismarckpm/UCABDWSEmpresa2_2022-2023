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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        public int dias { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            dias = Convert.ToInt16(textBox1.Text);
            // TODO: This line of code loads data into the 'gestionBDDataSet6.ReportesReque4' table. You can move, or remove it, as needed.
            this.reportesReque4TableAdapter.Fill(this.gestionBDDataSet6.ReportesReque4,dias);

            this.reportViewer1.RefreshReport();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
