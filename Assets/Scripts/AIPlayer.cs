using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class AIPlayer : IPlayer
    {
        public int ID { get; private set; }
        
        private BoardManager boardManager;

        public AIPlayer(int id, BoardManager boardManager)
        {
            ID = id;
            this.boardManager = boardManager;
        }

        public void MakeMove()
        {
            Vector2Int aiMove = CalculateBestMove();
            EventManager.ProcessMoveEvent(aiMove, this);
        }

        private Vector2Int CalculateBestMove()
        {
            int[,] boardState = boardManager.GetBoard();
            
            // get list of valid moves (not occupied)
            List<Vector2Int> availableMoves = new List<Vector2Int>();
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (boardState[x, y] == 0)
                    {
                        availableMoves.Add(new Vector2Int(x, y));
                    }
                }
            }

            // choose a random move
            if (availableMoves.Count > 0)
            {
                int randomIndex = Random.Range(0, availableMoves.Count);
                return availableMoves[randomIndex];
            }

            return Vector2Int.zero;
        }
    }
}
