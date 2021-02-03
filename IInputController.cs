namespace Common.Files
{
    /// <summary>
    /// Interface to control the input.
    /// </summary>
    public interface IInputController
    {
        /// <summary>
        /// Gets the piece.
        /// </summary>
        /// <returns>input.</returns>
        string GetsPiece();

        /// <summary>
        /// Gets the direction.
        /// </summary>
        /// <returns>input.</returns>
        string GetsDirection();

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <returns>Input.</returns>
        string GetsPlayer();
    }
}
