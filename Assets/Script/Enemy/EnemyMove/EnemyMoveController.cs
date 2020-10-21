using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMoveController : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField]
    private EnemyStates.State state = EnemyStates.State.PATROL;

    [SerializeField]
    protected EnemyMoveSettingsInstance instance;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        // initialize settings
        ChangeStateTo(state);
    }

    public void MoveToPoint(Vector3 point)
    {
        if (agent.velocity.normalized != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
        }

        agent.SetDestination(point);
    }

    public bool IsPointReachable(Vector3 point)
    {
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(point, path);
        if (path.status == NavMeshPathStatus.PathComplete)
        {
            return true;
        }

        return false;
    }

    public bool IsMoving()
    {
        var velocity = agent.velocity;
        if (Math.Abs(velocity.x) < 0.2 && Math.Abs(velocity.y) < 0.2 && Math.Abs(velocity.z) < 0.2 )
        {
            return false;
        }

        return true;
    }

    public void StopMoving()
    {
        agent.isStopped = true;
    }

    public void ContinueMoving()
    {
        agent.isStopped = false;
    }

    public void ChangeStateTo(EnemyStates.State state)
    {
        var builder = new EnemyMoveSettingsBuilder(instance, agent); // recreate to change during debug by instance
        builder.SetMoveByState(state);
    }
}
