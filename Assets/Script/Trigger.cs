using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    [SerializeField] private GameObject trigger;
    


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            audio.Play();
            
            Destroy(trigger);
        }
    }
}
