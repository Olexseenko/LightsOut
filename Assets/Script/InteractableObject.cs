using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private Material hightlightMaterial;

    private Material normalMaterial;

    void Start(){
        normalMaterial = GetComponent<MeshRenderer>().material;
    }

    private void OnMouseDown(){
        if(gameObject.GetComponent<Note>() && CanTake())
        {
            FromSceneToDiary.instance.ReplaсeFromScene(this.gameObject);
        }
        
    }

    private void OnMouseEnter(){
        this.GetComponent<MeshRenderer>().material = hightlightMaterial;
    }

    private void OnMouseExit(){
        this.GetComponent<MeshRenderer>().material = normalMaterial;
    }

    private bool CanTake()
    {
        Vector3 range = GetComponent<Transform>().position - PlayerController.playerPosition;
        float distanse = range.magnitude;
        Debug.Log("Distanse: " + distanse);

        if(distanse <= 3)
        {
            return true;
        }
        return false;
    }
}
