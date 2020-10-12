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

    public NotePattern notePattern;

    void Start(){
        if(notePattern != null && text != null)
            text.text = notePattern.title;
    }

    public void Select()
    {
        GetComponent<Text>().color = Color.grey;
        FromSceneToDiary.instance.ShowDiscription(this);
        Debug.Log("Show discription");
    }

    public void DeSelect()
    {
        GetComponent<Text>().color = Color.white;
    }
    
}
