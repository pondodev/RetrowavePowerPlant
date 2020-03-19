using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageController : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    public void SetMessage(string message)
    {
        text.text = message;
    }
}
