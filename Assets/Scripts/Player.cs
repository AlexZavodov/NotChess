using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player
{
    public List<Pawn> Pawns { get; set; } = new List<Pawn>();

    public bool IsHuman { get; set; } = true;

    private bool myTurn = false;
    public bool MyTurn
    {
        get
        {
            return myTurn;
        }
        set
        {
            myTurn = value;
            if (myTurn && !IsHuman)
            {
                AiPlayTurn?.Invoke(this);
            }
        }
    }

    public static event Action<Player> AiPlayTurn;

    public void ClearPawns()
    {
        foreach (Pawn pawn in Pawns)
        {
            GameObject.Destroy(pawn.gameObject);
        }

        Pawns.Clear();
    }
}
