using UnityEngine;
using TMPro;

namespace TicTacToe
{
    public class UIManager : MonoBehaviour
    {
        public TMP_Text playerTurnText;
        public GameObject endGamePanel;
        public TMP_Text endGameMessage;

        private void Start()
        {
            playerTurnText.text = "Player 1's turn";
        }

        private void OnEnable()
        {
            EventManager.OnGameEnd += OnGameEnd;
            EventManager.OnMove += OnPlayerMove;
        }

        private void OnDisable()
        {
            EventManager.OnGameEnd -= OnGameEnd;
            EventManager.OnMove -= OnPlayerMove;
        }

        private void OnPlayerMove(Vector2Int position, IPlayer player)
        {
            int nextPlayerId = (player.ID % 2) + 1;
            playerTurnText.text = "Player " + nextPlayerId + "'s turn";
        }

        private void OnGameEnd(IPlayer winner)
        {
            playerTurnText.gameObject.SetActive(false);
            endGamePanel.SetActive(true);
            if (winner == null)
            {
                endGameMessage.text = "It's a tie!";
            }
            else
            {
                endGameMessage.text = "Player " + winner.ID + " wins!";
            }
        }
    }
}