using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TicTacToe
{
    public class BoardSpace : MonoBehaviour
    {
        [SerializeField] private Vector2Int boardPosition;

        public Vector2Int GetBoardPosition()
        {
            return boardPosition;
        }
    }
}