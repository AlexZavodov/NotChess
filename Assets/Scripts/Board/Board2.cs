using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//доска с обработкой позиций
//верим что не ошиблись больше погрешности
public class Board2 : Board
{
    int cellCount = 0;
    //погрешность расстановки
    float epsilon = 0.1f;

    public void Awake()
    {
        Cell.CellSpawned += AddCell;
        Cells = new Cell[BoardSize.x, BoardSize.y];
    }

    private void AddCell(Cell cell)
    {
        Cells[cellCount / BoardSize.x, cellCount % BoardSize.x] = cell;
        cellCount++;
    }

    public void Start()
    {
        StartCoroutine(SortAtStart()); 
    }

    private IEnumerator SortAtStart()
    {
        yield return null;

        List<float> gridX = CreateGrid(true);
        List<float> gridY = CreateGrid(false);

        Cell[,] sortCells = new Cell[BoardSize.x, BoardSize.y];

        gridX.Sort();
        gridY.Sort();

        Vector2 position;
        int indexX, indexY;
        
        foreach (Cell cell in Cells)
        {
            position = cell.transform.position;

            indexX = gridX.FindIndex(value => Mathf.Abs(position.x - value) < epsilon); 
            indexY = gridY.FindIndex(value => Mathf.Abs(position.y - value) < epsilon);

            sortCells[indexX, indexY] = cell;
            cell.Position = new Vector2Int(indexX, indexY);
        }

        Cells = sortCells;
    }

    private List<float> CreateGrid(bool isX = true)
    {
        List<float> grid = new List<float>();

        float position;
        int index;

        foreach (Cell cell in Cells) 
        {
            position = isX ? cell.transform.position.x
                           : cell.transform.position.y;

            index = grid.FindIndex(value => Mathf.Abs(position - value) < epsilon); 

            if (index == -1) grid.Add(position);
        }

        return grid;
    }
}
