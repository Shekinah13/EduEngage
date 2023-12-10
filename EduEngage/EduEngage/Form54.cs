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
    public partial class Form54 : Form
    {
        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;

        bool gameOver = false;
        public Form54()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (!gameOver)
            {
                flappyBird.Top += gravity;
                pipeBottom.Left -= pipeSpeed;
                pipeTop.Left -= pipeSpeed;
                scoreText.Text = "Score: " + score;

                if (pipeBottom.Left < -150)
                {
                    pipeBottom.Left = 800;
                    score++;
                }
                if (pipeTop.Left < -180)
                {
                    pipeTop.Left = 950;
                    score++;
                }

                if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                    flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                    flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25
                )
                {
                    endGame();
                }

                if (score > 5)
                {
                    pipeSpeed = 15;
                }
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (!gameOver && e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game over! Press R to restart or ESC to Quit Game!";
            gameOver = true;
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (!gameOver && e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }

            if (e.KeyCode == Keys.R && gameOver)
            {
                RestartGame();
            }

            if (e.KeyCode == Keys.Escape)
            {   
                this.Hide();
                Form9 form9 = new Form9();
                form9.Show();
                
            }
        }

        private void RestartGame ()
        {
            gameOver = false;
            flappyBird.Location = new Point(69, 228);
            pipeTop.Left = 800;
            pipeBottom.Left = 1200;
            score = 0;
            pipeSpeed = 8;
            scoreText.Text = "Score: 0";
            gameTimer.Start();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            gameTimer.Start();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        private void Form54_Load(object sender, EventArgs e)
        {

        }

    }
}