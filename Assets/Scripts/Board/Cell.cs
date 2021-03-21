using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Cell : MonoBehaviour
{
    public Vector2Int Position { get; set; }

    [SerializeField] private UnityEvent onSelected;
    [SerializeField] private UnityEvent onDeselected;

    //нужно для Board2
    public static Action<Cell> CellSpawned;

    public void Start()
    {
        CellSpawned?.Invoke(this);
    }

    public void Select()
    {
        onSelected?.Invoke();
    }

    public void Deselect()
    {
        onDeselected?.Invoke();
    }

}
