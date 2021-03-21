using System.Collections.Generic;
using UnityEngine;

// связывающий правила c менеджером и канвасом
public class Rules : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    List<IRule> rules = new List<IRule>();

    List<bool> boolRules = new List<bool>();

    private void Start()
    {
        boolRules.Add(true);
        boolRules.Add(true);
        boolRules.Add(true);
    }

    public void BoolRules(int num)
    {
        boolRules[num] = !boolRules[num];
    }

    public void StartGame()
    {
        if (boolRules[0]) rules.Add(new Rule1(gameManager.Size));
        if (boolRules[1]) rules.Add(new Rule2(gameManager.Size));
        if (boolRules[2]) rules.Add(new Rule3(gameManager.Size));
    }

    public List<Vector2Int> PossibleMoves(Vector2Int position)
    {
        List<Vector2Int> moves = new List<Vector2Int>();
        List<Vector2Int> moveRule;

        foreach (IRule rule in rules)
        {
            moveRule = rule.PossibleMoves(gameManager.GameBoard, position);

            foreach(Vector2Int move in moveRule)
            {
                moves.Add(move);
            }
        }

        return moves;
    }

}
