using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSorce;
    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        audioSorce.Stop();
        audioSorce.PlayOneShot(audioClip);
    }
}
