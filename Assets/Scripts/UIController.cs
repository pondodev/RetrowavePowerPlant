using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance { get; private set; }

    public Image crosshair;
    public Image outerCrosshair;
    public Image puzzleScreen;

    private GameController gameController;

    void Awake()
    {
        if (instance != null)
            throw new System.Exception("Cannot have more than one UIController instance in a scene");
        
        instance = this;
    }

    void Start()
    {
        gameController = GameController.instance;
        if (gameController == null)
            throw new System.Exception("No GameController present");
    }

    public void SetCrosshairState(CrosshairState state)
    {
        switch (state)
        {
            case CrosshairState.Enabled:
                crosshair.enabled = true;
                outerCrosshair.enabled = false;
                break;

            case CrosshairState.Engaged:
                crosshair.enabled = true;
                outerCrosshair.enabled = true;
                break;

            case CrosshairState.Disabled:
                crosshair.enabled = false;
                outerCrosshair.enabled = false;
                break;
        }
    }

    public void ShowPuzzleScreen()
    {
        puzzleScreen.gameObject.SetActive(true);
    }

    public void HidePuzzleScreen()
    {
        puzzleScreen.gameObject.SetActive(false);
        gameController.DisengagePuzzle();
    }
}
