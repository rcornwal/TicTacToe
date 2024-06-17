using System;
using UnityEngine;

namespace TicTacToe
{
    public static class EventManager
    {
        public static event Action<Vector2Int, IPlayer> OnMove;
        public static event Action<IPlayer> OnGameEnd;

        public static void ProcessMoveEvent(Vector2Int position, IPlayer player)
        {
            OnMove?.Invoke(position, player);
        }

        public static void ProcessGameEndEvent(IPlayer winner)
        {
            OnGameEnd?.Invoke(winner);
        }
    }
}