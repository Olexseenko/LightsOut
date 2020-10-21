using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalTP : MonoBehaviour
{
    
    private LvlLoader lvlLoader;
    
    private void Awake()
    {
        lvlLoader = FindObjectOfType<LvlLoader>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            lvlLoader.LoadNextLvl();
            
        }
    }
}
