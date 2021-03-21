using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Text name_;
    [SerializeField] Text turn;

    private void Start()
    {
    }

    public void ChangeName(string val)
    {
        name_.text = val;
    }

    public void ChangeTurn(int val, bool win = false)
    {
        if (win)
        {
            if (val == 1)
                turn.text = "win Player 1";
            else if (val == 2)
                turn.text = "win Player 2";
            else
                turn.text = "win Somebody";
        }else
        {
            if (val == 1)
                turn.text = "Player 1";
            else if (val == 2)
                turn.text = "Player 2";
            else turn.text = "NoN";
        }
    }
}
