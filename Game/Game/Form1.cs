using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {

        bool right;
        bool left;
        bool jump;
        int G = 30;
        int Force;
        int index = 0;

        public Form1()
        {
            InitializeComponent();

            player.Top = screen.Height - player.Height;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            index++;
            if (right == true && index % 15 == 0) //повторение анимации шага
            {
                player.Image = Image.FromFile("walk_r.gif");
            }

            if (left == true && index % 15 == 0) //повторение анимации шага
            {
                player.Image = Image.FromFile("walk_l.gif");
            }

            if (player.Right > block.Left && player.Left < block.Right - player.Width && player.Bottom < block.Bottom && player.Bottom > block.Top)
            {
                right = false;
            }

            if (player.Left < block.Right && player.Right > block.Left + player.Width && player.Bottom < block.Bottom && player.Bottom > block.Top)
            {
                left = false;
            }

            if (player.Left + player.Width > block.Left && player.Left + player.Width < block.Left + block.Width+player.Width && player.Top + player.Height >= block.Top && player.Top < block.Top)
            {
                /*player.Top = screen.Height - block.Height - player.Height -10;
                Force = 0;
                if (jump == true)
                {
                    player.Image = Image.FromFile("stand.png");
                }
                jump = false;*/
                jump = false;
                Force = 0;
                player.Top = block.Location.Y - player.Height - 10;
            }


            if (player.Left + player.Width > block.Left && player.Left + player.Width < block.Left + block.Width + player.Width && player.Top - block.Bottom <= 10 && player.Top - block.Top > -10)
            {
                Force = -1; 
            }

            if (right == true)
            {
                player.Left += 3;
            }
            if (left == true)
            {
                player.Left -= 3;
            }

            if (jump == true) 
            {//falling
                player.Top -= Force;
                Force -= 1;
            }

            if (player.Top + player.Height >= screen.Height)
            {
                player.Top = screen.Height - player.Height;   //stop falling at bottom
                if (jump == true)
                {
                    player.Image = Image.FromFile("stand.png");
                }
                jump = false;                
            }
            else
            {
                player.Top += 5;   //falling
            }


            if (player.Right == flag.Left)
            {
                MessageBox.Show("Win","Win", MessageBoxButtons.OK);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = true;
                //player.Image = Image.FromFile("walk_r.gif");
            }
            
            if (e.KeyCode == Keys.Left)
            {
                left = true;
                //player.Image = Image.FromFile("walk_l.gif");
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }  

            if (jump != true)
            {
                if (e.KeyCode == Keys.Space)
                {
                    player.Image = Image.FromFile("jump.png");
                    jump = true;
                    Force = G;
                }

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
                player.Image = Image.FromFile("stand.png");
            }
            
            if (e.KeyCode == Keys.Left)
            {
                left = false;
                player.Image = Image.FromFile("stand.png");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // WindowState = FormWindowState.Maximized;
            player.Image = Image.FromFile("stand.png");
            flag.Image = Image.FromFile("flag.png");
            player.Top = screen.Height - player.Height;
        }
    }
}
