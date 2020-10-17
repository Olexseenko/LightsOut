using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerArea : MonoBehaviour
{
    public enum State
    {
        close,
        open,
    }
    [SerializeField]
    private GameObject doorId;
    private int id;
    private bool canInteract = false;
    private State state = State.close;

    private void Start()
    {
        id = doorId.GetComponent<DoorController>().id;
    }

    private void Update()
    {
        switch(state)
        {
            case State.close:
                if(Input.GetKeyDown(KeyCode.E) && canInteract)
                {
                    GameEvents.current.DoorwayTriggerEnter(id);
                    state = State.open;
                }
            break;
            case State.open:
                if(Input.GetKeyDown(KeyCode.E) && canInteract)
                {
                    GameEvents.current.DoorwayTriggerExit(id);
                    state = State.close;
                }
            break;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            InteractionUI.instance.Show();
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            InteractionUI.instance.Hide();
            canInteract = false;
        }
        
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameEvents.current.DoorwayTriggerEnter(id);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            GameEvents.current.DoorwayTriggerExit(id);
        }
        
    }
    */
}
