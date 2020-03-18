using UnityEngine;

public class PuzzleData : ScriptableObject
{
    public int width;
    public int height;
    public int startTerminalCoord;
    public int endTerminalCoord;
    public PuzzlePieceData[] pieces;
}