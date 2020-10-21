using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCrying : MonoBehaviour
{
    [SerializeField]
    private AudioSource motherCrying;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            motherCrying.Stop();
        }
    }
}
