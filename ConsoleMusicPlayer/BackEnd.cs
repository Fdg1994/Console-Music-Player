using System;
using WMPLib;

namespace ConsoleMusicPlayer
{
    public class BackEnd
    {
        //todo dependency injection
        private WindowsMediaPlayer player;
        private FrontEnd frontEnd;

        public BackEnd(FrontEnd front, WindowsMediaPlayer wmp)
        {
            frontEnd = front;
            player = wmp;
        }

        public void PlayUserInput()
        {
            string musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            player.URL = System.IO.Path.Combine(musicFolder, frontEnd.GetUserInput());

            player.controls.play();
            ShowMainMenu();

            PlayUserInput();
        }

        internal void ShowMainMenu()
        {
            frontEnd.ShowMainMenu();
            HandleUserChoice();
        }

        public void HandleUserChoice()
        {
            int menuSelect = int.Parse(Console.ReadLine()) - 1;

            Console.Clear();
            switch (menuSelect) //ToDo add enum
            {
                case 0:
                    PlayUserInput();
                    break;

                case 1:
                    Console.WriteLine("Set volume level:");
                    frontEnd.ShowCurrentVolume();
                    SetVolume();
                    ShowMainMenu();
                    break;

                case 2:
                //play/pause

                case 3:
                // stop song

                case 4:
                    Console.WriteLine("Made by Frederik De Gottal");
                    Console.ReadLine();
                    ShowMainMenu();
                    break;

                case 5:
                    Environment.Exit(0);
                    break;
            }
        }

        public void SetVolume()
        {
            //ToDo handle invalid input (tryparse)
            int volume = int.Parse(Console.ReadLine());

            if (volume >= 0 && volume <= 100)
            {
                Console.WriteLine($"Volume set to {volume}");
                player.settings.volume = volume;
            }
            else
            {
                Console.WriteLine("Invalid value, try again!");
                SetVolume();
            }
        }

        public void PausePlaySong()
        {
        }
    }
}