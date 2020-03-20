using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    public bool puzzleEngaged { get; private set; } = false;

    private UIController uIController;

    void Awake()
    {
        if (instance != null)
            throw new System.Exception("Cannot have more than one GameController instance in a scene");

        instance = this;
    }

    void Start()
    {
        uIController = UIController.instance;
        if (uIController == null)
            throw new System.Exception("No UIController present");
    }

    public void EngagePuzzle()
    {
        puzzleEngaged = true;
        Cursor.lockState = CursorLockMode.None;
        uIController.SetCrosshairState(CrosshairState.Disabled);
        uIController.ShowPuzzleScreen();
    }

    public void DisengagePuzzle()
    {
        puzzleEngaged = false;
        Cursor.lockState = CursorLockMode.Locked;
        uIController.SetCrosshairState(CrosshairState.Enabled);
    }
}
