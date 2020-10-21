using UnityEngine;

public class PatrolPatrolActivity : IEnemyStateActivity
{
    public int wayPointInd = 0;
    public EnemyController controller;

    public PatrolPatrolActivity(EnemyController _controller)
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
        if (Vector3.Distance(controller.transform.position, controller.target.transform.position) > 12f)
        {
            ChangeState(EnemyStates.State.CHASE);
        }

        if (Vector3.Distance(controller.transform.position, controller.waypoints[wayPointInd].transform.position) >= 1)
        {
            controller.EnemyMoveController.MoveToPoint(controller.waypoints[wayPointInd].transform.position);
        }
        else
        {
            wayPointInd++;
            if (controller.waypoints.Length <= wayPointInd)
            {
                ChangeState(EnemyStates.State.FREE_PATROL);
            }
        }
    }

    public void TriggerEnterActivity(Collider other)
    {
        // no activities
    }
}
