using System.Collections.Generic;
using UnityEngine;

public class StatesBuilder : MonoBehaviour, IStatesBuilder
{
    public Dictionary<EnemyStates.State, IEnemyStateActivity> GetActivitiesDic(EnemyController controller)
    {
        var statesDic = new Dictionary<EnemyStates.State, IEnemyStateActivity>();

        statesDic.Add(EnemyStates.State.PATROL, new EnemyPatrolActivity(controller));
        statesDic.Add(EnemyStates.State.FREE_PATROL, new EnemyFreePatrolActivity(controller));
        statesDic.Add(EnemyStates.State.CHASE, new EnemyChaseActivity(controller));
        statesDic.Add(EnemyStates.State.ATTACK, new EnemyAttackActivity(controller));
        statesDic.Add(EnemyStates.State.SEEK, new EnemySeekActivity(controller));

        return statesDic;
    }
}
