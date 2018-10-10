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
    public partial class ChooseLevel : Form
    {


        public static double score { get; set; }
        public ChooseLevel()
        {
            InitializeComponent();
        }

        private void btnLvl1_Click(object sender, EventArgs e)
        {
            Level1 lvl1 = new Level1();
            lvl1.ShowDialog();
        }

        private void btnLvl2_Click(object sender, EventArgs e)
        {
            Level2 lvl2 = new Level2();
            lvl2.ShowDialog();
        }

        private void btnMM_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLvl3_Click(object sender, EventArgs e)
        {
            Level3 lvl3 = new Level3();
            lvl3.ShowDialog();
        }

        private void ChooseLevel_Activated(object sender, EventArgs e)
        {
            score = 0;
        }
    }
}
