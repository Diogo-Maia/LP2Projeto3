namespace Common.Files
{
    using System;

    /// <summary>
    /// Class Gamanager.
    /// </summary>
    public class GameManager
    {
        /// <summary>
        /// Represents the game board.
        /// </summary>
        public readonly Square[,] gameGrid;

        /// <summary>
        /// Iterface for input.
        /// </summary>
        private readonly IInputController input;

        /// <summary>
        /// Interface for Ui.
        /// </summary>
        private readonly IView view;

        /// <summary>
        /// Represents player 1.
        /// </summary>
        private Player p1;

        /// <summary>
        /// Represents player 2.
        /// </summary>
        private Player p2;

        /// <summary>
        /// Represents the current player playing.
        /// </summary>
        private Player turn;

        /// <summary>
        /// Represents current Piece.
        /// </summary>
        private Piece cPiece;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameManager"/> class.
        /// Constructor of the class.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="view"></param>
        public GameManager(IInputController input, IView view)
        {
            this.input = input;

            this.view = view;

            // Instanciates the grid
            this.gameGrid = new Square[5, 5];

            // Spawns the pieces
            this.SpawnPieces();

            // Sets all possible movements
            this.PossibleMoves();
        }

        /// <summary>
        /// Game loop method.
        /// </summary>
        public void GameLoop()
        {
            // Get the players and respective colors
            this.GetPlayers();

            // Make player 1 play
            this.turn = this.p1;

            // Update the Blocked Pieces
            this.UpdateBlockedPieces();

            // Play a turn
            while (true)
            {
                // Player chooses a piece to play
                this.ChoosePiece();

                // Chooses the direction to move the piece and moves the piece
                this.MoveDirection();

                // If a player wins, clear the board and show the winner.
                if (this.Win())
                {
                    // Clears the console
                    Console.Clear();

                    this.view.Win(this.turn);

                    // Breaks the game loop
                    break;
                }

                // Changes the player who is playing
                this.ChangeTurn();
            }
        }

        /// <summary>
        /// Chooses the direction to where the piece should go and move.
        /// </summary>
        private void MoveDirection()
        {
            // Empry string
            string c = string.Empty;

            // Movement Tuple
            (bool, int, int, bool) mov = (false, 0, 0, false);

            while (!mov.Item1)
            {
                // Makes the player choose a direction between 0 - 7
                while (c != "0" && c != "1" && c != "2" && c != "3" && c != "4"
                    && c != "5" && c != "6" && c != "7")
                {
                    this.view.Render(this.gameGrid);

                    this.view.ShowPossibleDirections(
                        this.gameGrid[
                            this.cPiece.Row,
                            this.cPiece.Col].PossibleMovements,
                        this.cPiece);

                    // Gets the player choice
                    c = this.input.GetsDirection();

                    // Checks if piece can be moved in that direction
                    mov = this.CheckMovement(c);

                    // If an unavaliable movement is chosen
                    // display an appropriate message
                    if (!mov.Item1)
                    {
                        // Clears the player input
                        c = string.Empty;

                        Console.WriteLine("Unavailable movement to choose");
                    }
                }
            }

            if (mov.Item4)
            {
                // Moves the piece
                this.cPiece.MoveTo((Directions)Convert.ToInt32(c));

                // Makes the place where the piece was null
                this.gameGrid[this.cPiece.Row, this.cPiece.Col].Piece = null;

                // Resets the movement
                this.cPiece.ResetMovement();

                // Updates the number of pieces each player has
                this.UpdatePieces();
            }

            this.cPiece.Col = mov.Item3;
            this.cPiece.Row = mov.Item2;

            this.gameGrid[this.cPiece.Row, this.cPiece.Col]
                .Piece = this.cPiece;
            this.gameGrid[this.cPiece.PreviousRow, this.cPiece.PreviousCol]
                .Piece = null;

            // Updates the blocked pieces
            this.UpdateBlockedPieces();
        }

        /// <summary>
        /// Method used to see if the piece can move in x direction.
        /// </summary>
        /// <param name="c">Choice of the player.</param>
        /// <returns>Values used to move the piece.</returns>
        private (bool, int, int, bool) CheckMovement(string c)
        {
            bool value = false;
            bool eraseEnemy = false;
            int nRow = 0;
            int nColumn = 0;
            int pRow;
            int pColumn;

            // Check if the player chooses an unavaliable direction
            if (c != "0" && c != "1" && c != "2" && c != "3"
            && c != "4" && c != "5" && c != "6" && c != "7")
            {
                // returns becaus input wasnt between 0 - 7
                return (false, 0, 0, false);
            }
            else
            {
                // Gets the direction the player wanted
                Directions dir = (Directions)Convert.ToInt32(c);

                if (this.gameGrid[this.cPiece.Row, this.cPiece.Col]
                    .HasDirection(dir))
                {
                    this.cPiece.MoveTo(dir);

                    Square targetSq = this.gameGrid
                        [this.cPiece.Row, this.cPiece.Col];
                    pRow = this.cPiece.PreviousRow;
                    pColumn = this.cPiece.PreviousCol;
                    nRow = this.cPiece.Row;
                    nColumn = this.cPiece.Col;

                    if (!targetSq.HasPiece())
                    {
                        value = true;
                    }
                    else
                    {
                        if (this.cPiece.Color != targetSq.Piece.Color &&
                            targetSq.HasDirection(dir))
                        {
                            this.cPiece.MoveTo(dir);
                            nRow = this.cPiece.Row;
                            nColumn = this.cPiece.Col;
                            eraseEnemy = true;

                            value =
                                !this.gameGrid
                                [this.cPiece.Row, this.cPiece.Col].HasPiece();
                        }
                    }

                    this.cPiece.Row = pRow;
                    this.cPiece.Col = pColumn;
                    this.cPiece.PreviousRow = pRow;
                    this.cPiece.PreviousCol = pColumn;
                }

                return (value, nRow, nColumn, eraseEnemy);
            }
        }

        /// <summary>
        /// Method used for the player to choose a piece.
        /// </summary>
        private void ChoosePiece()
        {
            string c = string.Empty;

            this.cPiece = null;

            // Ask the player which piece they wish to choose.
            while (cPiece is null)
            {
                while (c != "1" && c != "2" && c != "3" &&
                    c != "4" && c != "5" && c != "6")
                {
                    Console.Clear();
                    this.view.Render(this.gameGrid);
                    Console.WriteLine($"{this.turn.Id} - {this.turn.Color}" +
                        $" is playing.");
                    Console.WriteLine("Choose the piece you want" +
                        " to play from 1-6.");
                    Console.WriteLine();
                    c = this.input.GetsPiece();
                }

                this.cPiece = this.ChoosenPiece(c);

                // If the chosen piece isn't allowed to be chosen, display 
                // an appropriate message.
                if (this.cPiece is null)
                {
                    Console.WriteLine("Unavailable Piece to choose");
                }
            }
        }

        /// <summary>
        /// Gets the piece.
        /// </summary>
        /// <param name="x">choice of the player.</param>
        /// <returns>Piece the player chooses.</returns>
        private Piece ChoosenPiece(string x)
        {
            Piece piece = null;

            // Gets the piece (with color and ID) the player chooses.
            foreach (Square square in this.gameGrid)
            {
                if (square.HasPiece() && square.Piece.Id == Convert.ToInt32(x)
                    && square.Piece.Color == this.turn.Color
                    && !square.Piece.IsBlocked)
                {
                    piece = square.Piece;
                }
            }

            return piece;
        }

        /// <summary>
        /// Changes the current player playing.
        /// </summary>
        private void ChangeTurn() => this.turn = this.turn ==
            this.p1 ? this.p2 : this.p1;

        /// <summary>
        /// Updates the number of pieces each player has.
        /// </summary>
        private void UpdatePieces()
        {
            if (this.turn == this.p1)
            {
                this.p2.PieceCount--;
            }
            else
            {
                this.p1.PieceCount--;
            }
        }

        /// <summary>
        /// Updates the blocked pieces of the game.
        /// </summary>
        private void UpdateBlockedPieces()
        {
            for (int x = 0; x < this.gameGrid.GetLength(0); x++)
            {
                for (int y = 0; y < this.gameGrid.GetLength(1); y++)
                {
                    if (this.gameGrid[x, y].HasPiece())
                    {
                        bool value = false;

                        foreach (Directions d in
                            this.gameGrid[x, y].PossibleMovements)
                        {
                            value = 
                                this.CheckPos(this.gameGrid[x, y].Piece, d);

                            if (!value)
                            {
                                break;
                            }
                        }

                        this.gameGrid[x, y].Piece.IsBlocked = value;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if a piece can move in a direction.
        /// </summary>
        /// <param name="piece">Piece to move.</param>
        /// <param name="dir">Direction to move.</param>
        /// <returns>True if piece can be moved in that direction.</returns>
        private bool CheckPos(Piece piece, Directions dir)
        {
            int row = piece.Row;
            int column = piece.Col;
            int previousRow = piece.PreviousRow;
            int previousColumn = piece.PreviousCol;
            bool value = false;

            piece.MoveTo(dir);

            // Check if a position on the grid doesn't have another piece and
            // is able to be moved there.
            if (this.gameGrid[piece.Row, piece.Col].HasPiece())
            {
                if (this.gameGrid[piece.Row, piece.Col].Piece.Color != piece.Color)
                {
                    if (this.gameGrid[piece.Row, piece.Col].HasDirection(dir))
                    {
                        piece.MoveTo(dir);
                        if (this.gameGrid[piece.Row, piece.Col].HasPiece())
                        {
                            value = true;
                        }
                    }
                }
                else
                {
                    value = true;
                }
            }

            piece.Row = row;
            piece.Col = column;
            piece.PreviousRow = previousRow;
            piece.PreviousCol = previousColumn;

            return value;
        }

        /// <summary>
        /// Populates the board with pieces.
        /// </summary>
        private void SpawnPieces()
        {
            // Draw the grid
            for (int i = 0; i < this.gameGrid.GetLength(0); ++i)
            {
                for (int j = 0; j < this.gameGrid.GetLength(1); j++)
                {
                    this.gameGrid[i, j] = new Square(Playable.Playable);
                }
            }

            // Spawn each piece with its specific color and position
            // on the grid
            this.gameGrid[0, 0].Piece = new Piece(0, 0, 1, PieceColor.B);
            this.gameGrid[0, 2].Piece = new Piece(0, 2, 2, PieceColor.B);
            this.gameGrid[0, 4].Piece = new Piece(0, 4, 3, PieceColor.B);
            this.gameGrid[1, 1].Piece = new Piece(1, 1, 4, PieceColor.B);
            this.gameGrid[1, 2].Piece = new Piece(1, 2, 5, PieceColor.B);
            this.gameGrid[1, 3].Piece = new Piece(1, 3, 6, PieceColor.B);
            this.gameGrid[3, 1].Piece = new Piece(3, 1, 4, PieceColor.W);
            this.gameGrid[3, 2].Piece = new Piece(3, 2, 5, PieceColor.W);
            this.gameGrid[3, 3].Piece = new Piece(3, 3, 6, PieceColor.W);
            this.gameGrid[4, 0].Piece = new Piece(4, 0, 1, PieceColor.W);
            this.gameGrid[4, 2].Piece = new Piece(4, 2, 2, PieceColor.W);
            this.gameGrid[4, 4].Piece = new Piece(4, 4, 3, PieceColor.W);

            // Spawn each non-playable square on a specific position
            // on the grid
            this.gameGrid[0, 1] = new Square(Playable.NonPlayable);
            this.gameGrid[0, 3] = new Square(Playable.NonPlayable);
            this.gameGrid[1, 0] = new Square(Playable.NonPlayable);
            this.gameGrid[1, 4] = new Square(Playable.NonPlayable);
            this.gameGrid[2, 0] = new Square(Playable.NonPlayable);
            this.gameGrid[2, 1] = new Square(Playable.NonPlayable);
            this.gameGrid[2, 3] = new Square(Playable.NonPlayable);
            this.gameGrid[2, 4] = new Square(Playable.NonPlayable);
            this.gameGrid[3, 0] = new Square(Playable.NonPlayable);
            this.gameGrid[3, 4] = new Square(Playable.NonPlayable);
            this.gameGrid[4, 1] = new Square(Playable.NonPlayable);
            this.gameGrid[4, 3] = new Square(Playable.NonPlayable);
        }

        /// <summary>
        /// Gets the menu to let the players pick the color.
        /// </summary>
        private void GetPlayers()
        {
            string choice = string.Empty;

            while (!string.Equals(
                choice, "W", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(
                    choice, "B", StringComparison.OrdinalIgnoreCase))
            {
                this.view.ChooseMenu();
                choice = this.input.GetsPlayer().ToUpper();
            }

            this.SetPlayers(choice);
        }

        /// <summary>
        /// Sets the players with the respective colors.
        /// </summary>
        /// <param name="choice">Color of the player.</param>
        private void SetPlayers(string choice)
        {
            // If the player chooses W, set its color to white and the
            // opponent's color to black.
            if (string.Equals(choice, "W", StringComparison.OrdinalIgnoreCase))
            {
                this.p1 = new Player(PieceColor.W, 1);
                this.p2 = new Player(PieceColor.B, 2);
            }
            else
            {
                // If the player chooses B, set its color to black
                // and the opponent's color to white.
                this.p1 = new Player(PieceColor.B, 1);
                this.p2 = new Player(PieceColor.W, 2);
            }
        }

        /// <summary>
        /// Makes the possible moves from each board position.
        /// </summary>
        private void PossibleMoves()
        {
            this.gameGrid[0, 0].PossibleMovements
                    = new Directions[] {
                        Directions.E, Directions.SE, };
            this.gameGrid[0, 2].PossibleMovements
                = new Directions[] {
                    Directions.S, Directions.E, Directions.O, };
            this.gameGrid[0, 4].PossibleMovements
                = new Directions[] {
                    Directions.O, Directions.SO, };
            this.gameGrid[1, 1].PossibleMovements
                = new Directions[] {
                    Directions.NO, Directions.E, Directions.SE, };
            this.gameGrid[1, 2].PossibleMovements
                = new Directions[] {
                    Directions.N, Directions.S, Directions.E, Directions.O, };
            this.gameGrid[1, 3].PossibleMovements
                = new Directions[] {
                    Directions.NE, Directions.O, Directions.SO, };
            this.gameGrid[2, 2].PossibleMovements
                = new Directions[] {
                    Directions.NE, Directions.N, Directions.NO,
                    Directions.SO, Directions.S, Directions.SE, };
            this.gameGrid[3, 1].PossibleMovements
                = new Directions[] {
                    Directions.NE, Directions.E, Directions.SO, };
            this.gameGrid[3, 2].PossibleMovements
                = new Directions[] {
                    Directions.N, Directions.S, Directions.E, Directions.O, };
            this.gameGrid[3, 3].PossibleMovements
                = new Directions[] {
                    Directions.NO, Directions.O, Directions.SE, };
            this.gameGrid[4, 0].PossibleMovements
                = new Directions[] {
                    Directions.NE, Directions.E, };
            this.gameGrid[4, 2].PossibleMovements
                = new Directions[] {
                    Directions.O, Directions.E, Directions.N, };
            this.gameGrid[4, 4].PossibleMovements
                = new Directions[] {
                    Directions.O, Directions.NO, };
        }

        /// <summary>
        /// Sees if a player has win.
        /// </summary>
        /// <returns>True if a player won.</returns>
        private bool Win()
        {
            // If the other player has all their pieces blocked, they lose
            // and the current player wins.
            if (this.p1.Color == this.turn.Color)
            {
                if (this.p2.PieceCount == 0 ||
                    this.HasAllPiecesBlocked(this.p2.Color))
                {
                    return true;
                }
            }
            else
            {
                if (this.p1.PieceCount == 0 ||
                    this.HasAllPiecesBlocked(this.p1.Color))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if a player has all his pieces blocked.
        /// </summary>
        /// <param name="color">Color of the player.</param>
        /// <returns>True if all pieces are blocked.</returns>
        private bool HasAllPiecesBlocked(PieceColor color)
        {
            bool value = false;

            // Check if the piece of the current player's color is
            // blocked by all sides
            foreach (Square square in this.gameGrid)
            {
                if (square.HasPiece() && square.Piece.Color == color)
                {
                    if (square.Piece.IsBlocked)
                    {
                        value = true;
                    }
                    else
                    {
                        value = false;
                        break;
                    }
                }
            }

            return value;
        }
    }
}
