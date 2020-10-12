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
        agent.SetDestination(point);
    }

    public void ChangeStateTo(EnemyStates.State state)
    {
        var builder = new EnemyMoveSettingsBuilder(instance, agent); // recreate to change during debug by instance
        builder.SetMoveByState(state);
    }
}
