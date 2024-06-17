using UnityEngine;

namespace TicTacToe
{
    public class HumanPlayer : IPlayer
    {
        public int ID { get; private set; }
        private BoardManager boardManager;

        public HumanPlayer(int id, BoardManager boardManager)
        {
            ID = id;
            this.boardManager = boardManager;
        }

        public void MakeMove()
        {
            InputManager.OnMoveInput += HandleMoveInput;
        }

        private void HandleMoveInput(Vector2Int boardPosition)
        {
            if (!boardManager.IsSpaceOccupied(boardPosition))
            {
                EventManager.ProcessMoveEvent(boardPosition, this);
                InputManager.OnMoveInput -= HandleMoveInput;
            }
        }
    }
}
