using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pawn : MonoBehaviour
{
    [SerializeField] private Vector2Int position;
    public Vector2Int Position 
    { 
        get
        {
            return position;
        }
        set
        {
            position = value;
        }
    }
}
