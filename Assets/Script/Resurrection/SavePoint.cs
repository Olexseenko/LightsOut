using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Resurrection.resPoint = gameObject.transform;
        }
    }
}
