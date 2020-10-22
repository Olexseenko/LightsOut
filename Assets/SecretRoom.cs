using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoom : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private GameObject roof;



    void Start()
    {
        audioSource.PlayOneShot(audioClip);
        audioSource.Pause();
        roof.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            roof.SetActive(false);
            audioSource.UnPause();
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            roof.SetActive(true);
            audioSource.Pause();
        }
        
    }
}
