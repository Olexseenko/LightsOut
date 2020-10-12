using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;
    private Material hightlightMaterial;
    private Material normalMaterial;

    public float distanse = 3f;

    void Start(){
        hightlightMaterial = Resources.Load<Material>(@"Materials/Hightlight");
        normalMaterial = GetComponent<MeshRenderer>().material;
    }

    private void OnMouseDown(){
        if(gameObject.GetComponent<Note>() && CheckRange())
        {
            FromSceneToDiary.instance.ReplaсeFromScene(this.gameObject);
        }

        if(gameObject.tag == "Box" && CheckRange() && (CanHideInBox() || player.state == PlayerController.State.hide))
        {
            Debug.Log("Inside box!");
            float x = gameObject.transform.position.x;
            float y = player.transform.position.y;
            float z = gameObject.transform.position.z;
            Vector3 newPosition = new Vector3(x, y, z);
            Vector3 offset = new Vector3(x, y, z+gameObject.transform.localScale.z);
            
            if(player.state == PlayerController.State.normal)
            {
                player.transform.position = newPosition;
                player.transform.rotation = gameObject.transform.rotation;
                player.state = PlayerController.State.hide;
            }
            else
            {
                player.transform.position = offset;
                player.state = PlayerController.State.normal;
            }
            
            Debug.Log("playerPosition: " + PlayerController.playerPosition);
            
        }
        
    }

    private void OnMouseEnter(){
        this.GetComponent<MeshRenderer>().material = hightlightMaterial;
    }

    private void OnMouseExit(){
        this.GetComponent<MeshRenderer>().material = normalMaterial;
    }

    private bool CheckRange()
    {
        Vector3 range = GetComponent<Transform>().position - PlayerController.playerPosition;
        float _distanse = range.magnitude;
        

        if(_distanse <= distanse)
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

    private bool CanHideInBox()
    {
        Ray ray = new Ray(transform.position, transform.forward); 

        RaycastHit hit; 
        if (Physics.SphereCast(ray, 1f, out hit)) { 
            GameObject hitObject = hit.transform.gameObject;
            if(hitObject.tag == "Player")
            {
                return true;
            }

        }
        return false;
    }

    
}
