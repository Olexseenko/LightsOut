using UnityEngine;

public class PatrolChaseActivity : IEnemyStateActivity
{
    public EnemyController controller;
    protected float waitRange = 3f;

    public PatrolChaseActivity(EnemyController _controller)
    {
        controller = _controller;
    }

    public void ChangeState(EnemyStates.State state)
    {
        controller.ChangeStateTo(state);
    }

    public void PreStartActivity()
    {
        // no activity
    }

    public void StateActivity()
    {
        controller.EnemyMoveController.MoveToPoint(controller.target.transform.position);

        // target in attack range
        if (Vector3.Distance(controller.target.transform.position, controller.transform.position) <= waitRange)
        {
            ChangeState(EnemyStates.State.SEEK);
        }
    }

    public void TriggerEnterActivity(Collider other)
    {
        // empty activity
    }
}
