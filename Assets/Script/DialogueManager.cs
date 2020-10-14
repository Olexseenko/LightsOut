using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private Text targetDialogue;

    [SerializeField]
    private Text dialogueText;

    [SerializeField]
    private GameObject dialogueUI;

    private Queue<string> sentences;

    void Start()
    {
        dialogueUI.SetActive(false);
        sentences = new Queue<string>();
    }

    public void StartDialogue(DialoguePattern dialogue)
    {
        dialogueUI.SetActive(true);
        targetDialogue.text = dialogue.dialogueTargeter;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }   

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialoge();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //dialogueText.text = sentence;

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialoge()
    {
        dialogueUI.SetActive(false);
        
    }
}
