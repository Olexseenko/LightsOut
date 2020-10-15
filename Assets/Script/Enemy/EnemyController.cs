using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyMoveController EnemyMoveController { get; protected set; }

    protected Dictionary<EnemyStates.State, IEnemyStateActivity> StatesDic = new Dictionary<EnemyStates.State, IEnemyStateActivity>();

    [Header("Patrol variables")]
    public GameObject[] waypoints;

    [Header("Chase variables")]
    public GameObject target;

    [Space]
    [SerializeField]
    protected EnemyStates.State state = EnemyStates.State.PATROL;

    public EnemyController()
    {
        StatesDic.Add(EnemyStates.State.PATROL, new EnemyPatrolActivity(this));
        StatesDic.Add(EnemyStates.State.CHASE, new EnemyChaseActivity(this));
    }

    // Start is called before the first frame update
    void Start()
    {
        EnemyMoveController = GetComponent<EnemyMoveController>();
    }

    // Update is called once per frame
    void Update()
    {
        IEnemyStateActivity currentActivity;

        if (StatesDic.TryGetValue(state, out currentActivity))
        {
            currentActivity.StateActivity();
        }

        // only develop version
        ChangeStateTo(state);
    }

    private void OnTriggerEnter(Collider other)
    {
        IEnemyStateActivity currentActivity;

        if (StatesDic.TryGetValue(state, out currentActivity))
        {
            currentActivity.TriggerEnterActivity(other);
        }
    }

    public void ChangeStateTo(EnemyStates.State state)
    {
        this.state = state;
        EnemyMoveController.ChangeStateTo(state);
    }
}
