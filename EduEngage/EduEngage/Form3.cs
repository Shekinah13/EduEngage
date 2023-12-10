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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EduEngage
{
    public partial class Form3 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=''");
        
        public static string username = "";

        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            

        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            username = textBox1.Text;

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter your Username and Password", "No Value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (MySqlConnection connnection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=''"))
                {
                    connection.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM eduengage.user_information WHERE Username = @user AND Password = @pass", connection))
                    {
                        cmd.Parameters.AddWithValue("@user", textBox1.Text);
                        cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Form6 form6 = new Form6();
                                form6.ShowDialog();

                                // Pass the username to Form55 (Score)



                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Login Information! Try again.");
                                connection.Close();
                            }
                        }
                    }
                }
            }
        }
    }
}
