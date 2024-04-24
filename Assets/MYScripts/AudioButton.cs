using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    public AudioSource audioBtn;
    public AudioClip audioClip;
 
    public void playClip()
    {
        AudioSource audioSource = Instantiate(audioBtn, new Vector3(0, 0, 0), Quaternion.identity) as AudioSource;
        audioSource.clip = audioClip;
        audioSource.Play();
    }

}
