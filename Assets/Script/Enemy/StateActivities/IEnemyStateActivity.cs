using UnityEngine;

public interface IEnemyStateActivity
{
    void PreStartActivity();

    void StateActivity();

    void TriggerEnterActivity(Collider other);

    void ChangeState(EnemyStates.State state);
}
