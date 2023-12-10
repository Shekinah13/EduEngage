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
    public partial class Form52 : Form
    {
        List<string> words = new List<string>();
        string newText;
        int i = 0;
        int guessed = 0;
        int attemptsLeft = 3; // Maximum number of attempts allowed
        int totalScore = 0; // Total score variable


        public Form52()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            words = File.ReadLines("words.txt.txt").ToList();
            newText = Scramble(words[i]);
            lblWord.Text = newText;
            lblInfo.Text = "Words: " + (i + 1) + " of " + words.Count;
        }

        private string Scramble(string text)
        {
            return new string(text.ToCharArray().OrderBy(x => Guid.NewGuid()).ToArray());
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
                        totalScore += 1; // Adjust the scoring logic based on your game
                    }
                    else
                    {
                        lblWord.Text = "You Win, Well Done";
                        // Open the next form and pass the total score
                        this.Hide();
                        Form53 Form53 = new Form53(totalScore);
                        Form53.Show();
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
                            Form53 Form53 = new Form53(totalScore);
                            Form53.Show();
                            i = 0;
                            totalScore = 1;
                            Setup();
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

        private void Form52_Load(object sender, EventArgs e)
        {

        }

        private void lblWord_Click(object sender, EventArgs e)
        {

        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblGuessed_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
