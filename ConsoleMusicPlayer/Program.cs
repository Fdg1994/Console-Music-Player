namespace ConsoleMusicPlayer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FrontEnd frontEnd = new FrontEnd();
            BackEnd backEnd = new BackEnd(frontEnd);

            backEnd.ShowMainMenu();
        }
    }
}