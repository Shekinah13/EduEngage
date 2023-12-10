using MySql.Data.MySqlClient;
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
    public partial class Form5 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=''");
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            form2.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter your Username and Password", "No Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (MySqlConnection connnection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=''"))
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM eduengage.admin WHERE adminUser = @user AND adminPass = @pass", connection))
                    {
                        cmd.Parameters.AddWithValue("@user", textBox1.Text);
                        cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Form60 form60 = new Form60();
                                form60.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Login Information! Try again.");
                            }
                        }
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
    }
}
