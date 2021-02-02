using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class Menu : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene(1);
        }

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
