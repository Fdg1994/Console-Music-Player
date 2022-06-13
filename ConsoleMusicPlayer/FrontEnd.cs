using System;
using WMPLib;

namespace ConsoleMusicPlayer
{
    public class FrontEnd
    {
        
        WindowsMediaPlayer player;

        public FrontEnd(WindowsMediaPlayer wmp)
        {
            
            player = wmp;   
        }

        public void ShowTitle()
        {
            string title = @"
.    .                     .--. .
|\  /|           o         |   )|
| \/ |.  . .--.  .   .-.   |--' |  .-.  .  . .-. .--.
|    ||  | `--.  |  (      |    | (   ) |  |(.-' |
'    '`--`-`--'-' `- `-'   '    `- `-'`-`--| `--''
                                           ;
                                        `-'
";

            Console.WriteLine(title);
        }

        public string GetUserInput()
        {
            Console.WriteLine("Enter a file to play:");
            string input = Console.ReadLine();
            return input;
        }

        public void ShowMainMenu()
        {
            ShowTitle();
            Console.WriteLine("1. Find song\n" + "2. Change volume\n" + "3. Play/Pause\n" + "4. Stop\n" + "5. About\n" + "6. Exit\n");
        
        }

        public void ShowCurrentVolume()
        {
            int volume = player.settings.volume;
            Console.WriteLine($"Current volume: {volume}");
        }
    }
}