using UnityEngine;

namespace TicTacToe
{
    public class BoardManager : MonoBehaviour
    {
        private int[,] board;

        public void InitializeBoard()
        {
            board = new int[3, 3];
        }

        public int[,] GetBoard()
        {
            return board;
        }

        public void MakeMove(Vector2Int position, IPlayer player)
        {
            board[position.x, position.y] = player.ID;
        }

        public bool IsSpaceOccupied(Vector2Int position)
        {
            return board[position.x, position.y] != 0;
        }

        public bool CheckTie()
        {
            // Check if all spaces are occupied
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (board[x, y] == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool CheckWin()
        {
            // Check rows and columns
            for (int i = 0; i < 3; i++)
            {
                if (IsWinningLine(board[i, 0], board[i, 1], board[i, 2]) || // check rows
                    IsWinningLine(board[0, i], board[1, i], board[2, i])) // check columns
                {
                    return true;
                }
            }

            // Check diagonals
            if (IsWinningLine(board[0, 0], board[1, 1], board[2, 2]) || // top-left to bottom-right
                IsWinningLine(board[0, 2], board[1, 1], board[2, 0])) // top-right to bottom-left
            {
                return true;
            }

            return false;
        }

        private bool IsWinningLine(int a, int b, int c)
        {
            return (a != 0) && (a == b) && (b == c);
        }
    }
}