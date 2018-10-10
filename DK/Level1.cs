using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DK
{
    public partial class Level1 : Form
    {
        bool right;
        bool left;
        bool jump,up,down;
        int g = 18;
        int force;
        int index;
        bool gameover = false;

        Boolean barrelr, barrel1r, barrel2r, barrel3r;

        public Level1()
        {
            ChooseLevel.score += 200;
            InitializeComponent();
        }

        private void timerMove_Tick(object sender, EventArgs e)
        {
            if (gameover == false)
            {
                index++;

                //call barrel roll method
                barrelMove();

                //Gif replay
                if (right == true && index % 15 == 0)
                {
                    player.Image = Image.FromFile("walk_r.gif");
                }
                if (left == true && index % 15 == 0)
                {
                    player.Image = Image.FromFile("walk_l.gif");
                }
                if (right == true)
                {
                    if (player.Left < 650)
                        player.Left += 5;
                }
                if (left == true)
                {
                    if (player.Left > 10)
                        player.Left -= 5;
                }
                if (up == true)
                {
                    player.Top -= 15;
                }
                if (down == true)
                {
                    player.Top += 15;
                }
                else if (jump == true)
                {
                    player.Top -= force;
                    force -= 1;

                    if (player.Top + player.Height >= screen.Height)
                    {
                        player.Top = screen.Height - player.Height;
                        if (jump == true)
                        {
                            player.Image = Image.FromFile("stand.png");
                        }
                        jump = false;
                    }
                    else
                    {
                        player.Top += 10;
                    }
                }
                collideBLock();
            }
        }

        public void barrelMove()
        {
            if (gameover == false)
            {
                //barrel
                if (barrel.Location.X > 650)
                    barrelr = true;
                else if (barrel.Location.X < 10)
                    barrelr = false;
                if (barrelr == true)
                    barrel.Location = new Point(barrel.Location.X - 1, barrel.Location.Y);
                else
                    barrel.Location = new Point(barrel.Location.X + 1, barrel.Location.Y);


                //barrel1
                if (barrel1.Location.X > 650)
                    barrel1r = true;
                else if (barrel3.Location.X < 10)
                    barrel1r = false;
                if (barrel1r == true)
                    barrel1.Location = new Point(barrel1.Location.X - 1, barrel1.Location.Y);
                else
                    barrel1.Location = new Point(barrel1.Location.X + 1, barrel1.Location.Y);


                //barrel2
                if (barrel2.Location.X > 650)
                    barrel2r = true;
                else if (barrel2.Location.X < 10)
                    barrel2r = false;
                if (barrel2r == true)
                    barrel2.Location = new Point(barrel2.Location.X - 1, barrel2.Location.Y);
                else
                    barrel2.Location = new Point(barrel2.Location.X + 1, barrel2.Location.Y);

                //barrel3
                if (barrel3.Location.X > 650)
                    barrel3r = true;
                else if (barrel3.Location.X < 10)
                    barrel3r = false;
                if (barrel3r == true)
                    barrel3.Location = new Point(barrel3.Location.X - 1, barrel3.Location.Y);
                else
                    barrel3.Location = new Point(barrel3.Location.X + 1, barrel3.Location.Y);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameover == false)
            {
                if (e.KeyCode == Keys.Right)
                {
                    right = true;
                    audioContext.walk.Play();
                }
                if (e.KeyCode == Keys.Left)
                {
                    left = true;
                    audioContext.walk.Play();
                }
                if (player.Bounds.IntersectsWith(ladder1.Bounds) || player.Bounds.IntersectsWith(ladder2.Bounds) || player.Bounds.IntersectsWith(ladder3.Bounds) || player.Bounds.IntersectsWith(ladder4.Bounds))
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        player.Top -= 5;
                    }
                    if (e.KeyCode == Keys.Down)
                    {
                        player.Top += 5;
                    }
                }
                if (jump != true)
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        jump = true;
                        force = g;
                        audioContext.jump.Play();
                        player.Image = Image.FromFile("jump.png");
                    }
                }
            }
        }

        private void timerScore_Tick(object sender, EventArgs e)
        {
            if (gameover == false)
            {
                ChooseLevel.score = ChooseLevel.score - .05;
                label2.Text = Math.Ceiling(ChooseLevel.score).ToString();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (gameover == false)
            {
                if (e.KeyCode == Keys.Right)
                {
                    right = false;
                    audioContext.walk.Stop();
                    player.Image = Image.FromFile("stand.png");
                }
                if (e.KeyCode == Keys.Left)
                {
                    left = false;
                    audioContext.walk.Stop();
                    player.Image = Image.FromFile("stand.png");
                }
            }
        }

        public void Blocks(PictureBox block)
        {
            
            //Top Collision
            if (player.Left + player.Width > block.Left && player.Left + player.Width < block.Left + block.Width + player.Width && player.Top + player.Height >= block.Top && player.Top < block.Top)
            {
                jump = false;
                force = 0;
                player.Top = block.Location.Y - player.Height;
            }

            //Head Collision
            if (player.Left + player.Width > block.Left && player.Left + player.Width < block.Left + block.Width + player.Width && player.Top -block.Bottom <=10 &&player.Top-block.Top>-10)
            {
                jump = false;
                force = 0;
                player.Top = block.Location.Y + player.Height;
                
            }
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\mydatabase.mdb";
          
            if (player.Bounds.IntersectsWith(barrel.Bounds) || player.Bounds.IntersectsWith(barrel1.Bounds) || player.Bounds.IntersectsWith(barrel2.Bounds) || player.Bounds.IntersectsWith(barrel3.Bounds))
            {
                if (gameover == false)
                {
                    audioContext.die.Play();
                    gameover = true;
                    ChooseLevel.score = 0;
                    connection.Open();
                    OleDbCommand comm = new OleDbCommand();
                    comm.Connection = connection;
                    comm.CommandText = "insert into data values('" + EnterName.playername + "','" + Math.Ceiling(ChooseLevel.score) + "')";
                    comm.ExecuteNonQuery();
                    connection.Close();
                    if (MessageBox.Show("Do you want to play again?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        this.Close();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            if (player.Bounds.IntersectsWith(pictureBox6.Bounds))
            {
                if (gameover == false)
                {
                    audioContext.vic.Play();
                    gameover = true;
                    connection.Open();
                    OleDbCommand comm = new OleDbCommand();
                    comm.Connection = connection;
                    comm.CommandText = "insert into data values('" + EnterName.playername + "','" + Math.Ceiling(ChooseLevel.score) + "')";
                    comm.ExecuteNonQuery();
                    connection.Close();
                    if (MessageBox.Show("Congratulations! Score: " + Math.Ceiling(ChooseLevel.score) + " Move to next level?", "Winner!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Close();
                        Level2 lvl2 = new Level2();
                        lvl2.ShowDialog();

                    }
                    else
                    {
                        this.Close();
                    }
                }
            }

        }

        public void collideBLock()
        {
            Blocks(block);
            Blocks(block1);
            Blocks(block2);
            Blocks(block3);
            Blocks(block4);
            Blocks(block5);
            Blocks(block6);
            Blocks(block7);
            Blocks(block8);
        }
    }
}

