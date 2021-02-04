using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    /// <summary>
    /// Class TextUI.
    /// </summary>
    public class TextUI : MonoBehaviour
    {
        // View variable.
        [SerializeField]
        private View v;

        // View variable.
        [SerializeField]
        private Text t;

        // Variable for the gameboard.
        [SerializeField]
        private Text gameboard;

        // Variable for directions.
        [SerializeField]
        private Text directions;

        // Variable for the win menu.
        [SerializeField]
        private GameObject winMenu;

        // Variable for the text menu.
        [SerializeField]
        private Text winText;

        // Update is called once per frame
        void Update()
        {
            //Se a montanha nao vai a maome, vai maome a montanha
            if (!v.win)
            {
                t.text = v.text;
                gameboard.text = v.gameboard;
                directions.text = v.directions;
            }
            else
            {
                winMenu.SetActive(true);
                winText.text = $"Player {v.winner.Id} wins!!!!";
            }
            
        }

        /// <summary>
        /// Return() method that goes back to the Menu.
        /// </summary>
        public void Return()
        {
            SceneManager.LoadScene(0);
        }

    }
}

