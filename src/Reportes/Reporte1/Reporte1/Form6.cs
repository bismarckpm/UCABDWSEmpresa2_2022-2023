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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        private void Form6_Load(object sender, EventArgs e)
        {
        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            fecha_inicio = Convert.ToDateTime(textBox1.Text);
            fecha_fin= Convert.ToDateTime(textBox2.Text);
            // TODO: This line of code loads data into the 'gestionBDDataSet8.ReportesReque6' table. You can move, or remove it, as needed.
            this.reportesReque6TableAdapter.Fill(this.gestionBDDataSet8.ReportesReque6,fecha_inicio,fecha_fin);

            this.reportViewer1.RefreshReport();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
