using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private void Awake()
    {
        Player.AiPlayTurn += StartAiTurn;
    }

    private void StartAiTurn(Player player)
    {
        if (!AiTurn(player.Pawns))
        {
            gameManager.ChangeTurn();
        }
    }

    private bool AiTurn(List<Pawn> pawns)
    {
        if (pawns.Count == 0) return false;

        List<Cell> clicks = SelectClick(pawns);

        TurnClick(clicks);

        return true;
    }

    private void TurnClick(List<Cell> clicks)
    {
        int rand2 = UnityEngine.Random.Range(0, clicks.Count);

        gameManager.ClickOnCell(clicks[rand2].Position);
    }

    private List<Cell> SelectClick(List<Pawn> pawns)
    {
        int pawnNum = UnityEngine.Random.Range(0, pawns.Count);

        List<Cell> clicks = gameManager.ClickOnCell(pawns[pawnNum].Position);

        if (clicks.Count == 0)
        {
            return SelectClick(pawns);
        }

        return clicks;
    }
}
