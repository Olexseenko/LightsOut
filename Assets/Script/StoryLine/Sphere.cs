using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField]
    private GameObject storyLine;

    [SerializeField]
    private GameObject nextstoryLine;

    [SerializeField]
    private GameObject portal;

    void Start()
    {
       storyLine.SetActive(false); 
       nextstoryLine.SetActive(false); 
       portal.SetActive(false);
    }

    private void OnMouseDown()
    {
        storyLine.SetActive(true); 
        nextstoryLine.SetActive(true); 
        portal.SetActive(true);
        Destroy(gameObject);
    }
}
