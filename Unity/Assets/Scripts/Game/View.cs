using UnityEngine;
using Common.Files;

public class View : MonoBehaviour
{
    private void Awake()
    {
        GameManager gm = new GameManager();

        gm.GameLoop();
    }
}
