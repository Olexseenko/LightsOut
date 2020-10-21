using UnityEngine;

public class EnemyAttackActivity : IEnemyStateActivity
{
    public EnemyController controller;
    protected float range = 3f;
    protected float attackTime = 0f; // zero is uset attack time
    protected float hitTime = 0.5f; // attack cast time 0.5 s

    public EnemyAttackActivity(EnemyController _controller)
    {
        controller = _controller;
    }

    public void ChangeState(EnemyStates.State state)
    {
        controller.ChangeStateTo(state);
    }

    public void PreStartActivity()
    {
        attackTime = 0; // set attack time as unstarted
    }

    public void StateActivity()
    {
        // check if target in attack range
        if (Vector3.Distance(controller.target.transform.position, controller.transform.position) <= range)
        {
            if (attackTime == 0)
            {
                attackTime = Time.time + hitTime;
            }
            else if (Time.time >= attackTime && attackTime != 0)
            {
                controller.audioSource.PlayOneShot(controller.attackClip);

                controller.target.GetComponent<PlayerMovement>().AttackRecevied();

                this.controller.transform.position = controller.waypoints[0].transform.position;

                ChangeState(EnemyStates.State.PATROL);

                //attackTime = 0f; // reset attack
            }
        }
        else
        {
            attackTime = 0f; // reset attack

            // keep chaseing if out of attack range
            ChangeState(EnemyStates.State.CHASE);
        }
    }

    public void TriggerEnterActivity(Collider other)
    {
        // empty activity
    }
}
