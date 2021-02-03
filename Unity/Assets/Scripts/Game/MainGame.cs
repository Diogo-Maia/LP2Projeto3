using UnityEngine;
using Common.Files;
using System.Threading;

namespace Game
{
    public class MainGame : MonoBehaviour
    {
        private IInputController input;
        private IView iv;

        private GameManager gm;

        private void Start()
        {
            input = GetComponent<InputManager>();
            iv = GetComponent<View>();

            gm = new GameManager(input, iv);

            iv.MainMenu();
            Thread game = new Thread(new ThreadStart(gm.GameLoop));
            game.Start();
        }
    }
}

