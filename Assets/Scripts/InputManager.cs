using System;
using UnityEngine;

namespace TicTacToe
{
    public class InputManager : MonoBehaviour
    {
        public static event Action<Vector2Int> OnMoveInput;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                if (hit.collider != null)
                {
                    BoardSpace space = hit.collider.GetComponent<BoardSpace>();
                    if (space != null)
                    {
                        OnMoveInput?.Invoke(space.GetBoardPosition());
                    }
                }
            }
        }
    }
}