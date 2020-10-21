using UnityEngine;

public class CowIDLEActivity : IEnemyStateActivity
{
    protected float idleEndPoint = 0f;
    protected float idleDuration = 5f;
    public EnemyController controller;

    public CowIDLEActivity(EnemyController _controller)
    {
        controller = _controller;
    }

    public void ChangeState(EnemyStates.State state)
    {
        controller.ChangeStateTo(state);
    }

    public void PreStartActivity()
    {
        idleDuration = Random.Range(5, 20);
        idleEndPoint = Time.time + idleDuration;
    }

    public void StateActivity()
    {
        if (Time.time >= idleEndPoint)
        {
            ChangeState(EnemyStates.State.FREE_PATROL);
        }
    }

    public void TriggerEnterActivity(Collider other)
    {
        // no activity
    }
}
