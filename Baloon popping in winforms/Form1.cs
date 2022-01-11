using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baloon_popping_in_winforms
{
    public partial class Form1 : Form
    {
        int speed, score;
        Random rand = new Random();
        bool gameIsOver;
        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            label1.Text = "Score: " + score;
            foreach (Control item in Controls)
            {
              if (item is PictureBox)
                {
                    if ((string)item.Tag=="balloon" &&  bomb.Bounds.IntersectsWith(item.Bounds))
                    {
                        bomb.Top = rand.Next(700, 1200);
                        bomb.Left = rand.Next(0, 500);
                    }
                    if ((string)item.Tag=="balloon" && item.Top<-80)
                    {
                        GameOver();
                    }
                    item.Top -= speed;
                    if (item.Top< -100)
                    {
                        item.Top = rand.Next(700, 1200);
                        item.Left = rand.Next(0, 500);
                    }
                }
            }

        }

        private void PopBalloon(object sender, EventArgs e)
        {
            if (gameIsOver== false)
            {
                var balloon = (PictureBox)sender;
                balloon.Top= rand.Next(700, 1200);
                balloon.Left= rand.Next(0, 500);
                score++;
            }
        }

        private void KaBoom(object sender, EventArgs e)
        {
            bomb.Image = Properties.Resources.boom;
            GameOver();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter && gameIsOver==true)
            {
                RestartGame();
            }
        }
        private void RestartGame()
        {
            gameIsOver = false;
            speed = 5;
            score = 0;
            label1.Text = "Score: " + score;
            bomb.Image = Properties.Resources.bomb;
            foreach (Control x in Controls)
            {
                if (x is PictureBox)
                {
                    x.Top = rand.Next(700, 1200);
                    x.Left = rand.Next(0, 550);
                }
            }
            gameTimer.Start();
        }
        private void GameOver() {
            gameIsOver = true;
            gameTimer.Stop();

        }

    }
}
