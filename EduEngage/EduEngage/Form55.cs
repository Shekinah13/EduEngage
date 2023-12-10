﻿using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EduEngage
{
    public partial class Score : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=''");
       
        public Score(int correctCount, int totalWords)
        {
            InitializeComponent();
            string result = $"{correctCount}";
            int.Parse(result);
            label1.Text = result;
            label3.Text = Form3.username;
        }

        private void insert()
        {

            try
            {
                connection.Open();

                string query = "SELECT ID FROM eduengage.user_information WHERE Username = @User";

                using (MySqlCommand com = new MySqlCommand(query, connection))
                {
                    com.Parameters.AddWithValue("@User", label3.Text);

                    // ExecuteScalar is used to retrieve a single value (in this case, an integer) from the database
                    object result = com.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        // Assuming 'result' is an integer, you can convert it to a string and display it in label
                        label4.Text = result.ToString();
                    }
                    else
                    {
                        // Handle the case where no data is found for the specified user
                        MessageBox.Show("No user ID found for the specified user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log and display any errors
                Console.WriteLine($"Error retrieving user ID: {ex}");
                MessageBox.Show("An error occurred while retrieving user ID. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }


            try
            {
                connection.Open();

                // Validate and parse the label text as an integer
                if (int.TryParse(label1.Text, out int score))
                {
                    string query = "INSERT INTO eduengage.crosswordPuzzle1(crossPuzzle1_score, Username, ID) VALUES (@score, @User, @id)";

                    using (MySqlCommand com = new MySqlCommand(query, connection))
                    {
                        com.Parameters.AddWithValue("@score", label1.Text);
                        com.Parameters.AddWithValue("@User", label3.Text);
                        com.Parameters.AddWithValue("@id", int.Parse(label4.Text));

                        com.ExecuteNonQuery();
                    }
                }
                else
                {
                    // Handle the case where label1.Text is not a valid integer
                    MessageBox.Show("Invalid score format. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Log the error for further analysis
                Console.WriteLine($"Error inserting data: {ex}");
                MessageBox.Show("An error occurred while inserting data. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
            finally
            {
                connection.Close();
            }
        }

        private void submitButton_Click_1(object sender, EventArgs e)
        {
            insert();


            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }
    }
}
