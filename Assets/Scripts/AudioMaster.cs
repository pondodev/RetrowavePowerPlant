using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMaster : MonoBehaviour
{

    [Header("SFX")]
    public AudioSource sfxMaster;
    public AudioClip swipeSound;
    public AudioClip winSound;

    public void PlayWinSound()
    {
        sfxMaster.PlayOneShot(winSound);
    }

    public void PlaySwipeSound()
    {
        sfxMaster.PlayOneShot(swipeSound);
    }


}
