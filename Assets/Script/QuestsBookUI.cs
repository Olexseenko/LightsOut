using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsBookUI : MonoBehaviour
{
    [SerializeField]
    private GameObject questsBookUI;
    // Start is called before the first frame update
    void Start()
    {
        questsBookUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuestsBookUIToogle(){
        questsBookUI.SetActive(!questsBookUI.activeSelf);
    }
}
