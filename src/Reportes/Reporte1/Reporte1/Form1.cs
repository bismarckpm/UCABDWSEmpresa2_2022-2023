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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public string nombre_dep { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            nombre_dep = Convert.ToString(textBox1.Text);
            // TODO: This line of code loads data into the 'gestionBDDataSet.ReportesReque' table. You can move, or remove it, as needed.
            this.reportesRequeTableAdapter.Fill(this.gestionBDDataSet1.ReportesReque,nombre_dep);

            this.reportViewer1.RefreshReport();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
