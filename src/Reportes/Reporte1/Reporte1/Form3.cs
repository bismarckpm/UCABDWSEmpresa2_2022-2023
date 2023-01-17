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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
         public string nombre_dep { get; set; }
        public string estado{ get; set; }
        private void Form3_Load(object sender, EventArgs e)
        {
     

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nombre_dep = Convert.ToString(textBox1.Text);
            estado = Convert.ToString(textBox2.Text);
            // TODO: This line of code loads data into the 'gestionBDDataSet5.ReportesReque2' table. You can move, or remove it, as needed.
            this.reportesReque2TableAdapter.Fill(this.gestionBDDataSet5.ReportesReque2, nombre_dep, estado);

            this.reportViewer1.RefreshReport();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
