using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 1f;
    private Rigidbody rigidbody;
    private Vector3 startingPosition;
    private Vector3 roamPosition;
    private NavMeshAgent agent;

    public enum State { 
        PATROL,
        CHASE
    }

    public State state;
    private bool alive;

    // Vars for Patrol
    public GameObject[] waypoints;
    public int wayPointInd = 0;
    public float patrolSpeed = 0.5f;


    // Vars for Chase
    public float chaseSpeed = 1f;
    public GameObject target;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();

        agent.updatePosition = true;
        agent.updateRotation = false;

        state = State.PATROL;

        alive = true;

        StartCoroutine(FSM());
    }

    void Update()
    {
        //switch (state)
        //{
        //    case State.PATROL:
        //        Patrol();
        //        break;
        //    case State.CHASE:
        //        break;
        //    default:
        //        break;
        //}

        //MoveToPoint(roamPosition);


        //FindTarget();

        //float reachedPositionDistance = 1f;
        //if (Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance)
        //{
        //    roamPosition = GetRoamingPosition();
        //}

    }

    IEnumerator FSM()
    {
        while (alive)
        {
            switch (state)
            {
                case State.PATROL:
                    Patrol();
                    break;
                case State.CHASE:
                    Chase();
                    break;
                default:
                    break;
            }

            yield return null;
        }
    }

    void Patrol()
    {
        agent.speed = patrolSpeed;

        if (Vector3.Distance(this.transform.position, waypoints[wayPointInd].transform.position) >= 1)
        {
            agent.SetDestination(waypoints[wayPointInd].transform.position);
        }
        else
        {
            wayPointInd++;
            if (waypoints.Length <= wayPointInd)
            {
                wayPointInd = 0;
            }
        }
    }

    void Chase() 
    {
        agent.speed = chaseSpeed;
        agent.SetDestination(target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            state = State.CHASE;
            target = other.gameObject;
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

    private void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
}
