using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private DoorTriggerArea door;

    [SerializeField]
    private GameObject triggerPrefab;
    
    private PlayerMovement playerMovement;

    public float interactionDistance = 3f;

    void Start(){
        
        playerMovement = FindObjectOfType<PlayerMovement>();
        
    }

    private void OnMouseDown()
    {
        if(CheckRange())
        {
           door.OpenTheDoor();
            door.SpawnTrigger(gameObject.transform, triggerPrefab);
            gameObject.SetActive(false); 
        }
        
    }


    private bool CheckRange()
    {
        Vector3 range = GetComponent<Transform>().position - PlayerMovement.playerPosition;
        //Vector3 range = GetComponent<Transform>().position - PlayerController.playerPosition;
        float _distanse = range.magnitude;
        

        if(_distanse <= interactionDistance)
        {
            Debug.Log("Distanse: " + _distanse);
            return true;
        }
        else
        {
           Debug.Log("Out of range! Distanse: " + _distanse); 
        }
        return false;
    }
}
