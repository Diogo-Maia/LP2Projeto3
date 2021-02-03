using UnityEngine;

namespace Game
{
    public class Buttons : MonoBehaviour
    {
        [SerializeField]
        private InputManager im;

        public void Click()
        {
            im.Pressed();
        }
    }
}

