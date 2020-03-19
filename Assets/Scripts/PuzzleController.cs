﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour, IInteractable
{
    public PuzzleData data;

    private GameController gameController;
    private UIController uIController;

    void Start()
    {
        gameController = GameController.instance;
        if (gameController == null)
            throw new System.Exception("No GameController present");

        uIController = UIController.instance;
        if (uIController == null)
            throw new System.Exception("No UIController present");
    }

    public void Interact()
    {
        if (data.completed)
        {
            uIController.ShowMessage("Breaker box already fixed");
            return;
        }

        gameController.EngagePuzzle();
        uIController.InitPuzzle(data, this);
    }

    // return true if finised, false if not
    public bool CheckPath()
    {
        // first we clear all the powered states except for the start terminal
        foreach (PuzzlePieceData piece in data.pieces)
        {
            // skip the start terminal
            if (!piece.terminal)
                piece.powered = false;
        }

        // now we check all the things
        Queue<int> indexes = new Queue<int>();
        indexes.Enqueue(data.startTerminalCoord);

        while (indexes.Count != 0)
        {
            int index = indexes.Dequeue();
            int res;
            res = CheckUp(index);
            if (res != -1) indexes.Enqueue(res);

            res = CheckDown(index);
            if (res != -1) indexes.Enqueue(res);

            res = CheckLeft(index);
            if (res != -1) indexes.Enqueue(res);

            res = CheckRight(index);
            if (res != -1) indexes.Enqueue(res);
        }

        data.completed = data.pieces[data.endTerminalCoord].powered;
        uIController.RedrawPuzzle(data.completed);
        if (data.completed) LockPuzzle();
        return data.completed;
    }

    // all these methods will check if there's anything to power in a direction
    // returns the index of the next powered piece, -1 if nothing is powered
    private int CheckUp(int index)
    {
        if (!data.pieces[index].top) return -1;
        if (index + data.width > data.pieces.Length - 1) return -1;

        index += data.width;
        if (data.pieces[index].bottom && !data.pieces[index].powered)
        {
            data.pieces[index].powered = true;
            return index;
        }
        else
        {
            return -1;
        }
    }

    private int CheckDown(int index)
    {
        if (!data.pieces[index].bottom) return -1;
        if (index - data.width < 0) return -1;

        index -= data.width;
        if (data.pieces[index].top && !data.pieces[index].powered)
        {
            data.pieces[index].powered = true;
            return index;
        }
        else
        {
            return -1;
        }
    }

    private int CheckLeft(int index)
    {
        if (!data.pieces[index].left) return - 1;
        if (index - 1 < 0) return - 1;

        index--;
        if (data.pieces[index].right && !data.pieces[index].powered)
        {
            data.pieces[index].powered = true;
            return index;
        }
        else
        {
            return -1;
        }
    }

    private int CheckRight(int index)
    {
        if (!data.pieces[index].right) return -1;
        if (index + 1 > data.pieces.Length - 1) return -1;

        index++;
        if (data.pieces[index].left && !data.pieces[index].powered)
        {
            data.pieces[index].powered = true;
            return index;
        }
        else
        {
            return -1;
        }
    }

    private void LockPuzzle()
    {
        foreach (PuzzlePieceData piece in data.pieces)
        {
            // lmao so jank but it do be workin
            piece.terminal = true;
        }
    }
}
