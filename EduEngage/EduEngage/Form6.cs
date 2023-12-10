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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            Form49 form49 = new Form49();
            form49.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
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
    }
}
