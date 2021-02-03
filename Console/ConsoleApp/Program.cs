// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ConsoleApp
{
    using Common.Files;

    /// <summary>
    /// Program class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main Method.
        /// </summary>
        private static void Main()
        {
            IInputController input = new ConsoleControler();
            IView iv = new ConsoleView();
            GameManager gm = new GameManager(input , iv);

            iv.MainMenu();
            gm.GameLoop();
        }
    }
}
