using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSound : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SoundManager.instance.state = SoundManager.State.PART_2;
            SoundManager.instance.CurrentPlay();
        }
    }
}
