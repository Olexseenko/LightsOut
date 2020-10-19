using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryLineTriggerArea : MonoBehaviour
{
    public DialoguePattern dialogue;
    
    [SerializeField]
    private GameObject nextTrigger;

    private void Start()
    {
        if(nextTrigger != null)
            {
                nextTrigger.SetActive(false);
            }
    }

    

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(nextTrigger != null)
            {
                nextTrigger.SetActive(true);
            }

            TriggerDialogue();
            Destroy(gameObject);
        }
    }

    public void TriggerDialogue()
    {

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
