using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGame
{
    public partial class Form1 : Form

    {
        System.Media.SoundPlayer startSoundPlayer = new System.Media.SoundPlayer(@"sounds\lose.wav");
        System.Media.SoundPlayer finishSoundPlayer = new System.Media.SoundPlayer(@"sounds\win.wav");
        System.Media.SoundPlayer wallSoundPlayer = new System.Media.SoundPlayer(@"sounds\lose2.wav");
        System.Media.SoundPlayer tenseSoundPlayer = new System.Media.SoundPlayer(@"sounds\tense.wav");
        System.Media.SoundPlayer doneSoundPlayer = new System.Media.SoundPlayer(@"sounds\done.wav");


        public Form1()
        {
            InitializeComponent();
            MoveToStart();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void finishlabel_MouseEnter(object sender, EventArgs e)
        {
            finishSoundPlayer.Play();
            MessageBox.Show("Congrats!!!");
            Close();
        }

        private void MoveToStart()
        {
            startSoundPlayer.Play();
            Point startingPoint = panel1.Location;
            startingPoint.Offset(10, 10);
            Cursor.Position = PointToScreen(startingPoint);
        }

        private void wall_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
            wallSoundPlayer.Play();
        }

        int timeLeft = 30;
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                lblmyTime.Text = timeLeft + " Seconds";
                btnRef.Visible = false;
            }
            else

            {
                btnRef.Visible = true;
                lblmyTime.Text = timeLeft + " Its over.....";
                doneSoundPlayer.PlaySync();
            }
                if (timeLeft <= 10)
                {
            
                    lblmyTime.Text = timeLeft + " Hurrryyyy";
                    tenseSoundPlayer.Play();
                }
            if (timeLeft == 0)
            {
                lblmyTime.Text = timeLeft + " Its over.....";
                doneSoundPlayer.Play();
            }

               
            }

            private void btnRef_Click(object sender, EventArgs e)
            {
            Refresh();
            }
        }

    } 

