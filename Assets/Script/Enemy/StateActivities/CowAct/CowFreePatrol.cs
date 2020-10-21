using UnityEngine;

public class CowFreePatrol : IEnemyStateActivity
{
    private Vector3 roamPosition;
    private Vector3 startingPosition;
    public EnemyController controller;

    public CowFreePatrol(EnemyController _controller)
    {
        controller = _controller;
    }

    public void PreStartActivity()
    {
        startingPosition = controller.transform.position;
        roamPosition = GetRoamingPosition();
    }

    public void ChangeState(EnemyStates.State state)
    {
        controller.ChangeStateTo(state);
    }

    public void StateActivity()
    {
        if (Vector3.Distance(controller.transform.position, roamPosition) < 3)
        {
            ChangeState(EnemyStates.State.IDLE);
        }

        if (controller.EnemyMoveController.IsPointReachable(roamPosition))
        {
            controller.EnemyMoveController.MoveToPoint(roamPosition);
        }
        else
        {
            roamPosition = GetRoamingPosition();
        }
    }

    public void TriggerEnterActivity(Collider other)
    {
        // no activity
    }

    private Vector3 GetRoamingPosition()
    {
        float x = Random.Range(-10, 11);
        float y = 0;
        float z = Random.Range(-10, 11);
        Vector3 pos = new Vector3(x, y, z);

        return startingPosition + pos;
    }
}
