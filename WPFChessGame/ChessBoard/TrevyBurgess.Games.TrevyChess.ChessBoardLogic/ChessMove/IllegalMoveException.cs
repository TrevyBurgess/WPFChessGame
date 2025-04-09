//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Illegal chess move
    /// </summary>
    public class IllegalMoveException : ApplicationException
    {
        public IllegalMoveException() : base() { }

        public IllegalMoveException(string message) : base(message) { }

        public IllegalMoveException(string message, Exception innerException) : base(message, innerException) { }

        public IllegalMoveException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
