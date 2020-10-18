using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private DoorTriggerArea door;

    [SerializeField]
    private GameObject triggerPrefab;

    private void OnMouseDown()
    {
        door.OpenTheDoor();
        door.SpawnTrigger(gameObject.transform, triggerPrefab);
        gameObject.SetActive(false);
    }

}
