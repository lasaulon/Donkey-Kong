using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DK
{
    public partial class MainMenuForm : Form
    {
        public Point mouselocation;
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            EnterName name = new EnterName();
            name.ShowDialog();
           
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            audioContext.theme.PlayLooping();
        }

        private void btnHigh_Click(object sender, EventArgs e)
        {
            highScore high = new highScore();
            high.ShowDialog(); ;
        }

        private void MainMenuForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouselocation = new Point(-e.X, -e.Y);
        }

        private void MainMenuForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouselocation.X, mouselocation.Y);
                Location = mousePos;

            }
        }

        private void btnControls_Click(object sender, EventArgs e)
        {
            Controls control = new Controls();
            control.ShowDialog();
            
        }
    }
}
