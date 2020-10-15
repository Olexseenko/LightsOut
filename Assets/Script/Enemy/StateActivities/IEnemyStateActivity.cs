using UnityEngine;

public interface IEnemyStateActivity
{
    void StateActivity();

    void TriggerEnterActivity(Collider other);
}
