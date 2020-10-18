using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryLineTriggerArea : MonoBehaviour
{
    public DialoguePattern dialogue;
    

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            TriggerDialogue();
            Destroy(gameObject);
        }
    }
}
