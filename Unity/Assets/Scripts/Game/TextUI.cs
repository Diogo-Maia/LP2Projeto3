using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class TextUI : MonoBehaviour
    {
        [SerializeField]
        private View v;

        [SerializeField]
        private Text t;

        [SerializeField]
        private Text gameboard;

        [SerializeField]
        private Text directions;

        [SerializeField]
        private GameObject winMenu;

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

        public void Return()
        {
            SceneManager.LoadScene(0);
        }

    }
}

