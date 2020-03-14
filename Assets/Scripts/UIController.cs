using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image crosshair;
    public Image outerCrosshair;

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
}
