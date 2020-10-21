using UnityEngine;

public class PatrolSeekActivity : IEnemyStateActivity
{
    public EnemyController controller;

    public PatrolSeekActivity(EnemyController _controller)
    {
        controller = _controller;
    }

    public void ChangeState(EnemyStates.State state)
    {
        controller.EnemyMoveController.ContinueMoving();
        controller.ChangeStateTo(state);
    }

    public void PreStartActivity()
    {
        controller.EnemyMoveController.StopMoving();
    }

    public void StateActivity()
    {
        if (Vector3.Distance(controller.target.transform.position, controller.transform.position) <= 2f)
        {
            ChangeState(EnemyStates.State.PATROL);
        }

        if (Vector3.Distance(controller.target.transform.position, controller.transform.position) >= 4f)
        {
            ChangeState(EnemyStates.State.CHASE);
        }
    }

    public void TriggerEnterActivity(Collider other)
    {
        // no action
    }
}
