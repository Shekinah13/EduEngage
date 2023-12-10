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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form61 form61 = new Form61();
            form61.Show();
            this.Hide();
        }

        private void button4_Click_2(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            Form49 form49 = new Form49();
            form49.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form58 form58 = new Form58();
            form58.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form51 form51 = new Form51();
            form51.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form52 form52 = new Form52();
            form52.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form56 form56 = new Form56();
            form56.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form47 form47 = new Form47();
            form47.Show();
            this.Hide();
        }
    }
}
