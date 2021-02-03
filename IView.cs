namespace Common.Files
{
    /// <summary>
    /// Interface to control the view
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Main Menu display.
        /// </summary>
        void MainMenu();

        /// <summary>
        /// ChooseMenu UI.
        /// </summary>
        void ChooseMenu();

        /// <summary>
        /// Renders the map.
        /// </summary>
        /// <param name="gameGrid">The game board.</param>
        void Render(Square[,] gameGrid);

        /// <summary>
        /// Tells who wins.
        /// </summary>
        /// <param name="winner">The winner.</param>
        void Win(Player winner);

        /// <summary>
        /// Show Directions.
        /// </summary>
        /// <param name="possibleMoves">All possible moves.</param>
        /// <param name="p">A piece.</param>
        void ShowPossibleDirections(Directions[] possibleMoves, Piece p);
    }
}
