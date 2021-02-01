using System;
using Common.Files;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IInputController input = new ConsoleControler();
            IView iv = new ConsoleView();
            GameManager gm = new GameManager(input , iv);
            
            iv.MainMenu();
            gm.GameLoop();
        }
    }
}
