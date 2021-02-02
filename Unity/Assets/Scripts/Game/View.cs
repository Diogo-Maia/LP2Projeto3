using UnityEngine;
using Common.Files;

namespace Game
{
    public class View : MonoBehaviour, IView
    {
        public void ChooseMenu()
        {
            throw new System.NotImplementedException();
        }

        public void MainMenu()
        {
            throw new System.NotImplementedException();
        }

        public void Render(Square[,] gameGrid)
        {
            throw new System.NotImplementedException();
        }

        public void ShowPossibleDirections(Directions[] possibleMoves, Piece p)
        {
            throw new System.NotImplementedException();
        }

        public void Win(Player winner)
        {
            throw new System.NotImplementedException();
        }

        //private void Awake()
        //{
        //    GameManager gm = new GameManager();
        //
        //    gm.GameLoop();
        //}
    }
}
