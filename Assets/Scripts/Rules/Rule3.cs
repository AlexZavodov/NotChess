using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule3 : Rule, IRule
{
    public Rule3(Vector2Int size)
    {
        Size = size;
    }

    public List<Vector2Int> PossibleMoves(int[,] gameBoard, Vector2Int pos)
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        for (int i = -1; i <= 1; i++)
            for (int j = -1; j <= 1; j++)
            {
                if (!IsExists(pos.x + i, pos.y + j) || (i == 0 && j == 0)) { continue; }

                if (gameBoard[pos.x + i, pos.y + j] == 0)
                {
                    moves.Add(new Vector2Int(pos.x + i, pos.y + j));
                }
            }

        return moves;
    }
}
