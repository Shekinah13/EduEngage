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
    public partial class Form4 : Form
    {
       MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=''");
        public Form4()
        {
            InitializeComponent();
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        #region
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
      
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text)
       || string.IsNullOrEmpty(textBox4.Text)
       || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Please fill out all information!", "Error");
                return;
            }
            else if (textBox5.Text != textBox6.Text)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }
            else
            {
                connection.Open();
                MySqlCommand cm = new MySqlCommand("SELECT * FROM eduengage.user_information WHERE Username = @User", connection);
                cm.Parameters.AddWithValue("@User", textBox5.Text);
                bool userExists = false;

                using (var dr1 = cm.ExecuteReader())
                {
                    userExists = dr1.HasRows;
                    if (userExists)
                    {
                        MessageBox.Show("Username is already in use, please choose a different username");
                    }
                }

                if (!userExists)
                {
                    string query = "INSERT INTO eduengage.user_information(FirstName,LastName,Birthdate,EmailAddress,Username,Password) VALUES " +
                                   "(@Fname, @Lname, @Bday, @Email, @User, @Pass)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Fname", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Lname", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Bday", dateTimePicker1.Value); // Assuming dateTimePicker1 is a DateTimePicker control
                    cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                    cmd.Parameters.AddWithValue("@User", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Pass", textBox5.Text);

                    try
                    {
                        // Reaching the datasets from the SQL Database
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        // Show any error message.
                        MessageBox.Show(ex.Message);
                        connection.Close();
                    }
                    textBox1.Clear();
                    textBox2.Clear();
                    dateTimePicker1.Value = DateTime.Now; // Reset the DateTimePicker to the current date/time
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();


                    MessageBox.Show("Account Successfully Created!");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel your registration?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

