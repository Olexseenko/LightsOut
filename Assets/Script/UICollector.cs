using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICollector : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject interactionUI;
    public GameObject questgiverUI;

    void Start(){
        pauseMenuUI.SetActive(false);
        interactionUI.SetActive(false);
        questgiverUI.SetActive(false);
    }
}
