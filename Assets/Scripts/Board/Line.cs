using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] List<Cell> cells;

    public List<Cell> Cells
    {
        get
        {
            return cells;
        }
        set
        {
            cells = value;
        }
    }
}
