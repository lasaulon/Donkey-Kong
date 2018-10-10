using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace DK
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenuForm());
        }
    }

    static class audioContext
    {
        static public readonly SoundPlayer die = new SoundPlayer(Properties.Resources.die);
        static public readonly SoundPlayer jump = new SoundPlayer(Properties.Resources.jump);
        static public readonly SoundPlayer vic = new SoundPlayer(Properties.Resources.victory);
        static public readonly SoundPlayer walk = new SoundPlayer(Properties.Resources.walk);
        static public readonly SoundPlayer theme = new SoundPlayer(Properties.Resources.theme);
    }
}
