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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 mostrar = new Form1();
            mostrar.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 mostrar = new Form3();
            mostrar.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 mostrar = new Form7();
            mostrar.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 mostrar = new Form4();
            mostrar.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 mostrar = new Form5();
            mostrar.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 mostrar = new Form6();
            mostrar.ShowDialog();
        }
    }
}
