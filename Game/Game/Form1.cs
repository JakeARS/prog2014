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

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (right == true)
            {
                player.Left += 5;
            }
            if (left == true)
            {
                player.Left -= 5;
            }

            if (jump == true) 
            {//falling
                player.Top -= Force;
                Force -= 1;
            }

            if (player.Top + player.Height >= screen.Height)
            {
                player.Top = screen.Height - player.Height;   //stop falling at bottom
                jump = false;                
            }
            else
            {
                player.Top += 5;   //falling
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = true;
                player.Image = Image.FromFile("walk_r.gif");
            }
            
            if (e.KeyCode == Keys.Left)
            {
                left = true;
                player.Image = Image.FromFile("walk_l.gif");
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
            WindowState = FormWindowState.Maximized;
            player.Image = Image.FromFile("stand.png");
        }
    }
}
