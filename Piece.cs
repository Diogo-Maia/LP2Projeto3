namespace Common.Files
{
    /// <summary>
    /// Class that represents a game piece.
    /// </summary>
    public class Piece
    {
        /// <summary>
        /// Gets or sets column where the piece is in.
        /// </summary>
        public int Col { get; set; }

        /// <summary>
        /// Gets or Sets the row where the piece is in.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Gets or sets the previous Column.
        /// </summary>
        public int PreviousCol { get; set; }

        /// <summary>
        /// Gets or sets the previous row.
        /// </summary>
        public int PreviousRow { get; set; }

        /// <summary>
        /// Gets the Id.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the volor of the piece.
        /// </summary>
        public PieceColor Color { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the piece
        /// is blocked or not.
        /// </summary>
        public bool IsBlocked { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Piece"/> class.
        /// Constructor of the class.
        /// </summary>
        /// <param name="row">Row of the Piece.</param>
        /// <param name="col">Collumn of the piece.</param>
        /// <param name="id">ID of the piece.</param>
        /// <param name="color">Color of the piece.</param>
        public Piece(int row, int col, int id, PieceColor color)
        {
            this.Row = row;
            this.Col = col;
            this.Id = id;
            this.Color = color;
        }

        /// <summary>
        /// Method to move the piece.
        /// </summary>
        /// <param name="dir">Direction to move.</param>
        public void MoveTo(Directions dir)
        {
            this.PreviousCol = this.Col;
            this.PreviousRow = this.Row;

            switch (dir)
            {
                case Directions.NE:
                    this.Col++;
                    this.Row--;
                    break;

                case Directions.N:
                    this.Row--;
                    break;

                case Directions.NO:
                    this.Col--;
                    this.Row--;
                    break;

                case Directions.E:
                    if (this.Row == 0 || this.Row == 4)
                    {
                        this.Col += 2;
                    }
                    else
                    {
                        this.Col++;
                    }

                    break;

                case Directions.O:
                    if (this.Row == 0 || this.Row == 4)
                    {
                        this.Col -= 2;
                    }
                    else
                    {
                        this.Col--;
                    }

                    break;

                case Directions.SE:
                    this.Col++;
                    this.Row++;
                    break;

                case Directions.S:
                    this.Row++;
                    break;

                case Directions.SO:
                    this.Col--;
                    this.Row++;
                    break;
            }
        }

        /// <summary>
        /// Method to reset the movment of the piece.
        /// </summary>
        public void ResetMovement()
        {
            this.Row = this.PreviousRow;
            this.Col = this.PreviousCol;
        }
    }
}
