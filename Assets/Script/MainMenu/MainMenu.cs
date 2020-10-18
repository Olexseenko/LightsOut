using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {

    }

    public void Creaters()
    {

    }

    public void Exit()
    {
        Debug.Log("Exit...");
        Application.Quit();
    }
}
