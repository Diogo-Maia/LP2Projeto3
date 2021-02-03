using UnityEngine;
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

        // Update is called once per frame
        void Update()
        {
            //Se a montanha nao vai a maome, vai maome a montanha
            t.text = v.text;
            gameboard.text = v.gameboard;
            directions.text = v.directions;
        }
    }
}

