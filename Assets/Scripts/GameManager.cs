using System.Collections;
using UnityEngine;

namespace TicTacToe
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public GameSettings gameSettings;

        private PlayerManager playerManager;
        private BoardManager boardManager;
        private const float aiMoveDelay = 1.0f;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            var gameBoard = GameObject.FindWithTag("Game Board");
            if (gameBoard == null)
            {
                Debug.LogWarning("Failed to find game board");
                return;
            }

            boardManager = gameBoard.GetComponent<BoardManager>();
            playerManager = GetComponent<PlayerManager>();
        }

        private void OnEnable()
        {
            EventManager.OnMove += OnPlayerMove;
        }

        private void OnDisable()
        {
            EventManager.OnMove -= OnPlayerMove;
        }

        private void Start()
        {
            StartNewGame();
        }

        public void StartNewGame()
        {
            boardManager.InitializeBoard();
            playerManager.InitializePlayers(gameSettings.numberOfPlayers);
            playerManager.CurrentPlayer.MakeMove();
        }

        private void OnPlayerMove(Vector2Int position, IPlayer player)
        {
            if (!boardManager.IsSpaceOccupied(position))
            {
                boardManager.MakeMove(position, player);
                if (boardManager.CheckWin())
                {
                    EndGame(player);
                }
                else if (boardManager.CheckTie())
                {
                    EndGame(null);
                }
                else
                {
                    playerManager.SwitchPlayer();
                    StartCoroutine(MoveAfterDelay());
                }
            }
            else
            {
                // space is taken, try again
                player.MakeMove();
            }
        }

        // add slight delay so AI player slows down
        private IEnumerator MoveAfterDelay()
        {
            IPlayer currentPlayer = playerManager.CurrentPlayer;
            if (playerManager.IsPlayerAI(currentPlayer.ID))
            {
                yield return new WaitForSeconds(aiMoveDelay);
            }

            currentPlayer.MakeMove();
        }

        private void EndGame(IPlayer winner)
        {
            EventManager.ProcessGameEndEvent(winner);
        }
    }
}