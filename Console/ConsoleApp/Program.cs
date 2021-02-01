using System;
using Common.Files;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IInputController input = null;
            GameManager gm = new GameManager(input);
            IView cv = new ConsoleView();

            cv.MainMenu();
            gm.GameLoop();
        }
    }
}
