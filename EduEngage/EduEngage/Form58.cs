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
    public partial class Form58 : Form
    {
        int correctAnswer;
        int questionNumber = 1;
        int score;
        int totalQuestions;

        public Form58()
        {
            InitializeComponent();

            askQuestion(questionNumber);

            totalQuestions = 5;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }


        private void lblQuestion_Click(object sender, EventArgs e)
        {

        }

        private void checkAnswerEvent(object sender, EventArgs e)
        {
            var senderObject = (Button)sender;

            int buttonTag = Convert.ToInt32(senderObject.Tag);

            if (buttonTag == correctAnswer)
            {
                score++;
            }

            if (questionNumber == totalQuestions)
            {

                Form59 resultForm = new Form59(score);
                resultForm.Show();
                this.Hide();


                score = 0;
                questionNumber = 1;
                askQuestion(questionNumber);


            }
            questionNumber++;
            askQuestion(questionNumber);
        }
        private void askQuestion(int qnum)
        {
            switch (qnum)
            {
                case 1:
                    lblQuestion.Text = "It involves learning how to access information \nand perform basic operations on a computer.";

                    button1.Text = "Computer Literacy";
                    button2.Text = "Computer";
                    button3.Text = "Power Users";
                    button4.Text = "Computer Literate";

                    correctAnswer = 1;

                    break;

                case 2:
                    lblQuestion.Text = "Those with higher level skills like programming are sometimes called ______.";

                    button1.Text = "Computer Literate";
                    button2.Text = "Power User";
                    button3.Text = "Literacy";
                    button4.Text = "Computer";

                    correctAnswer = 2;

                    break;

                case 3:
                    lblQuestion.Text = "It is a term used to describe individuals who have \nknowledge and skills to use a computer and other related technology. ";

                    button1.Text = "Computer Literacy";
                    button2.Text = "Computer Literate";
                    button3.Text = "Power Users";
                    button4.Text = "Computer";

                    correctAnswer = 2;

                    break;

                case 4:
                    lblQuestion.Text = "Skills involved in computer literacy.";

                    button1.Text = "Coding";
                    button2.Text = "Reading";
                    button3.Text = "Editing";
                    button4.Text = "Drawing";

                    correctAnswer = 1;

                    break;

                case 5:
                    lblQuestion.Text = "When you are computer literate, you understand the _________ and limitations of computers.\r\n";

                    button1.Text = "Boundaries";
                    button2.Text = "Capabilities";
                    button3.Text = "Parts";
                    button4.Text = "Use";

                    correctAnswer = 2;

                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form58_Load(object sender, EventArgs e)
        {

        }
    }
}
