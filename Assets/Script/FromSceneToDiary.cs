using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromSceneToDiary : MonoBehaviour
{
    public static FromSceneToDiary instance;

    [SerializeField]
    private Transform questArea;

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

    public void ReplaseFromScene(GameObject gameObject)
    {
        GameObject _note = Instantiate(notePrefab, questArea);
        _note.GetComponent<Note>().note.id = gameObject.GetComponent<Note>().note.id;
        _note.GetComponent<Note>().note.title = gameObject.GetComponent<Note>().note.title;
        _note.GetComponent<Note>().note.description = gameObject.GetComponent<Note>().note.description;

        Debug.Log(gameObject.tag + " Object Taked " + gameObject);
        Destroy(gameObject);
    }
}
