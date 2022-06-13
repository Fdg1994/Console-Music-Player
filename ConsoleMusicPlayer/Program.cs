using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace ConsoleMusicPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WindowsMediaPlayer player = new WindowsMediaPlayer();
            FrontEnd frontEnd = new FrontEnd(player);
            BackEnd backEnd = new BackEnd(frontEnd,player);
            

            backEnd.ShowMainMenu();                
        }
    }
}
