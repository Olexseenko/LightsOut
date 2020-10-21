using UnityEngine;

public class EnemyFreePatrolActivity : IEnemyStateActivity
{
    private Vector3 roamPosition;
    private Vector3 startingPosition;
    public EnemyController controller;

    public EnemyFreePatrolActivity(EnemyController _controller)
    {
        controller = _controller;
        startingPosition = controller.transform.position;
    }

    public void PreStartActivity()
    {
        // no activity
    }

    public void ChangeState(EnemyStates.State state)
    {
        controller.ChangeStateTo(state);
    }

    public void StateActivity()
    {
        if (Vector3.Distance(controller.transform.position, roamPosition) < 3)
        {
            roamPosition = GetRoamingPosition();
        }
    }

    public void TriggerEnterActivity(Collider other)
    {
        if (other.tag == "Player")
        {
            ChangeState(EnemyStates.State.CHASE);
            controller.target = other.gameObject;
        }
    }

    private Vector3 GetRoamingPosition()
    {
        var vec = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

        return startingPosition + vec * Random.Range(10f, 70f);
    }
}
