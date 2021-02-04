using UnityEngine;
using Common.Files;
using System.Threading;

namespace Game
{
    /// <summary>
    /// Class MainGame()
    /// </summary>
    public class MainGame : MonoBehaviour
    {
        // Variable input.
        private IInputController input;

        // Variable view.
        private IView iv;

        // Variable for the game manager.
        private GameManager gm;

        /// <summary>
        /// Method start.
        /// </summary>
        private void Start()
        {
            input = GetComponent<InputManager>();
            iv = GetComponent<View>();

            gm = new GameManager(input, iv);

            Thread game = new Thread(new ThreadStart(gm.GameLoop));
            game.Start();
        }
    }
}

