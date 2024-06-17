using UnityEngine;

namespace TicTacToe
{
    public class PlayerManager : MonoBehaviour
    {
        private IPlayer[] players;
        private int currentPlayerIndex;
        private BoardManager boardManager;

        public IPlayer CurrentPlayer => players[currentPlayerIndex];

        private void Awake()
        {
            var gameBoard = GameObject.FindWithTag("Game Board");
            if (gameBoard == null)
            {
                Debug.LogWarning("Failed to find game board");
                return;
            }

            boardManager = gameBoard.GetComponent<BoardManager>();
        }

        public void InitializePlayers(int numberOfHumanPlayers)
        {
            players = new IPlayer[2];

            for (int i = 0; i < numberOfHumanPlayers; i++)
            {
                players[i] = new HumanPlayer(i + 1, boardManager);
            }

            for (int i = numberOfHumanPlayers; i < 2; i++)
            {
                players[i] = new AIPlayer(i + 1, boardManager);
            }

            currentPlayerIndex = 0;
        }

        public void SwitchPlayer()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;
        }

        public bool IsPlayerAI(int id)
        {
            foreach (IPlayer player in players)
            {
                if (player.ID == id)
                {
                    return player is AIPlayer;
                }
            }

            return false;
        }
    }
}
