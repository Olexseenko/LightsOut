using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform prologSpawnPoint;
    [SerializeField] private Transform poligonSpawnPoint;

    private void ChangePosition(Transform player, Transform spawnPoint){
        float x = spawnPoint.position.x;
        float y = player.position.y;
        float z = spawnPoint.position.z;
        Vector3 newPosition = new Vector3(x, y, z);
        player.position = newPosition;
    }

    public void TPtoProlog(){
        ChangePosition(player, prologSpawnPoint);
    }

    public void TPtoPoligon(){
        ChangePosition(player, poligonSpawnPoint);
    }
}
