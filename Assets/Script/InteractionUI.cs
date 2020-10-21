using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    [SerializeField]
    private GameObject interactionUI;

    public static InteractionUI instance;
    
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
        //DontDestroyOnLoad(gameObject);
        interactionUI.SetActive(false);
    }

    public void Show()
    {
        interactionUI.SetActive(true);
    }

    public void Hide()
    {
        interactionUI.SetActive(false);
    }
}
