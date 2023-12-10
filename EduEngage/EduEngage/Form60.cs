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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace EduEngage
{
    public partial class Form60 : Form
    {

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=''");
        private int selectRow;
        private int rowIndex;
        public Form60()
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
        }


        public void edit()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                selectRow = dataGridView1.SelectedCells[0].RowIndex;
                rowIndex = dataGridView1.SelectedCells[0].ColumnIndex;

                dataGridView1.ReadOnly = false;
                dataGridView1.Rows[selectRow].Cells[rowIndex].ReadOnly = false;

                dataGridView1.Rows[selectRow].Cells[rowIndex].Style.BackColor = Color.Green;
            }
            else
            {
                MessageBox.Show("Please select a cell to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void display()
        {
            if (comboBox1 == null)
            {
                dataGridView1 = null;
            }
            else if (comboBox1.Text == "Students Record")
            {
                string query = "SELECT * FROM eduengage.user_information";

                using (MySqlCommand com = new MySqlCommand(query, connection))
                {

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(com))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        public void DisplayScore()
        {
            string userInformationQuery = "";
            try
            {
                connection.Open();


                switch (comboBox2.Text)
                {
                    case "Score Quiz #1":
                        userInformationQuery = "SELECT crossPuzzle1_id, crossPuzzle1_score, Username, quiz_date FROM eduengage.crosswordpuzzle1";
                        break;

                    case "Score Quiz #2":
                        userInformationQuery = "SELECT multipleChoice_id, multipleChoice_score, Username, quiz_date FROM eduengage.multiplechoice";
                        break;

                    case "Score Quiz #3":
                        userInformationQuery = "SELECT crossPuzzle2_id, crossPuzzle2_score, Username, quiz_date FROM eduengage.crosswordpuzzle2";
                        break;
                    case "Score Quiz #4":
                        userInformationQuery = "SELECT guessingGame1_id, guessingGame1_score, Username, quiz_date FROM eduengage.guessinggame1";
                        break;
                    case "Score Quiz #5":
                        userInformationQuery = "SELECT guessingGame2_id, guessingGame2_score, Username, quiz_date FROM eduengage.guessinggame2";
                        break;

                    default:
                        // Handle other cases or provide a default query
                        MessageBox.Show("Invalid quiz selection");
                        return; // Exit the method or handle the default case appropriately
                }
                using (MySqlCommand com = new MySqlCommand(userInformationQuery, connection))
                {


                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(com))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                    dataGridView1.Columns["Username"].HeaderText = "USERNAME";
                    dataGridView1.Columns["quiz_date"].HeaderText = "DATE";


                    switch (comboBox2.Text)
                    {
                        case "Score Quiz #1":
                            dataGridView1.Columns["crossPuzzle1_id"].HeaderText = "ID";
                            dataGridView1.Columns["crossPuzzle1_score"].HeaderText = "SCORE";

                            break;

                        case "Score Quiz #2":
                            dataGridView1.Columns["multipleChoice_id"].HeaderText = "ID";
                            dataGridView1.Columns["multipleChoice_score"].HeaderText = "SCORE";
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

                        default:
                            MessageBox.Show("Invalid");
                            return; // Exit the method or handle the default case appropriately
                    }
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



        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectRow = dataGridView1.SelectedCells[0].RowIndex;
                int columnIndex = dataGridView1.SelectedCells[0].ColumnIndex;
                button1.Enabled = true;

                // Check if the selected cell contains a value
                if (dataGridView1.Rows[selectRow].Cells[columnIndex].Value != null)
                {
                    var editedValue = dataGridView1.Rows[selectRow].Cells[columnIndex].Value.ToString();

                    // Get the column name using the ColumnIndex
                    string columnName = dataGridView1.Columns[columnIndex].Name;

                    // Check if the selected column is the "username" column
                    if (columnName.ToLower() == "username")
                    {
                        MessageBox.Show("Editing is disabled for the 'username' column.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Exit the method, editing is disabled for the "username" column
                    }

                    string query = $"UPDATE eduengage.user_information SET `{columnName}` = @editedValue WHERE ID = @ID";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }

                        cmd.Parameters.AddWithValue("@editedValue", editedValue);
                        cmd.Parameters.AddWithValue("@ID", dataGridView1.Rows[selectRow].Cells["ID"].Value);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data Updated!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error updating data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }

                    dataGridView1.Rows[selectRow].Cells[columnIndex].Style.BackColor = Color.Pink;
                    dataGridView1.ReadOnly = false;
                }
                else
                {
                    MessageBox.Show("Selected cell is empty. Please select a cell with a value to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a cell to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                connection.Close();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            button1.Enabled = true;
            button2.Enabled = true;
            display();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            DisplayScore();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            string query = @"
            SELECT
                u.ID,
                u.Username,
                MAX(cp1.crossPuzzle1_score) AS max_quiz1_score,
                MAX(mc.multipleChoice_score) AS max_quiz2_score,
                MAX(cp2.crossPuzzle2_score) AS max_quiz3_score,
                MAX(gg1.guessingGame1_score) AS max_quiz4_score,
                MAX(gg2.guessingGame2_score) AS max_quiz5_score
            FROM
                eduengage.user_information u
            LEFT JOIN eduengage.crosswordPuzzle1 cp1 ON u.Username = cp1.Username
            LEFT JOIN eduengage.crosswordPuzzle2 cp2 ON u.Username = cp2.Username
            LEFT JOIN eduengage.guessingGame2 gg2 ON u.Username = gg2.Username
            LEFT JOIN eduengage.guessingGame1 gg1 ON u.Username = gg1.Username
            LEFT JOIN eduengage.multiplechoice mc ON u.Username = mc.Username
            GROUP BY
                u.ID;";


            using (MySqlCommand com = new MySqlCommand(query, connection))
            {

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(com))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                dataGridView1.Columns["max_quiz1_score"].HeaderText = "QUIZ 1";
                dataGridView1.Columns["max_quiz2_score"].HeaderText = "QUIZ 2";
                dataGridView1.Columns["max_quiz3_score"].HeaderText = "QUIZ 3";
                dataGridView1.Columns["max_quiz4_score"].HeaderText = "QUIZ 4";
                dataGridView1.Columns["max_quiz5_score"].HeaderText = "QUIZ 5";
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string connection = "datasource=localhost;port=3306;username=root;password=''";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                var user = dataGridView1.SelectedRows[0].Cells["Username"].FormattedValue.ToString();

                DialogResult result = MessageBox.Show("Do you want to delete this row of data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connection))
                    {
                        conn.Open();

                        // Step 1: Delete from child tables
                        string childQuery = "DELETE FROM eduengage.crosswordpuzzle1 WHERE Username = @user;" +
                                            "DELETE FROM eduengage.multiplechoice WHERE Username = @user;" +
                                            "DELETE FROM eduengage.crosswordpuzzle2 WHERE Username = @user;" +
                                            "DELETE FROM eduengage.guessinggame1 WHERE Username = @user;" +
                                            "DELETE FROM eduengage.guessinggame2 WHERE Username = @user;";

                        MySqlCommand childCmd = new MySqlCommand(childQuery, conn);
                        childCmd.Parameters.AddWithValue("@user", user);
                        childCmd.ExecuteNonQuery();

                        // Step 2: Delete from parent table
                        string parentQuery = "DELETE FROM eduengage.user_information WHERE Username = @user";
                        MySqlCommand parentCmd = new MySqlCommand(parentQuery, conn);
                        parentCmd.Parameters.AddWithValue("@user", user);
                        parentCmd.ExecuteNonQuery();

                        MessageBox.Show("Data Deleted!");
                        conn.Close();
                        dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
