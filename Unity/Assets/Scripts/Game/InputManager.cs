using UnityEngine;
using Common.Files;
using UnityEngine.UI;
using System.Threading;

namespace Game
{
    /// <summary>
    /// Class InputManager that implements IInputController.
    /// </summary>
    public class InputManager : MonoBehaviour, IInputController
    {
        // Variable getPiece.
        [SerializeField]
        private InputField getPiece;

        // Variable getDirection.
        [SerializeField]
        private InputField getDirection;

        [SerializeField]
        private InputField getPlayer;

        [SerializeField]
        private View view;

        private bool x;

        /// <summary>
        /// Method that gets the piece
        /// </summary>
        /// <returns></returns>
        public string GetsPiece()
        {
            view.text = "Choose a piece from 1 to 5";
            x = false;
            while (!x)
            {
                Thread.Sleep(100);
            }

            return getPiece.text;
        }

        /// <summary>
        /// Method that gets the direction
        /// </summary>
        /// <returns></returns>
        public string GetsDirection()
        {
            x = false;
            while (!x)
            {
                Thread.Sleep(100);
            }

            return getDirection.text;
        }

        /// <summary>
        /// Method that gets the player
        /// </summary>
        /// <returns></returns>
        public string GetsPlayer()
        {
            x = false;
            while (!x)
            {
                Thread.Sleep(100);
            }

            return getPlayer.text;
        }

        /// <summary>
        /// Method that presses
        /// </summary>
        public void Pressed()
        {
            x = true;
        }
    }
}

