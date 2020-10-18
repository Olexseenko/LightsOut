using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerArea : MonoBehaviour
{
    public enum State
    {
        close,
        open,
        locked,
    }
    [SerializeField]
    private GameObject door;

    [SerializeField]
    private GameObject triggerPrefab;

    [SerializeField]
    private GameObject key;

    

    private int id;
    private bool canInteract = false;
    public State state = State.close;


    private AudioSource audioSource;
    public AudioClip[] audioClips;

    private void Start()
    {
        id = door.GetComponent<DoorController>().id;
        audioSource = door.GetComponent<AudioSource>();
        if(key == null)
        {
            return;
        }
        key.SetActive(false);
        
    }

    private void Update()
    {
        switch(state)
        {
            case State.close:
                if(Input.GetKeyDown(KeyCode.E) && canInteract)
                {
                    GameEvents.current.DoorwayTriggerEnter(id);
                    state = State.open;
                }
            break;
            case State.open:
                if(Input.GetKeyDown(KeyCode.E) && canInteract)
                {
                    GameEvents.current.DoorwayTriggerExit(id);
                    state = State.close;
                }
            break;

            case State.locked:
                if(Input.GetKeyDown(KeyCode.E) && canInteract)
                {
                    PlaySound(2);
                    SpawnTrigger(door.gameObject.transform, triggerPrefab);
                    if(key == null)
                    {
                        return;
                    }
                    key.SetActive(true);
                }
            break;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            InteractionUI.instance.Show();
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            InteractionUI.instance.Hide();
            canInteract = false;
        }
        
    }

    private void PlaySound(int num)
    {
        if(audioClips[num] != null)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(audioClips[num]); 
        }
    }

    public void SpawnTrigger(Transform spawnPoint, GameObject TriggerPrefab)
    {
        if(spawnPoint == null || TriggerPrefab == null)
        {
            return;
        }
        Instantiate(TriggerPrefab, spawnPoint.position, spawnPoint.rotation);
        
    }

    public void OpenTheDoor()
    {
        state = State.close;
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameEvents.current.DoorwayTriggerEnter(id);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            GameEvents.current.DoorwayTriggerExit(id);
        }
        
    }
    */
}
