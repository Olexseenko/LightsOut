using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resurrection : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private GameObject deathUI;

    public static Transform resPoint;
    
    void Start()
    {
        deathUI.SetActive(false);
        
    }


    public void PlayerDied()
    {
        deathUI.SetActive(true);
    }

    public void ReSpawn()
    {
        Debug.Log("SHit");
        deathUI.SetActive(false);
        float x = resPoint.position.x;
        float y = player.position.y;
        float z = resPoint.position.z;
        Vector3 newPosition = new Vector3(x, y, z);
        player.position = newPosition;
        player.GetComponent<PlayerMovement>().state = PlayerMovement.State.normal;
    }

}
