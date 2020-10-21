using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlLoader : MonoBehaviour
{
    public Animator animator;

    public float transitionTime = 0.8f;

    public void LoadNextLvl()
    {
        StartCoroutine(LoadLvl(SceneManager.GetActiveScene().buildIndex + 1));
        
    }

    public void LoadSomeLvl(int levelIndex)
    {
        StartCoroutine(LoadLvl(levelIndex));
        
    }

    IEnumerator LoadLvl(int levelIndex)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }
    
    
}
