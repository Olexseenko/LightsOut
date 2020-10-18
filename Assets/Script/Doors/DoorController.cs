using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    private BoxCollider boxCollider;
    private MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {   
        boxCollider = gameObject.GetComponent<BoxCollider>();
        mesh = gameObject.GetComponent<MeshRenderer>();
        GameEvents.current.onDoorwayTriggerEnter += OnDoorOpen;
        GameEvents.current.onDoorwayTriggerExit += OnDoorClose;
    }

    private void OnDoorClose(int id)
    {
        if(this.id == id)
        {
            boxCollider.enabled = true;
            mesh.enabled = true;
        }
        
    }

    private void OnDoorOpen(int id)
    {
        if(this.id == id)
        {
            boxCollider.enabled = false;
            mesh.enabled = false;
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.onDoorwayTriggerEnter -= OnDoorOpen;
        GameEvents.current.onDoorwayTriggerExit -= OnDoorClose;
    }
}
