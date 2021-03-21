using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Board board;
    [SerializeField] Rules rules;

    [SerializeField] Pawn prefabBlackPawn;
    [SerializeField] Pawn prefabWhitePawn;

    [SerializeField] CanvasManager canvasManager;
    Settings settings;

    Player[] players = new Player[3] { new Player(), new Player(), new Player() };

    Vector2Int size;

    int[,] gameBoard;
    int[,] winPosition;

    /// <summary>
    /// 
    /// </summary>
    /// 
    List<Vector2Int> possibleMoves;
    Vector2Int selected;
    Pawn pawnSelected;

    bool isSelected = false;
    bool gameEnd = false;

    public Vector2Int Size
    {
        get
        {
            return size;
        }
    }
    public int[,] GameBoard
    {
        get
        {
            return gameBoard;
        }
    }

    int Turn
    {
        get
        {
            if (players[1].MyTurn)
                return 1;
            else
            if (players[2].MyTurn)
                return 2;
            else
                return 0;
        }
    }

    private void Awake()
    {
        size = board.BoardSize;
        gameBoard = new int[size.x, size.y];
        winPosition = new int[size.x, size.y];

        possibleMoves = new List<Vector2Int>();

        settings = FindObjectOfType<Settings>();
        players[2].IsHuman = settings.IsEnemyHuman;
        canvasManager.ChangeName(settings.name_);
    }

    public void NewGame()
    {   
        for (int i = 0; i < size.x; i++)
            for (int j = 0; j < size.y; j++)
            {
                gameBoard[i, j] = 0;
                winPosition[i, j] = 0;
            }
        isSelected = false;
        gameEnd = false;

        players[1].ClearPawns();
        players[2].ClearPawns();

        Pawn pawn;
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            {
                pawn = Instantiate(prefabWhitePawn, board.Cells[size.x - i - 1, j].transform);
                pawn.Position = new Vector2Int(size.x - i - 1, j);
                players[1].Pawns.Add(pawn);

                gameBoard[size.x - i - 1, j] = 1;
                winPosition[size.x - i - 1, j] = 2;

                pawn = Instantiate(prefabBlackPawn, board.Cells[i, size.y - j - 1].transform);
                pawn.Position = new Vector2Int(i, size.y - j - 1);
                players[2].Pawns.Add(pawn);

                gameBoard[i, size.y - j - 1] = 2;
                winPosition[i, size.y - j - 1] = 1;
            }

        players[1].MyTurn = true;
        players[2].MyTurn = false;
        canvasManager.ChangeTurn(Turn);
    }


    public List<Cell> ClickOnCell(Vector2Int cellPosition)
    {
        List<Cell> cells = new List<Cell>();
        selected = cellPosition;

        if (MovePawn()) 
        {
            ChangeTurn();
        }

        possibleMoves.Clear();
        isSelected = false;

        if (SelectedPawn())
        {
            isSelected = true;
        }

        foreach (Vector2Int move in possibleMoves)
        {
            cells.Add(board.Cells[move.x, move.y]);
        }
        
        return cells;
    }

    private bool SelectedPawn()
    {
        if (gameBoard[selected.x, selected.y] == Turn && Turn != 0 && !gameEnd)
        {
            pawnSelected = players[Turn].Pawns.Find(value => value.Position == selected);
            possibleMoves = rules.PossibleMoves(selected);
            return true;
        }
        return false;
    }

    private bool MovePawn()
    {
        if (isSelected == true && possibleMoves.FindIndex(value => value == selected) != -1)
        {
            gameBoard[selected.x, selected.y] = gameBoard[pawnSelected.Position.x, pawnSelected.Position.y];
            gameBoard[pawnSelected.Position.x, pawnSelected.Position.y] = 0;

            pawnSelected.transform.position = board.Cells[selected.x, selected.y].transform.position;
            pawnSelected.transform.parent = board.Cells[selected.x, selected.y].transform;
            pawnSelected.Position = selected;

            if (WinLose()) 
            {
                canvasManager.ChangeTurn(Turn, true);
                return false;
            }
            
            return true;
        }

        return false;
    }

    private bool WinLose()
    {
        bool win = true;

        for (int i = 0; i < size.x; i++)
            for (int j = 0; j < size.y; j++)
            {
                if (winPosition[i, j] == Turn && gameBoard[i, j] != Turn)
                    win = false;
            }

        if (win)
        {
            gameEnd = true;
            return true;
        }

        return false;
    }

    public void ChangeTurn()
    {
        players[1].MyTurn = !players[1].MyTurn;
        players[2].MyTurn = !players[2].MyTurn;

        canvasManager.ChangeTurn(Turn);
    }

    public bool IsTurnHuman()
    {
        return players[Turn].IsHuman;
    }
}
