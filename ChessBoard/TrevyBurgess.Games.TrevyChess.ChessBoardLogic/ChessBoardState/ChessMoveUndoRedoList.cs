//
//
namespace TrevyBurgess.Games.TrevyChess.ChessBoardLogic
{
    using System.Collections.Generic;

    /// <summary>
    /// Manage chess board UndoRedo list.
    /// </summary>
    public class ChessMoveUndoRedoList
    {
        private LinkedList<string> undoList;

        /// <summary>
        /// Current chess move
        /// </summary>
        private LinkedListNode<string> currentMove;

        /// <summary>
        /// Keep track of how many moves passed since game started
        /// </summary>
        public int MoveCount { get; internal set; }

        /// <summary>
        /// Create undo list, starting with first move
        /// </summary>
        internal ChessMoveUndoRedoList(string move)
        {
            undoList = new LinkedList<string>();
            currentMove = new LinkedListNode<string>(move);
            undoList.AddLast(currentMove);
            MoveCount = 1;
        }

        /// <summary>
        /// Add move to list of moves
        /// </summary>
        internal void AddMoveToUndoList(string boardLayout)
        {
            if (undoList.Count > MoveCount)
            {
                // Discard moves, since they are being replaced
                while (undoList.Count > MoveCount)
                {
                    undoList.RemoveLast();
                }
            }

            // Add new move
            currentMove = new LinkedListNode<string>(boardLayout);
            undoList.AddLast(currentMove);
            MoveCount++;
        }

        /// <summary>
        /// Return true if previous state exists
        /// </summary>
        internal bool CanGetPreviousState()
        {
            if (currentMove.Previous == null)
                return false;
            else return true;
        }

        /// <summary>
        /// Return true if next state exists
        /// </summary>
        internal bool CanGetNextState()
        {
            LinkedListNode<string> node = currentMove.Next;
            if (node == null)
                return false;
            else return true;
        }

        /// <summary>
        /// Gets the previous board state
        /// </summary>
        /// <returns>Previous state of board</returns>
        internal string GetPreviousMove()
        {
            if (currentMove.Previous == null)
            {
                throw new IllegalMoveException("Can't Undo Move");
            }
            else
            {
                currentMove = currentMove.Previous;
                MoveCount--;

                return currentMove.Value;
            }
        }

        /// <summary>
        /// Gets the next moard state
        /// </summary>
        /// <returns>Next state of board</returns>
        internal string GetNextMove()
        {
            if (currentMove.Next == null)
            {
                throw new IllegalMoveException("Can't Undo Move");
            }
            else
            {
                currentMove = currentMove.Next;
                MoveCount++;

                return currentMove.Value;
            }
        }
    }
}
