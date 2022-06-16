using System;
using WMPLib;

namespace ConsoleMusicPlayer
{
    public class BackEnd
    {
        private WindowsMediaPlayer player;

        private FrontEnd frontEnd;

        public BackEnd(FrontEnd front)
        {
            frontEnd = front;
            player = SingletonPlayer.GetInstance().Player;
        }

        private void PlayUserInput()
        {
            frontEnd.ShowTitle();
            string musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            player.URL = System.IO.Path.Combine(musicFolder, frontEnd.GetUserInput());

            if (System.IO.File.Exists(player.URL) == true)
            {
                player.controls.play();
                Console.Clear();
                ShowMainMenu();
            }
            else if (System.IO.File.Exists(player.URL) == false)
            {
                frontEnd.ShowMainMenu();
                Console.WriteLine("The file does not exist in the current directory or the entry is missing an extension!");
                Console.WriteLine("press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                ShowMainMenu();
            }
            PlayUserInput();
        }

        internal void ShowMainMenu()
        {
            frontEnd.ShowMainMenu();
            HandleUserChoice();
        }

        private void HandleUserChoice()
        {
            Enums.MenuChoices menuChoice = (Enums.MenuChoices)GetKeyInput();

            Console.Clear();

            switch (menuChoice)
            {
                case Enums.MenuChoices.PlaySong:
                    PlayUserInput();
                    break;

                case Enums.MenuChoices.ChangeVolume:
                    SetVolume();
                    ShowMainMenu();
                    break;

                case Enums.MenuChoices.MuteUnmute:
                    MuteUnmute();
                    ShowMainMenu();
                    break;

                case Enums.MenuChoices.PauseResume:
                    PauseUnpause();
                    ShowMainMenu();
                    break;

                case Enums.MenuChoices.StopSong:
                    player.controls.stop();
                    ShowMainMenu();
                    break;

                case Enums.MenuChoices.Exit:
                    Environment.Exit(0);
                    break;

                default:
                    frontEnd.ShowMainMenu();
                    Console.WriteLine("Invalid choice (press a number from 1 to 7)");
                    Console.WriteLine("press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    ShowMainMenu();
                    break;
            }
        }

        private void SetVolume()
        {
            frontEnd.ShowTitle();
            Console.WriteLine("Enter the desired volume level (0-100):");
            string inputVolume = Console.ReadLine();
            int volume;
            bool isNum = int.TryParse(inputVolume, out volume);

            if (volume >= 0 && volume <= 100 && isNum == true)
            {
                player.settings.volume = volume;
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Invalid entry!");
                Console.WriteLine("press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                ShowMainMenu();
            }
        }

        private void MuteUnmute()
        {
            player.settings.mute = !player.settings.mute;
        }

        private void PauseUnpause()
        {
            Console.Clear();
            if (player.playState == WMPPlayState.wmppsPlaying)
            {
                player.controls.pause();
            }
            else
            {
                player.controls.play();
            }
        }

        private int GetKeyInput()
        {
            int choice = 0;
            var keyPressed = Console.ReadKey();

            switch (keyPressed.Key)
            {
                case ConsoleKey.NumPad1:
                    {
                        choice = 1;
                        break;
                    }
                case ConsoleKey.NumPad2:
                    {
                        choice = 2;
                        break;
                    }
                case ConsoleKey.NumPad3:
                    {
                        choice = 3;
                        break;
                    }
                case ConsoleKey.NumPad4:
                    {
                        choice = 4;
                        break;
                    }
                case ConsoleKey.NumPad5:
                    {
                        choice = 5;
                        break;
                    }
                case ConsoleKey.NumPad6:
                    {
                        choice = 6;
                        break;
                    }
            }
            return choice;
        }
    }
}