using System;
using Common.Files;

namespace ConsoleApp
{
    public class ConsoleControler: IInputController
    {
        public string GetsPiece()
        {
            return Console.ReadLine();
        }

        public string GetsDirection()
        {
            return Console.ReadLine();
        }

        public string GetsPlayer()
        {
            return Console.ReadLine();
        }
    }
}
