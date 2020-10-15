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
    private Animator animator;

    [SerializeField]
    private AudioSource audioSource;

    private Queue<string> sentences;
    private Queue<AudioClip> audioClip;
    


    void Start()
    {
        sentences = new Queue<string>();
        audioClip = new Queue<AudioClip>();
        
    }

    
    public void StartDialogue(DialoguePattern dialogue)
    {
        animator.SetBool("IsOpen", true);
        targetDialogue.text = dialogue.dialogueTargeter;
        sentences.Clear();
        audioClip.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (AudioClip audio in dialogue.audioClips)
        {
            audioClip.Enqueue(audio);
        }   

        DisplayNextSentence();
        PlayNextAudio();
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

    public void PlayNextAudio()
    {
        if(audioClip.Count == 0)
        {
            EndDialoge();
            return;
        }
        audioSource.Stop();
        if(audioClip.Peek() == null)
        {
            audioClip.Dequeue();
            return;
        }
        AudioClip audio = audioClip.Dequeue();
        audioSource.PlayOneShot(audio);
        
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

    public void EndDialoge()
    {
        audioSource.Stop();
        animator.SetBool("IsOpen", false);
        
    }
}
