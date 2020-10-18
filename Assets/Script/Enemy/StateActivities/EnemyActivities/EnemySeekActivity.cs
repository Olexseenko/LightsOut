using UnityEngine;

public class EnemySeekActivity : IEnemyStateActivity
{
    public EnemyController controller;
    protected float seekTime = 5; // 30sec for seeking
    protected float seekPoint = 0;

    public EnemySeekActivity(EnemyController _controller)
    {
        controller = _controller;
    }

    public void ChangeState(EnemyStates.State state)
    {
        controller.ChangeStateTo(state);
    }

    public void PreStartActivity()
    {
        // set point of event
        seekPoint = Time.time + seekTime;
    }

    public void StateActivity()
    {
        var isSeen = controller.EnemyVisionController.IsTargetSeen(controller.target); // check if see target

        if (isSeen)
        {
            if (Vector3.Distance(controller.target.transform.position, controller.transform.position) <= 10f)
            {
                // if see and it is not too far then chase
                ChangeState(EnemyStates.State.CHASE);
            }
        }

        if (Time.time >= seekPoint)
        {
            // if time out then go home
            ChangeState(EnemyStates.State.PATROL);
        }
    }

    public void TriggerEnterActivity(Collider other)
    {
        // no action
    }

    protected void GoForPlayer()
    {
        var vec = controller.target.transform.position - controller.transform.position;

    }
}
