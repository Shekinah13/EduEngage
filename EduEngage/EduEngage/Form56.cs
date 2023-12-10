using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EduEngage
{
    public partial class Form56 : Form
    {
        List<string> words = new List<string>();
        string newText;
        int i = 0;
        int guessed = 0;
        int attemptsLeft = 3; // Maximum number of attempts allowed
        int totalScore2 = 0; // Total score variable
        public Form56()
        {
            InitializeComponent();
            SetUp();
        }

        private void SetUp()
        {
            words = File.ReadLines("words2.txt").ToList();
            newText = Scramble(words[i]);
            lblWord.Text = newText;
            lblInfo.Text = "Words: " + (i + 1) + " of " + words.Count;
        }

        private string Scramble(string text)
        {
            return new string(text.ToCharArray().OrderBy(x => Guid.NewGuid()).ToArray());
        }

        private void Form56_Load(object sender, EventArgs e)
        {

        }

        private void KeyIsPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (words[i].ToLower() == textBox1.Text.ToLower())
                {
                    if (i < words.Count - 1)
                    {
                        MessageBox.Show("Correct!", "Very Good!");
                        textBox1.Text = "";
                        i += 1;
                        newText = Scramble(words[i]);
                        lblWord.Text = newText;
                        lblInfo.Text = "Words :" + (i + 1) + " of " + words.Count;
                        guessed = 0;
                        lblGuessed.Text = "Guessed: " + guessed + " times.";
                        attemptsLeft = 3; // Reset attempts for the next word
                        // Increment the total score when the word is guessed correctly
                        totalScore2 += 1; // Adjust the scoring logic based on your game
                    }
                    else
                    {
                        lblWord.Text = "You Win, Well Done";
                        // Open the next form and pass the total score
                        this.Hide();
                        Form57 Form57 = new Form57(totalScore2);
                        Form57.Show();
                    }
                }
                else
                {
                    guessed += 1;
                    lblGuessed.Text = "Guessed: " + guessed + " times.";
                    attemptsLeft -= 1;

                    if (attemptsLeft == 0)
                    {
                        MessageBox.Show("Incorrect! You've used all your attempts. Moving on to the next word.");
                        textBox1.Text = "";
                        i += 1;

                        if (i < words.Count)
                        {
                            newText = Scramble(words[i]);
                            lblWord.Text = newText;
                            lblInfo.Text = "Words :" + (i + 1) + " of " + words.Count;
                        }
                        else
                        {
                            lblWord.Text = "You Win, Well Done";
                            this.Hide(); 
                            Form57 Form57 = new Form57(totalScore2);
                            Form57.Show();
                            i = 0;
                            totalScore2 = 1;
                            SetUp();
                        }

                        guessed = 0;
                        lblGuessed.Text = "Guessed: " + guessed + " times.";
                        attemptsLeft = 3; // Reset attempts for the next word
                    }
                }

                // Clear the text box after processing the user's input
                textBox1.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
