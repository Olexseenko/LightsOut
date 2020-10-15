using UnityEngine;

public class EnemyChaseActivity : IEnemyStateActivity
{
    public EnemyController controller;

    public EnemyChaseActivity(EnemyController _controller)
    {
        controller = _controller;
    }

    public void StateActivity()
    {
        controller.EnemyMoveController.MoveToPoint(controller.target.transform.position);
    }

    public void TriggerEnterActivity(Collider other)
    {
        // empty activity
    }
}
