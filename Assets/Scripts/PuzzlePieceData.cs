[System.Serializable]
public class PuzzlePieceData
{
    public bool top;
    public bool bottom;
    public bool left;
    public bool right;
    public bool powered;
    public bool terminal;

    public void Rotate()
    {
        // store temp values
        bool _top = top;
        bool _bottom = bottom;
        bool _left = left;
        bool _right = right;

        top = _left;
        bottom = _right;
        left = _bottom;
        right = _top;
    }
}