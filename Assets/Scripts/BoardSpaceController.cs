using UnityEngine;

namespace TicTacToe
{
    public class BoardSpaceController : MonoBehaviour
    {
        public GameObject xPiece;
        public GameObject oPiece;
        private BoardSpace[] boardSpaces;

        void Awake()
        {
            boardSpaces = GetComponentsInChildren<BoardSpace>();
            EventManager.OnMove += OnPlayerMove;
        }

        private void OnPlayerMove(Vector2Int position, IPlayer player)
        {
            // find boardSpace
            BoardSpace boardSpace = null;
            foreach (var space in boardSpaces)
            {
                if (space.GetBoardPosition() == position)
                {
                    boardSpace = space;
                }
            }

            if (boardSpace == null)
            {
                return;
            }

            // create animated board piece
            Vector3 boardSpaceWorldPosition = boardSpace.transform.position;
            GameObject animatedPiece = player.ID == 1 ? Instantiate(xPiece) : Instantiate(oPiece);
            animatedPiece.transform.position = boardSpaceWorldPosition;
        }
    }
}