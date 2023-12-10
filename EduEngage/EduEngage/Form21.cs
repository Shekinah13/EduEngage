using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EduEngage
{
    public partial class Form21 : Form
    {
        public Form21()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form23 form23 = new Form23();
            form23.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form29 form29 = new Form29();
            form29.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form37 form37 = new Form37();
            form37.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form22 form22 = new Form22();
            form22.Show();
            this.Hide();
        }
    }
}
