using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestgiverInteraction : MonoBehaviour
{
    
    [SerializeField] private GameObject questgiverUI;
    [SerializeField] private GameObject interactionUI;
    
    //can Player open questgiver interfase or not
    private bool canOpenUI=false;

    private void Start(){
        questgiverUI.SetActive(false);
        
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.E) && canOpenUI == true){
            OpenQuestgiverUI(true);
            Debug.Log("Menu");
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
