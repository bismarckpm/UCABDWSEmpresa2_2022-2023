using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Reporte1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        public int cedula { get; set; }
        private void Form7_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {

            cedula = Convert.ToInt32(textBox1.Text);
            // TODO: This line of code loads data into the 'gestionBDDataSet9.ReportesReque3' table. You can move, or remove it, as needed.
            this.reportesReque3TableAdapter.Fill(this.gestionBDDataSet9.ReportesReque3, cedula);

            this.reportViewer1.RefreshReport();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
