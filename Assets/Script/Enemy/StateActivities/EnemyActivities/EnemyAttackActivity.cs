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
        controller.ChangeStateTo(EnemyStates.State.CHASE);
    }

    public void PreStartActivity()
    {
        attackTime = 0; // set attack time as unstarted
    }

    public void StateActivity()
    {
        // attack indicator
        var sphere = controller.gameObject.transform.GetChild(0);
        // attack indicator

        // check if target in attack range
        if (Vector3.Distance(controller.target.transform.position, controller.transform.position) <= range)
        {
            if (attackTime == 0)
            {
                attackTime = Time.time + hitTime;

                // attack animation stub
                sphere.gameObject.active = true;
            }
            else if (Time.time >= attackTime && attackTime != 0)
            {
                // commit attack
                sphere.gameObject.active = false;
                Debug.Log("Attack bitch!!!");
                attackTime = 0f; // reset attack
            }
        }
        else
        {
            // attack animation stub stop
            sphere.gameObject.active = false;
            // attack animation stub stop

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
