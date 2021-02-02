namespace Common.Files
{
    public interface IView
    {
        void MainMenu();

        void ChooseMenu();

        void Render(Square[,] gameGrid);

        void Win(Player winner);

        void ShowPossibleDirections(Directions[] possibleMoves, Piece p);
    }
}
