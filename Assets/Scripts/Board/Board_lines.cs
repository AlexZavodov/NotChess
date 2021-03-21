using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// доска с перетаскиванием в инспекторе
// верим что перетащили в правильном порядке
public class Board_lines : Board
{   
    [SerializeField] List<Line> lines;
    

    private void Awake()
    {
        Cells = new Cell[BoardSize.x, BoardSize.y];

        for (int i = 0; i < BoardSize.x; i++)
            for (int j = 0; j < BoardSize.y; j++)
            {
                Cells[i, j] = lines[j].Cells[i];
                Cells[i, j].Position = new Vector2Int(i, j);
            }
    }
}
