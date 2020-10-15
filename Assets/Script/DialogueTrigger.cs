using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class DialogueTrigger : MonoBehaviour
{
    public DialoguePattern dialogue;
    //private Dictionary<string, AudioClip> textToSpeach;

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
