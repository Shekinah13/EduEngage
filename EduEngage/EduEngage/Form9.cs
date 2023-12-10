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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form2 form2 = new Form2();
                this.Hide();
                form2.ShowDialog();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form48 form48 = new Form48();
            form48.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form49 form49 = new Form49();
            form49.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form54 form54 = new Form54();
            form54.Show();
            this.Hide();
        }
    }
}
