using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    /// <summary>
    /// Class Menu
    /// </summary>
    public class Menu : MonoBehaviour
    {
        /// <summary>
        /// Method that loads the game scene
        /// </summary>
        public void Play()
        {
            SceneManager.LoadScene(1);
        }

        /// <summary>
        /// Method that quits the program
        /// </summary>
        public void Quit()
        {
#if UNITY_STANDALONE
            Application.Quit();
#endif

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
