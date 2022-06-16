using WMPLib;

namespace ConsoleMusicPlayer
{
    internal class SingletonPlayer
    {
        public WindowsMediaPlayer Player { get; set; }
        private static SingletonPlayer instance;

        private SingletonPlayer()
        {
            Player = new WindowsMediaPlayer();
        }

        public static SingletonPlayer GetInstance()
        {
            if (instance == null)
            {
                instance = new SingletonPlayer();
            }

            return instance;
        }
    }
}