using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(IStatesBuilder))]
[RequireComponent(typeof(EnemyMoveController))]
[RequireComponent(typeof(EnemyVisionController))]
public class EnemyController : MonoBehaviour
{
    public AudioClip audioClip;
    [SerializeField]
    public AudioSource audioSource;

    public EnemyMoveController EnemyMoveController { get; protected set; }
    public EnemyVisionController EnemyVisionController { get; protected set; }

    protected Dictionary<EnemyStates.State, IEnemyStateActivity> StatesDic = new Dictionary<EnemyStates.State, IEnemyStateActivity>();

    protected IStatesBuilder StatesBuilder;

    [Header("Patrol variables")]
    public GameObject[] waypoints;

    [Header("Chase variables")]
    public GameObject target;

    [Space]
    [SerializeField]
    protected EnemyStates.State state = EnemyStates.State.PATROL;

    private void Awake()
    {
        StatesBuilder = GetComponent<IStatesBuilder>();
        StatesDic = StatesBuilder.GetActivitiesDic(this);
        EnemyMoveController = GetComponent<EnemyMoveController>();
        EnemyVisionController = GetComponent<EnemyVisionController>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        IEnemyStateActivity currentActivity;

        if (StatesDic.TryGetValue(state, out currentActivity))
        {
            currentActivity.StateActivity();
        }
        else
        {
            throw new Exception($"Enemy {this.gameObject.name} have no activity {EnemyStates.StatesNames.First(_ => _.Key == state).Value}");
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
        else
        {
            throw new Exception($"Enemy {this.gameObject.name} have no activity {EnemyStates.StatesNames.First(_ => _.Key == state).Value}");
        }
    }

    public void ChangeStateTo(EnemyStates.State state)
    {
        IEnemyStateActivity currentActivity;

        if (StatesDic.TryGetValue(state, out currentActivity))
        {
            // Prepare state to be used
            if (this.state != state)
            {
                currentActivity.PreStartActivity();
            }
        }
        else
        {
            throw new Exception($"Enemy {this.gameObject.name} have no activity {EnemyStates.StatesNames.First(_ => _.Key == state).Value}");
        }

        this.state = state;
        EnemyMoveController.ChangeStateTo(state);
    }
}
