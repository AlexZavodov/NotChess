using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������� ��������� ��� ������
public abstract class Board : MonoBehaviour
{
    [SerializeField] Vector2Int boardSize;
    public Cell[,] Cells { get; set; }

    public Vector2Int BoardSize
    {
        get
        {
            return boardSize;
        }
    }

}
