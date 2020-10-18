using UnityEngine;

public class EnemyChaseActivity : IEnemyStateActivity
{
    public EnemyController controller;
    protected float attackRange = 1f;
    protected float targetLostTime = 3f; // 3 sec keep chasing
    protected float targetLostTimePoint = 0f; // stop chasing point

    public EnemyChaseActivity(EnemyController _controller)
    {
        controller = _controller;
    }

    public void ChangeState(EnemyStates.State state)
    {
        controller.ChangeStateTo(state);
    }

    public void PreStartActivity()
    {
        targetLostTimePoint = 0; // unset lost point

        controller.audioSource.PlayOneShot(controller.audioClip);
    }

    public void StateActivity()
    {
        controller.EnemyMoveController.MoveToPoint(controller.target.transform.position);

        // target in attack range
        if (Vector3.Distance(controller.target.transform.position, controller.transform.position) <= attackRange)
        {
            ChangeState(EnemyStates.State.ATTACK);
        }

        // target far from you
        if (Vector3.Distance(controller.target.transform.position, controller.transform.position) > 5f)
        {
            var isSeen = controller.EnemyVisionController.IsTargetSeen(controller.target); // check if see target

            if (isSeen)
            {
                // if see target stop lost timer
                targetLostTimePoint = 0f;
            }
            else
            {
                // if can't see
                if (targetLostTimePoint == 0)
                {
                    // set stop time
                    targetLostTimePoint = Time.time + targetLostTime;
                }
            }
        }

        // if target can't be found
        if (Time.time >= targetLostTimePoint && targetLostTimePoint != 0)
        {
            // start seek for it
            ChangeState(EnemyStates.State.SEEK);
        }
    }

    public void TriggerEnterActivity(Collider other)
    {
        // empty activity
    }
}
