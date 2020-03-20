using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    UIController uic;
    public int puzzlesSovled;
    public int puzzleCount;

    void Start()
    {
        uic = FindObjectOfType<UIController>();
        puzzlesSovled = 0;
        puzzleCount = FindObjectsOfType<PuzzleController>().Length;
    }

    public void SolvePuzzle()
    {
        puzzlesSovled++;
        if(puzzlesSovled >= puzzleCount)
        {
            uic.ShowMessage("You win!");
            SceneManager.LoadSceneAsync(0);
        }
    }

    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Debug.Log("cheat");
    //        SolvePuzzle();
    //    }
    //}
}
