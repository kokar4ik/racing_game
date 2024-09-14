using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shashki_turbo_pro_racing_game
{
    public partial class Form1 : Form
    {
        int score = 0;
        private void increasescore ()
        {
            score++;
            defcars.Text = score.ToString();
        }
        public Form1()

        {
            SoundPlayer sound_main = new SoundPlayer(@"C:\Users\iliol\source\repos\shashki_pro_racing_game\shashki_turbo_pro_racing_game\music.mp3.wav");
            sound_main.PlayLooping();
            InitializeComponent();
            kaboom.Visible = false;
            btnretry.Visible = false;
            label1.Visible = false;
            KeyPreview = true;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                this.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (kaboom.Visible == true)
            {
                return;
            }
            if (e.KeyCode == Keys.Left)
            {
                if (car.Left > 0)
                    car.Left += -7;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (car.Right < 1000)
                    car.Left += 7; 
            }
            if (e.KeyCode == Keys.Up)
            {
                if (car.Top > 0)
                    car.Top += -5;
            }
            if (e.KeyCode == Keys.Down)
            {
                if (car.Top < 790)
                    car.Top += 5;
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int speed = 15;
            road.Top += speed;
            roadd.Top += speed;
            
        
            if (road.Top >= 1000)
            {
                road.Top = 0;
              roadd.Top = -990;
            }
            int speed2 = 9;
            car2.Top += speed2;
            if (car2.Top>1100)
            {
                car2.Top = -330;
                Random rand = new Random();
                car2.Left = rand.Next(10, 140);
                increasescore();
            }
            int speed3 = 7;
            car3.Top += speed3;
            if (car3.Top > 1100)
            {
                car3.Top = -500;
                Random rand = new Random();
                car3.Left = rand.Next(250, 395);
                increasescore();
            }

            int speed4 = 5;
            car4.Top += speed4;
            if (car4.Top > 1100)
            {
                car4.Top = -400;
                Random rand = new Random();
                car4.Left = rand.Next(505, 640);
                increasescore();
            }

            int speed5 = 3;
            car5.Top += speed5;
            if (car5.Top > 1100)
            {
                car5.Top = -300;
                Random rand = new Random();
                car5.Left = rand.Next(750, 863);
                this.increasescore();
            }
            if (car.Bounds.IntersectsWith(car2.Bounds)||
                car.Bounds.IntersectsWith(car3.Bounds) ||
                car.Bounds.IntersectsWith(car4.Bounds) ||
                car.Bounds.IntersectsWith(car5.Bounds))
            {
                timer1.Enabled = false;
                kaboom.Location = this.car.Location;
                kaboom.Visible = true;
                label1.Visible = true;
                btnretry.Visible = true; 
            }
        }

      

        private void btnretry_Click_1(object sender, EventArgs e)
        {
            car2.Top = -1030;
            car3.Top = -500;
            car4.Top = -1400;
            car5.Top = -900;
            label1.Visible = false;
            kaboom.Visible = false;
            btnretry.Visible = false;
            timer1.Enabled = true;
            score = 0;
            defcars.Text = score.ToString();
        }

   

    
    }
}
