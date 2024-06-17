using UnityEngine;

namespace TicTacToe
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "TicTacToe/GameSettings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        public int numberOfPlayers;
    }
}