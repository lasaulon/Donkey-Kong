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
    public partial class Level3 : Form
    {
        bool right;
        bool left;
        bool jump, up, down;
        int g = 17;
        int force;
        int index;
        bool gameover = false;
        Boolean barrel1r,barrel2r,barrel3r,barrel4r, barrel5r, barrel6r, DKr, moveBlockr;

        private void timerScore_Tick(object sender, EventArgs e)
        {
            if (gameover == false)
            {
                ChooseLevel.score = ChooseLevel.score - .05;

                label2.Text = Math.Ceiling(ChooseLevel.score).ToString();
            }
        }

        public Level3()
        {
            ChooseLevel.score += 400;
            InitializeComponent();
        }

        private void barrelTimer_Tick(object sender, EventArgs e)
        {
            if (gameover == false)
            {
                index++;
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
                collideBlock();
            }
        }

        public void barrelMove()
        {
            if (gameover == false)
            {
               
                //DonkeyKong
                if (DK.Location.X > 130)
                    DKr = true;
                else if (DK.Location.X < 30)
                    DKr = false;
                if (DKr == true)
                    DK.Location = new Point(DK.Location.X - 1, DK.Location.Y);
                else
                    DK.Location = new Point(DK.Location.X + 1, DK.Location.Y);

                //movingBlock
                if (moveBlock.Location.Y > 670)
                    moveBlockr = true;
                else if (moveBlock.Location.Y < 300)
                    moveBlockr = false;
                if (moveBlockr == true)
                    moveBlock.Location = new Point(moveBlock.Location.X, moveBlock.Location.Y - 1);
                else
                    moveBlock.Location = new Point(moveBlock.Location.X, moveBlock.Location.Y + 1);

                //Barrel1
                if (barrel1.Location.X > 230)
                     barrel1r = true;
                else if (barrel1.Location.X < 10)
                    barrel1r = false;
                if (barrel1r == true)
                    barrel1.Location = new Point(barrel1.Location.X-1, barrel1.Location.Y);
                else
                    barrel1.Location = new Point(barrel1.Location.X+1, barrel1.Location.Y);


                //Barrel2
                if (barrel2.Location.X > 650)
                    barrel2r = true;
                else if (barrel2.Location.X < 420)
                    barrel2r = false;
                if (barrel2r == true)
                    barrel2.Location = new Point(barrel2.Location.X - 1, barrel2.Location.Y);
                else
                    barrel2.Location = new Point(barrel2.Location.X + 1, barrel2.Location.Y);


                //Barrel3
                if (barrel3.Location.X > 230)
                    barrel3r = true;
                else if (barrel3.Location.X < 10)
                    barrel3r = false;
                if (barrel3r == true)
                    barrel3.Location = new Point(barrel3.Location.X - 1, barrel3.Location.Y);
                else
                    barrel3.Location = new Point(barrel3.Location.X + 1, barrel3.Location.Y);


                //Barrel4
                if (barrel4.Location.X > 650)
                    barrel4r = true;
                else if (barrel4.Location.X < 420)
                    barrel4r = false;
                if (barrel4r == true)
                    barrel4.Location = new Point(barrel4.Location.X - 1, barrel4.Location.Y);
                else
                    barrel4.Location = new Point(barrel4.Location.X + 1, barrel4.Location.Y);


                //Barrel5
                if (barrel5.Location.X > 230)
                    barrel5r = true;
                else if (barrel5.Location.X < 10)
                    barrel5r = false;
                if (barrel5r == true)
                    barrel5.Location = new Point(barrel5.Location.X - 1, barrel5.Location.Y);
                else
                    barrel5.Location = new Point(barrel5.Location.X + 1, barrel5.Location.Y);


                //Barrel6
                if (barrel6.Location.X > 650)
                    barrel6r = true;
                else if (barrel6.Location.X < 420)
                    barrel6r = false;
                if (barrel6r == true)
                    barrel6.Location = new Point(barrel6.Location.X - 1, barrel6.Location.Y);
                else
                    barrel6.Location = new Point(barrel6.Location.X + 1, barrel6.Location.Y);
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
                if (player.Bounds.IntersectsWith(pictureBox12.Bounds))
                {
                    if (e.KeyCode == Keys.Up)
                    {

                        player.Top -= 15;
                    }
                    if (e.KeyCode == Keys.Down)
                    {
                        player.Top += 15;
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

        public void Blocks(PictureBox moveBlock)
        {

            //Top Collision
            if (player.Left + player.Width > moveBlock.Left && player.Left + player.Width < moveBlock.Left + moveBlock.Width + player.Width && player.Top + player.Height >= moveBlock.Top && player.Top < moveBlock.Top)
            {
                jump = false;
                force = 0;
                player.Top = moveBlock.Location.Y - player.Height;
            }

            //Head Collision
            if (player.Left + player.Width > moveBlock.Left && player.Left + player.Width < moveBlock.Left + moveBlock.Width + player.Width && player.Top - moveBlock.Bottom <= 10 && player.Top - moveBlock.Top > -10)
            {
                jump = false;
                force = 0;
                player.Top = moveBlock.Location.Y + player.Height;

            }
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\mydatabase.mdb";
            if (player.Bounds.IntersectsWith(barrel1.Bounds) || player.Bounds.IntersectsWith(barrel2.Bounds) || player.Bounds.IntersectsWith(barrel3.Bounds)||player.Bounds.IntersectsWith(barrel4.Bounds)||player.Bounds.IntersectsWith(barrel5.Bounds)||player.Bounds.IntersectsWith(barrel6.Bounds))
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
            if (player.Bounds.IntersectsWith(princess.Bounds))
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
                    if (MessageBox.Show("Congratulations! Score: " + Math.Ceiling(ChooseLevel.score) + " You beat the game! Want to play again?", "Winner!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }

        public void collideBlock()
        {
            Blocks(moveBlock);
            Blocks(moveBlock2);
            Blocks(moveBlock3);
            Blocks(moveBlock4);
            Blocks(moveBlock5);
            Blocks(moveBlock6);
            Blocks(moveBlock8);
            Blocks(moveBlock7);
            Blocks(moveBlock9);
            
        }
    }
}
    
    



