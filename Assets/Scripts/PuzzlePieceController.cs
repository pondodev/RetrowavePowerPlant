using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PuzzlePieceController : MonoBehaviour
{
    public PuzzlePieceData data { get; private set; }
    public int index { get; private set; }
    public GameObject center;
    public GameObject top;
    public GameObject bottom;
    public GameObject left;
    public GameObject right;
    public Color unpowered;
    public Color powered;
    private UnityEvent rotated;

    public void InitPiece(PuzzlePieceData _data, int _index, float scaleFactor, UnityEvent _rotatedEvent)
    {
        data = _data;
        index = _index;
        rotated = _rotatedEvent;

        ScaleTheStuff(scaleFactor);
        Draw();
    }

    private void ScaleTheStuff(float scaleFactor)
    {
        ApplyScaling(top, scaleFactor);
        ApplyScaling(bottom, scaleFactor);
        ApplyScaling(left, scaleFactor);
        ApplyScaling(right, scaleFactor);
    }

    private void ApplyScaling(GameObject obj, float scaleFactor)
    {
        RectTransform rect = obj.GetComponent<RectTransform>();
        rect.sizeDelta = rect.sizeDelta * scaleFactor;
    }

    public void Rotate()
    {
        if (data.terminal) return; // can't rotate terminals
        data.Rotate();
        Draw();
        rotated.Invoke();
    }

    public void Draw()
    {
        top.SetActive(data.top);
        bottom.SetActive(data.bottom);
        left.SetActive(data.left);
        right.SetActive(data.right);
        Power(data.powered);
    }

    public void Power(bool state)
    {
        Color col;
        if (state)
            col = powered;
        else
            col = unpowered;
        
        ApplyColour(center, col);
        ApplyColour(top, col);
        ApplyColour(bottom, col);
        ApplyColour(left, col);
        ApplyColour(right, col);
    }

    private void ApplyColour(GameObject obj, Color col)
    {
        obj.GetComponent<Image>().color = col;
    }
}
