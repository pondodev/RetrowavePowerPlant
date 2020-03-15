using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryTrigger : MonoBehaviour
{

    public GameObject exterior;
    public GameObject interior;
    public GameObject ground;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (exterior.activeSelf)
            {
                exterior.SetActive(false);
                ground.SetActive(false);
                interior.SetActive(true);
            }
            else
            {
                exterior.SetActive(true);
                ground.SetActive(true);
                interior.SetActive(false);
            }
        }
    }
}
