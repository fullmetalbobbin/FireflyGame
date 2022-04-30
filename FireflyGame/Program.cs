using System;

namespace FireflyGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new FireflyGameBase())
                game.Run();
        }
    }
}
