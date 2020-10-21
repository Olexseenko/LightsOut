using System.Collections.Generic;
using UnityEngine;

public class PatrolStatesBuilder : MonoBehaviour, IStatesBuilder
{
    public Dictionary<EnemyStates.State, IEnemyStateActivity> GetActivitiesDic(EnemyController controller)
    {
        var statesDic = new Dictionary<EnemyStates.State, IEnemyStateActivity>();

        statesDic.Add(EnemyStates.State.PATROL, new PatrolPatrolActivity(controller));
        statesDic.Add(EnemyStates.State.FREE_PATROL, new PatrolFreeActivity(controller)); // stub to stop moving
        statesDic.Add(EnemyStates.State.CHASE, new PatrolChaseActivity(controller));
        statesDic.Add(EnemyStates.State.SEEK, new PatrolSeekActivity(controller));

        return statesDic;
    }
}
