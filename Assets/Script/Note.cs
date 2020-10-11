using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    [SerializeField]
    private Text text;

    //[SerializeField]
    //private Text textDiscriptionUI;

    public NotePattern note;

    void Start(){
        if(note != null && text != null)
            text.text = note.title;
    }

    public void DisplayDiscription()
    {
        Debug.Log("Show discription");
    }
    
}
