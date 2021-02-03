using UnityEngine;
using Common.Files;

namespace Game
{
    public class View : MonoBehaviour, IView
    {
        public string text;
        public string gameboard;
        public string directions;

        public bool win;
        public Player winner;

        private void Start()
        {
            text = "";
            gameboard = "";
            directions = "";
            win = false;
        }

        public void ChooseMenu()
        {
            text = "Choose who plays first Bottom(W) or Top(B)";
        }

        public void MainMenu()
        {
            //Shown in different scene
        }

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

        public void Win(Player winner)
        {
            win = true;
            this.winner = winner;
        }
    }
}

