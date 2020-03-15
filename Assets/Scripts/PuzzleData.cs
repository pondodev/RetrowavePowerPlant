using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PuzzleData
{
    int width;
    int height;
    int[] startTerminalCoord;
    int[] endTerminalCoord;
    PuzzlePieceData[,] pieces;
}