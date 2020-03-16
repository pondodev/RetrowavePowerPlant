using System.Collections;
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
        gameController.EngagePuzzle();
    }
}
