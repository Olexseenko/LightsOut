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

    private void OnMouseOver(){
        this.GetComponent<MeshRenderer>().material = hightlightMaterial;
    }

    private void OnMouseExit(){
        this.GetComponent<MeshRenderer>().material = normalMaterial;
    }
}
