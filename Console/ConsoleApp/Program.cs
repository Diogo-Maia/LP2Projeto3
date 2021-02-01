using System;
using Common.Files;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            ConsoleView cv = new ConsoleView();

            cv.MainMenu();
            gm.GameLoop();
        }
    }
}
