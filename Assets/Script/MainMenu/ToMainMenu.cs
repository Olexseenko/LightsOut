using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{
    private LvlLoader lvlLoader;

    private void Awake()
    {
        lvlLoader = FindObjectOfType<LvlLoader>();
    }
    
    public void MainMenu()
    {
        lvlLoader.LoadSomeLvl(0);
    }
}
