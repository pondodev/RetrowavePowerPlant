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
    public Color completed;
    private UnityEvent rotated;

    public void InitPiece(PuzzlePieceData _data, int _index, float scaleFactor, UnityEvent _rotatedEvent)
    {
        data = _data;
        index = _index;
        rotated = _rotatedEvent;

        ScaleTheStuff(scaleFactor);
        Draw(false);
        if (data.terminal) GetComponent<Button>().interactable = false;
    }

    private void ScaleTheStuff(float scaleFactor)
    {
        ApplyScaling(top, scaleFactor);
        ApplyScaling(bottom, scaleFactor);
        ApplyScaling(left, scaleFactor);
        ApplyScaling(right, scaleFactor);
        ApplyScaling(center, scaleFactor);
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
        Draw(false);
        rotated.Invoke();
    }

    public void Draw(bool _completed)
    {
        top.SetActive(data.top);
        bottom.SetActive(data.bottom);
        left.SetActive(data.left);
        right.SetActive(data.right);
        Power(_completed);
        if (_completed) GetComponent<Button>().interactable = false;
    }

    public void Power(bool _completed)
    {
        Color col;
        if (data.powered)
            if (_completed)
                col = completed;
            else
                col = powered;
        else
            col = unpowered;
        
        ApplyColour(col);
    }

    private void ApplyColour(Color col)
    {
        center.GetComponent<Image>().color = col;
        top.GetComponent<Image>().color = col;
        bottom.GetComponent<Image>().color = col;
        left.GetComponent<Image>().color = col;
        right.GetComponent<Image>().color = col;
    }
}
