using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EduEngage
{
    public partial class Form61 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=''");

        public Form61()
        {
            InitializeComponent();
            label1.Text = Form3.username;
        }

        public void DisplayScore()
        {
            string userInformationQuery = "";
            try
            {
                connection.Open();

                // Retrieve user ID
                string userIdQuery = "SELECT ID FROM eduengage.user_information WHERE Username = @User";

                using (MySqlCommand getUserIdCommand = new MySqlCommand(userIdQuery, connection))
                {
                    getUserIdCommand.Parameters.AddWithValue("@User", label1.Text);

                    object result = getUserIdCommand.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        // Assuming 'result' is an integer, you can convert it to a string and display it in the label
                        label2.Text = result.ToString();
                    }
                    else
                    {
                        MessageBox.Show("No user ID found for the specified user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return; // Exit the method if no user ID is found
                    }
                }

                switch (comboBox1.Text)
                {
                    case "Score Quiz #1":
                        userInformationQuery = "SELECT crossPuzzle1_id, crossPuzzle1_score, Username, quiz_date FROM eduengage.crosswordpuzzle1 WHERE Username = @username";
                        break;
                    case "Score Quiz #3":
                        userInformationQuery = "SELECT crossPuzzle2_id, crossPuzzle2_score, Username, quiz_date FROM eduengage.crosswordpuzzle2 WHERE Username = @username";
                        break;
                    case "Score Quiz #4":
                        userInformationQuery = "SELECT guessingGame1_id, guessingGame1_score, Username, quiz_date FROM eduengage.guessinggame1 WHERE Username = @username";
                        break;
                    case "Score Quiz #5":
                        userInformationQuery = "SELECT guessingGame2_id, guessingGame2_score, Username, quiz_date FROM eduengage.guessinggame2 WHERE Username = @username";
                        break;
                    case "Score Quiz #2":
                        userInformationQuery = "SELECT multipleChoice_id, multipleChoice_score, Username, quiz_date FROM eduengage.multiplechoice WHERE Username = @username";
                        break;
                    default:
                        // Handle other cases or provide a default query
                        MessageBox.Show("Invalid quiz selection");
                        return; // Exit the method or handle the default case appropriately
                }

                if (!string.IsNullOrEmpty(label2.Text))
                {
                    using (MySqlCommand com = new MySqlCommand(userInformationQuery, connection))
                    {
                        com.Parameters.AddWithValue("@username", label1.Text);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(com))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            // Bind the DataTable to the DataGridView
                            dataGridView1.DataSource = dataTable;
                        }
                        dataGridView1.Columns["Username"].HeaderText = "USERNAME";
                        dataGridView1.Columns["quiz_date"].HeaderText = "DATE";


                        switch (comboBox1.Text)
                        {
                            case "Score Quiz #1":
                                dataGridView1.Columns["crossPuzzle1_id"].HeaderText = "ID";
                                dataGridView1.Columns["crossPuzzle1_score"].HeaderText = "SCORE";

                                break;
                            case "Score Quiz #3":
                                dataGridView1.Columns["crossPuzzle2_id"].HeaderText = "ID";
                                dataGridView1.Columns["crossPuzzle2_score"].HeaderText = "SCORE";
                                break;
                            case "Score Quiz #4":
                                dataGridView1.Columns["guessingGame1_id"].HeaderText = "ID";
                                dataGridView1.Columns["guessingGame1_score"].HeaderText = "SCORE";
                                break;
                            case "Score Quiz #5":
                                dataGridView1.Columns["guessingGame2_id"].HeaderText = "ID";
                                dataGridView1.Columns["guessingGame2_score"].HeaderText = "SCORE";
                                break;
                            case "Score Quiz #2":
                                dataGridView1.Columns["multipleChoice_id"].HeaderText = "ID";
                                dataGridView1.Columns["multipleChoice_score"].HeaderText = "SCORE";
                                break;
                            default:
                                MessageBox.Show("Invalid");
                                return; // Exit the method or handle the default case appropriately
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Username is empty or null");
                    // Handle the case where the username is empty or null
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Form61_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DisplayScore();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

 
    }
}