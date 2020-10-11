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
        if(gameObject.GetComponent<Note>())
        {
            FromSceneToDiary.instance.ReplaseFromScene(this.gameObject);
        }
        
    }

    private void OnMouseEnter(){
        this.GetComponent<MeshRenderer>().material = hightlightMaterial;
    }

    private void OnMouseExit(){
        this.GetComponent<MeshRenderer>().material = normalMaterial;
    }
}
