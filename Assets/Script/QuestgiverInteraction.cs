using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestgiverInteraction : MonoBehaviour
{
    
    [SerializeField] private GameObject questgiverUI;
    [SerializeField] private GameObject interactionUI;
    
    private BoxCollider boxCollider;
    private MeshRenderer mesh;
    //can Player open questgiver interfase or not
    private bool canOpenUI=false;

    private void Start(){
        questgiverUI.SetActive(false);
        boxCollider = gameObject.GetComponent<BoxCollider>();
        mesh = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.E) && canOpenUI){
            //OpenQuestgiverUI(true);
            //Debug.Log("Menu");
            boxCollider.enabled = false;
            mesh.enabled = false;

        }
        if(Input.GetKeyDown(KeyCode.Q) && canOpenUI){
            //OpenQuestgiverUI(true);
            //Debug.Log("Menu");
            mesh.enabled = true;
            boxCollider.enabled = true;

        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            
            OpenQuestgiverUI(false);
        } 
    }

    private void OnTriggerExit(Collider other){
        if(other.tag == "Player"){
            canOpenUI = false;
            interactionUI.SetActive(false);
        }
        questgiverUI.SetActive(false);
    }

    public void Exit(){
        OpenQuestgiverUI(false);
    }

    private void OpenQuestgiverUI(bool b){
        canOpenUI = !b;
        interactionUI.SetActive(!b);
        questgiverUI.SetActive(b);
    }
}
