using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueWait : MonoBehaviour
{
    public float timeToWait = 4f;
    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {   
            StartCoroutine(WaitDialog());
        }
    }

    private IEnumerator WaitDialog()
    {   
        playerMovement.state = PlayerMovement.State.hide;

        yield return new WaitForSeconds(timeToWait);

        playerMovement.state = PlayerMovement.State.normal;

        Destroy(gameObject);
    }
}
