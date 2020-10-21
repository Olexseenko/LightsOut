using UnityEngine;

public class PatrolFreeActivity : IEnemyStateActivity
{
    public EnemyController controller;

    public PatrolFreeActivity(EnemyController _controller)
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
        controller.EnemyMoveController.MoveToPoint(controller.target.transform.position);
        controller.EnemyMoveController.StopMoving();
    }

    public void StateActivity()
    {
        // no activity
    }

    public void TriggerEnterActivity(Collider other)
    {
        // no action
    }
}
