using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 1f;
    private Rigidbody rigidbody;
    private Vector3 startingPosition;
    private Vector3 roamPosition;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();
    }

    void Update()
    {
        rigidbody.velocity = roamPosition * speed;

        FindTarget();

        float reachedPositionDistance = 1f;
        if (Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance)
        {
            roamPosition = GetRoamingPosition();
        }

    }

    private Vector3 GetRoamingPosition()
    {
        var vec = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

        return startingPosition + vec * Random.Range(10f, 70f);
    }

    private void FindTarget()
    {
        float targetRange = 250f;
        if (Vector3.Distance(transform.position, PlayerController.PlayerPosition) < targetRange)
        {
            roamPosition = PlayerController.PlayerPosition;
        }
    }
}
