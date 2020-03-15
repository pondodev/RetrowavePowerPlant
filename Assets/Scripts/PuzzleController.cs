using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public PuzzleData data;
    
    void Start()
    {
        Debug.Log(data);
        Debug.Log(data.width);
        Debug.Log(data.pieces);
    }
}
