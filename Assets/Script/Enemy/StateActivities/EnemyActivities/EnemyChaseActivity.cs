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

        controller.GetComponent<SphereCollider>().enabled = false;

        controller.ScreemsControll?.StartScreem();

        controller.audioSource.PlayOneShot(controller.chaseClip);

        controller.soundManager.FightBegin();
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
        if (Vector3.Distance(controller.target.transform.position, controller.transform.position) > 6f)
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

                RaycastHit hit;
                // Does the ray intersect any objects excluding the player layer
                if (Physics.Raycast(controller.transform.position, controller.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
                {
                    Debug.DrawRay(controller.transform.position, controller.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                    if (hit.collider.gameObject.tag == "Door")
                    {
                        hit.collider.gameObject.GetComponent<DoorController>().Open();
                    }
                }


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
