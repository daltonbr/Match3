using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePiece : MonoBehaviour
{

    private GamePiece piece;

    private void Awake()
    {
        piece = GetComponent<GamePiece>();
    }


    public void Move(int newX, int newY)
    {
        piece.X = newX;
        piece.Y = newY;

        piece.transform.localPosition = piece.GridRef.GetWorldPosition(newX, newY);
    }
}
