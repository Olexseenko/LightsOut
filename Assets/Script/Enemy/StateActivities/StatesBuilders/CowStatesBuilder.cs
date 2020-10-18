using System.Collections.Generic;
using UnityEngine;

public class CowStatesBuilder : MonoBehaviour, IStatesBuilder
{
    public Dictionary<EnemyStates.State, IEnemyStateActivity> GetActivitiesDic(EnemyController controller)
    {
        var statesDic = new Dictionary<EnemyStates.State, IEnemyStateActivity>();

        statesDic.Add(EnemyStates.State.FREE_PATROL, new CowFreePatrol(controller));
        statesDic.Add(EnemyStates.State.IDLE, new CowIDLEActivity(controller));

        return statesDic;
    }
}
