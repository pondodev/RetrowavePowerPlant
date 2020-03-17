using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance { get; private set; }

    public Image crosshair;
    public Image outerCrosshair;
    public GameObject puzzleScreen;
    public RectTransform puzzleContainer;
    public GameObject puzzlePiece;
    
    private List<GameObject> pieces;

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
        puzzleScreen.SetActive(true);
    }

    public void HidePuzzleScreen()
    {
        puzzleScreen.SetActive(false);
        gameController.DisengagePuzzle();
        foreach (GameObject obj in pieces)
        {
            Destroy(obj);
        }
    }

    public void InitPuzzle(PuzzleData data)
    {
        int maxSize = 1000;
        int pieceSize = maxSize / Mathf.Max(data.width, data.height);

        int width = data.width * pieceSize;
        int height = data.height * pieceSize;

        puzzleContainer.sizeDelta = new Vector2(width, height);

        pieces = new List<GameObject>();
        int index = 0;
        float xPos = pieceSize / 2;
        float yPos = pieceSize / 2;
        float scaleFactor = (pieceSize * 2f) / maxSize;
        for (int i = 0; i < data.height; i++)
        {
            for (int j = 0; j < data.width; j++)
            {
                GameObject obj = Instantiate(puzzlePiece, puzzleContainer.transform);
                RectTransform rect = obj.GetComponent<RectTransform>();
                PuzzlePieceController piece = obj.GetComponent<PuzzlePieceController>();

                rect.sizeDelta = new Vector2(pieceSize * 2, pieceSize * 2);
                rect.localPosition = new Vector3(xPos, yPos, 0);
                piece.InitPiece(data.pieces[index], index, scaleFactor);
                pieces.Add(obj);

                xPos += pieceSize;
                index++;
            }

            xPos = pieceSize / 2;
            yPos += pieceSize;
        }
    }
}   
