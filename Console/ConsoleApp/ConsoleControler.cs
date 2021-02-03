// <copyright file="ConsoleControler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ConsoleApp
{
    using System;
    using Common.Files;

    /// <summary>
    /// Class to control Input.
    /// </summary>
    public class ConsoleControler : IInputController
    {
        /// <summary>
        /// Chooses the piece.
        /// </summary>
        /// <returns>The input.</returns>
        public string GetsPiece()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Chooses the direction.
        /// </summary>
        /// <returns>The input.</returns>
        public string GetsDirection()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Chooses the player.
        /// </summary>
        /// <returns>The input.</returns>
        public string GetsPlayer()
        {
            return Console.ReadLine();
        }
    }
}
