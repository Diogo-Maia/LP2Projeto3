using UnityEngine;
using Common.Files;

namespace Game
{
    /// <summary>
    /// Class view that implements IView
    /// </summary>
    public class View : MonoBehaviour, IView
    {
        public string text;
        public string gameboard;
        public string directions;

        public bool win;
        public Player winner;

        /// <summary>
        /// Method Start()
        /// </summary>
        private void Start()
        {
            text = "";
            gameboard = "";
            directions = "";
            win = false;
        }

        /// <summary>
        /// Method that chooses the menu
        /// </summary>
        public void ChooseMenu()
        {
            text = "Choose who plays first Bottom(W) or Top(B)";
        }

        /// <summary>
        /// Method MainMenu()
        /// </summary>
        public void MainMenu()
        {
            //Shown in different scene
        }

        /// <summary>
        /// Method that renders the game grid
        /// </summary>
        /// <param name="gameGrid"></param>
        public void Render(Square[,] gameGrid)
        {
            gameboard = "";
            for (int x = 0; x < gameGrid.GetLength(0); x++)
            {
                // Iterate through the grid.
                for (int y = 0; y < gameGrid.GetLength(1); y++)
                {
                    gameboard += GetChar(gameGrid[x, y]) + "\t";
                }

                gameboard += "\n\n";
            }

            DrawMov();
        }

        /// <summary>
        /// Method that prints the moviment text
        /// </summary>
        private void DrawMov()
        {
            directions = "";
            directions += "Select the desired direction with your numpad!\n";
            directions += "  5(NO)   0(N)   4(NE)\n";
            directions += "    \\      |      /\n";
            directions += "     \\     |     /\n";
            directions += "      \\    |    /\n";
            directions += "3(O)-------------- 2(E)\n";
            directions += "      /    |    \\ \n";
            directions += "     /     |     \\ \n";
            directions += "    /      |      \\ \n";
            directions += "  7(SO)   1(S)   6(SE)\n";
        }

        /// <summary>
        /// Method that gets a char
        /// </summary>
        /// <param name="square"></param>
        /// <returns></returns>
        private char GetChar(Square square)
        {
            char c = ' ';
            if (square.Piece is null)
            {
                c = square.Type == Playable.Playable ? '\u00B7' : ' ';
            }
            else
            {
                Piece piece = square.Piece;

                // c = (char)piece.Id; //I dont know why it doesnt work had to
                // put it it a switch
                switch (piece.Id)
                {
                    case 1:
                        c = '1';
                        break;

                    case 2:
                        c = '2';
                        break;

                    case 3:
                        c = '3';
                        break;

                    case 4:
                        c = '4';
                        break;

                    case 5:
                        c = '5';
                        break;

                    case 6:
                        c = '6';
                        break;
                }
            }

            return c;
        }

        /// <summary>
        /// Method that shows the possible movement directions
        /// </summary>
        /// <param name="possibleMoves"></param>
        /// <param name="p"></param>
        public void ShowPossibleDirections(Directions[] possibleMoves, Piece p)
        {
            text = "";
            text += "Possible movements:\n";
            foreach (Directions direction in possibleMoves)
            {
                text += direction + ", ";
            }

            text += "\n";
            text += $"Selected Piece: {p.Id}";
            text += "Choose one of the options";
        }

        /// <summary>
        /// Method Win()
        /// </summary>
        /// <param name="winner"></param>
        public void Win(Player winner)
        {
            win = true;
            this.winner = winner;
        }
    }
}

