using UnityEngine;

namespace Game
{
    /// <summary>
    /// Class Buttons
    /// </summary>
    public class Buttons : MonoBehaviour
    {
        [SerializeField]
        private InputManager im;

        /// <summary>
        /// Method that calls the Pressed() method
        /// </summary>
        public void Click()
        {
            im.Pressed();
        }
    }
}

