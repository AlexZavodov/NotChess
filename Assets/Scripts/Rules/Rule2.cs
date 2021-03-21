using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule2 : Rule, IRule
{
    public Rule2(Vector2Int size)
    {
        Size = size;
        pathPawn = new List<Vector2Int>();
    }

    List<Vector2Int> pathPawn;

    int[,] gameBoard;

    public List<Vector2Int> PossibleMoves(int[,] gameBoard1, Vector2Int pos)
    {
        pathPawn.Clear();
        pathPawn.Add(pos);
        gameBoard = gameBoard1;

        pathStep(pos);

        pathPawn.Remove(pos);

        return pathPawn;
    }

    private void pathStep(Vector2Int pos)
    {
        CheckPos(new Vector2Int(pos.x, pos.y - 2), new Vector2Int(pos.x, pos.y - 1));
        CheckPos(new Vector2Int(pos.x, pos.y + 2), new Vector2Int(pos.x, pos.y + 1));
        CheckPos(new Vector2Int(pos.x - 2, pos.y), new Vector2Int(pos.x - 1, pos.y));
        CheckPos(new Vector2Int(pos.x + 2, pos.y), new Vector2Int(pos.x + 1, pos.y));
    }

    private void CheckPos(Vector2Int pos, Vector2Int posJump)
    {
        if (IsExists(pos.x, pos.y))
            if (gameBoard[posJump.x, posJump.y] != 0 && gameBoard[pos.x, pos.y] == 0)
                if (pathPawn.FindIndex(value => pos == value) == -1)
                {
                    pathPawn.Add(pos);
                    pathStep(pos);
                }
    }

}
