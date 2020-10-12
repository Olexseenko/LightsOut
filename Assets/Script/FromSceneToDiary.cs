using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FromSceneToDiary : MonoBehaviour
{
    public static FromSceneToDiary instance;

    private Note selected;

    [SerializeField]
    private Transform questArea;

    [SerializeField]
    private Text textArea;

    [SerializeField]
    private GameObject notePrefab;



    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } 
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReplaсeFromScene(GameObject gameObject)
    {
        GameObject _note = Instantiate(notePrefab, questArea);
        //Копирование из объекта в переменные дневника
        //Возможно надо оптимизировать
        _note.GetComponent<Note>().notePattern.id = gameObject.GetComponent<Note>().notePattern.id;
        _note.GetComponent<Note>().notePattern.title = gameObject.GetComponent<Note>().notePattern.title;
        _note.GetComponent<Note>().notePattern.description = gameObject.GetComponent<Note>().notePattern.description;

        Debug.Log(gameObject.tag + " Object Taked " + gameObject);
        Destroy(gameObject);
    }

    public void ShowDiscription(Note note)
    {
        if(selected == null)
        {
            selected = note;
            textArea.text = note.notePattern.description;
        } 
        else 
        {
            selected.DeSelect();
            selected = note;
            textArea.text = note.notePattern.description;
        }
        
    }
}
