using UnityEngine;
using Common.Files;
using UnityEngine.UI;
using System.Threading;

namespace Game
{
    public class InputManager : MonoBehaviour, IInputController
    {
        [SerializeField]
        private InputField getPiece;

        [SerializeField]
        private InputField getDirection;

        [SerializeField]
        private InputField getPlayer;

        [SerializeField]
        private View view;

        private bool x;

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

        public string GetsDirection()
        {
            x = false;
            while (!x)
            {
                Thread.Sleep(100);
            }

            return getDirection.text;
        }

        public string GetsPlayer()
        {
            x = false;
            while (!x)
            {
                Thread.Sleep(100);
            }

            return getPlayer.text;
        }

        public void Pressed()
        {
            x = true;
        }
    }
}

