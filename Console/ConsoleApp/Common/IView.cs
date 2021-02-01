namespace Common.Files
{
    public interface IView
    {
        public void MainMenu()
        {
            
        }

        public void ChooseMenu()
        {

        }

        public void Render(Square[,] gameGrid)
        {

        }

        public void Win(Player winner)
        {

        }

        public void ShowPossibleDirections(Directions[] possibleMoves, Piece p)
        {

        }
    }
}
