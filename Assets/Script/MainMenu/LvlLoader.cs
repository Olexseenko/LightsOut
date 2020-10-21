using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlLoader : MonoBehaviour
{
    public Animator animator;

    public float transitionTime = 1f;

    public void LoadNextLvl()
    {
        StartCoroutine(LoadLvl(SceneManager.GetActiveScene().buildIndex + 1));
        
    }

    IEnumerator LoadLvl(int levelIndex)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }
    
    
}
