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
    public partial class Level2 : Form
    {
        bool right;
        bool left;
        bool jump,up,down;
        int g = 18;
        int force;
        int index;
        bool gameover = false;
        Boolean barrelr, barrel1r, barrel2r, barrel3r,barrel4r,barrel5r,moveBlockr,DKr;

        private void timerScore_Tick(object sender, EventArgs e)
        {
            if (gameover == false)
            {
                ChooseLevel.score = ChooseLevel.score - .05;

                label2.Text = Math.Ceiling(ChooseLevel.score).ToString();
            }
        }

        public Level2()
        {
            ChooseLevel.score += 300;
            InitializeComponent();
        }

        private void barrelTimer_Tick(object sender, EventArgs e)
        {
            if (gameover == false)
            {
                index++;
                //barrelRoll
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
                //barrel1
                if (barrel1.Location.X > 650)
                    barrel1r = true;
                else if (barrel1.Location.X < 100)
                    barrel1r = false;
                if (barrel1r == true)
                    barrel1.Location = new Point(barrel1.Location.X - 1, barrel1.Location.Y);
                else
                    barrel1.Location = new Point(barrel1.Location.X + 1, barrel1.Location.Y);


                //barrel2
                if (barrel2.Location.X > 650)
                    barrel2r = true;
                else if (barrel2.Location.X < 100)
                    barrel2r = false;

                if (barrel2r == true)
                    barrel2.Location = new Point(barrel2.Location.X - 1, barrel2.Location.Y);
                else
                    barrel2.Location = new Point(barrel2.Location.X + 1, barrel2.Location.Y);


                //barrel3
                if (barrel3.Location.X > 650)
                    barrel3r = true;
                else if (barrel3.Location.X < 100)
                    barrel3r = false;
                if (barrel3r == true)
                    barrel3.Location = new Point(barrel3.Location.X - 1, barrel3.Location.Y);
                else
                    barrel3.Location = new Point(barrel3.Location.X + 1, barrel3.Location.Y);

                //barrel4
                if (barrel4.Location.X > 650)
                    barrel4r = true;
                else if (barrel4.Location.X < 100)
                    barrel4r = false;
                if (barrel4r == true)
                    barrel4.Location = new Point(barrel4.Location.X - 1, barrel4.Location.Y);
                else
                    barrel4.Location = new Point(barrel4.Location.X + 1, barrel4.Location.Y);

                //barrel5
                if (barrel5.Location.X > 650)
                    barrel5r = true;
                else if (barrel5.Location.X < 100)
                    barrel5r = false;
                if (barrel5r == true)
                    barrel5.Location = new Point(barrel5.Location.X - 1, barrel5.Location.Y);
                else
                    barrel5.Location = new Point(barrel5.Location.X + 1, barrel5.Location.Y);

                //movingBarrel
                if (barrel.Location.Y > 630)
                    barrelr = true;
                else if (barrel.Location.Y < 200)
                    barrelr = false;
                if (barrelr == true)
                    barrel.Location = new Point(barrel.Location.X, barrel.Location.Y - 1);
                else
                    barrel.Location = new Point(barrel.Location.X, barrel.Location.Y + 1);

                //movingBLock
                if (moveBlock.Location.Y > 680)
                    moveBlockr = true;
                else if (moveBlock.Location.Y < 200)
                    moveBlockr = false;
                if (moveBlockr == true)
                    moveBlock.Location = new Point(moveBlock.Location.X, moveBlock.Location.Y - 1);
                else
                    moveBlock.Location = new Point(moveBlock.Location.X, moveBlock.Location.Y + 1);

                //DonkeyKong
                if (DK.Location.X > 130)
                    DKr = true;
                else if (DK.Location.X < 30)
                    DKr = false;
                if (DKr == true)
                    DK.Location = new Point(DK.Location.X - 1, DK.Location.Y);
                else
                    DK.Location = new Point(DK.Location.X + 1, DK.Location.Y);
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
                if (player.Bounds.IntersectsWith(pictureBox12.Bounds) || player.Bounds.IntersectsWith(pictureBox13.Bounds) || player.Bounds.IntersectsWith(pictureBox14.Bounds) || player.Bounds.IntersectsWith(pictureBox15.Bounds) || player.Bounds.IntersectsWith(pictureBox2.Bounds))
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
                jump = true;
                force = 0;
                player.Top = moveBlock.Location.Y + player.Height;

            }
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\mydatabase.mdb";
            if (player.Bounds.IntersectsWith(barrel.Bounds) || player.Bounds.IntersectsWith(barrel1.Bounds) || player.Bounds.IntersectsWith(barrel2.Bounds) || player.Bounds.IntersectsWith(barrel3.Bounds) || player.Bounds.IntersectsWith(barrel4.Bounds) || player.Bounds.IntersectsWith(barrel5.Bounds))
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
                    connection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\mydatabase.mdb";
                    connection.Open();
                    OleDbCommand comm = new OleDbCommand();
                    comm.Connection = connection;
                    comm.CommandText = "insert into data values('" + EnterName.playername + "','" + Math.Ceiling(ChooseLevel.score) + "')";
                    comm.ExecuteNonQuery();
                    connection.Close();
                    if (MessageBox.Show("Congratulations! Score: " + Math.Ceiling(ChooseLevel.score) + " Move to next level?", "Winner!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Close();
                        Level3 lvl3 = new Level3();
                        lvl3.ShowDialog();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
        }

       public void collideBlock()
        {
            Blocks(moveBlock);
            Blocks(moveBlock1);
            Blocks(moveBlock2);
            Blocks(moveBlock3);
            Blocks(moveBlock4);
            Blocks(moveBlock5);
            Blocks(moveBlock6);
            Blocks(moveBlock7);
            Blocks(moveBlock8);
            Blocks(moveBlock9);
            Blocks(moveBlock10);
            Blocks(moveBlock11);
            Blocks(moveBlock12);
            Blocks(moveBlock13);
            Blocks(moveBlock14);
        }

    }
}
