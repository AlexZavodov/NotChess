using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//правила обязаны реализовывать интерфейс
public interface IRule
{
    public List<Vector2Int> PossibleMoves(int[,] gameBoard, Vector2Int pos);
}
//для облегчения кода
public abstract class Rule
{
    public Vector2Int Size { get; set; }

    public bool IsExists(int x, int y)
    {
        if (x < 0 || x >= Size.x) { return false; }
        if (y < 0 || y >= Size.y) { return false; }

        return true;
    }
}
