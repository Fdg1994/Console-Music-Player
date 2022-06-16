using System;
using WMPLib;

namespace ConsoleMusicPlayer
{
    public class FrontEnd
    {
        private WindowsMediaPlayer player;

        public FrontEnd()
        {
            player = SingletonPlayer.GetInstance().Player;
        }

        public void ShowTitle()
        {
            string title = @"
    __  ___           _         ____  __
   /  |/  /_  _______(_)____   / __ \/ /___ ___  _____  _____
  / /|_/ / / / / ___/ / ___/  / /_/ / / __ `/ / / / _ \/ ___/
 / /  / / /_/ (__  ) / /__   / ____/ / /_/ / /_/ /  __/ /
/_/  /_/\__,_/____/_/\___/  /_/   /_/\__,_/\__, /\___/_/
                                          /____/
";
            Console.WriteLine(title);
        }

        private void ShowPlayScreen()
        {
            Console.WriteLine("╔══════════════════════════════════════════ ══ ═ ═");
            ShowSongInfo();
            Console.Write("║ \n");
            ShowCurrentVolume();
            Console.Write("\n" + "\n");
        }

        public string GetUserInput()
        {
            Console.Clear();
            ShowTitle();
            Console.WriteLine("Enter a file to play (don't forget to include the proper file extension!):");
            string input = Console.ReadLine();
            return input;
        }

        public void ShowMainMenu()
        {
            ShowTitle();
            ShowPlayScreen();
            Console.WriteLine("╔══════════════════════════════════════════ ══ ═ ═");
            Console.WriteLine("║ 1. Find song\n" + "║ 2. Change volume\n" + "║ 3. Mute/Unmute\n" + "║ 4. Pause/Resume\n" + "║ 5. Stop\n" + "║ 6. Exit\n");
        }

        private void ShowCurrentVolume()
        {
            int volume = player.settings.volume;
            string soundBar = "";

            for (int i = 0; i < volume; i += 5)
            {
                soundBar += "█";
            }
            if (player.settings.mute == true)
            {
                Console.WriteLine($"║ Volume muted");
            }
            else
            {
                Console.WriteLine($"║ Volume {volume}% {soundBar}");
            }
        }

        private void ShowSongInfo()
        {
            if (player.playState == WMPPlayState.wmppsPlaying)
            {
                Console.WriteLine("║ Title: " + player.currentMedia.getItemInfo("Title"));
                Console.WriteLine("║ Artist: " + player.currentMedia.getItemInfo("Artist"));
                Console.WriteLine("║ Album: " + player.currentMedia.getItemInfo("Album"));
                Console.WriteLine("║ ");
                Console.WriteLine("║ Playing... ►");
            }
            else if (player.playState == WMPPlayState.wmppsPaused)
            {
                Console.WriteLine("║ Title: " + player.currentMedia.getItemInfo("Title"));
                Console.WriteLine("║ Artist: " + player.currentMedia.getItemInfo("Artist"));
                Console.WriteLine("║ Album: " + player.currentMedia.getItemInfo("Album"));
                Console.WriteLine("║ ");
                Console.WriteLine("║ Paused ‼");
            }
            else
            {
                Console.WriteLine("║ Title: ");
                Console.WriteLine("║ Artist: ");
                Console.WriteLine("║ Album: ");
                Console.WriteLine("║ ");
                Console.WriteLine("║ Stopped ■");
            }
        }
    }
}