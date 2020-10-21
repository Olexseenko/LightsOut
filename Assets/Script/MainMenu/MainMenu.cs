using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    [SerializeField]
    private GameObject creatorUI;


    private void Start()
    {
        creatorUI.SetActive(false);
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {

    }

    public void Creators()
    {
        creatorUI.SetActive(!creatorUI.activeSelf);
    }

    public void Exit()
    {
        Debug.Log("Exit...");
        Application.Quit();
    }
}
