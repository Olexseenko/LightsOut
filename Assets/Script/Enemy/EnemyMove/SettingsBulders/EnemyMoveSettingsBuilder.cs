using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveSettingsBuilder : IEnemyStateSetting
{
    public NavMeshAgent agent;
    protected IEnemyMoveSettings settingsCatalog;

    [SerializeField]
    protected EnemyMoveSettingsInstance instance;

    public EnemyMoveSettingsBuilder(EnemyMoveSettingsInstance _instance, NavMeshAgent _agent)
    {
        instance = _instance;
        agent = _agent;
        settingsCatalog = new EnemyMoveSettings(this);
    }

    public void SetMoveByState(EnemyStates.State state)
    {
        switch (state)
        {
            case EnemyStates.State.PATROL:
                SetForPatrol();
                break;
            case EnemyStates.State.FREE_PATROL:
                SetForFreePatrol();
                break;
            case EnemyStates.State.CHASE:
                SetForChase();
                break;
            default:
                throw new Exception("No such state " + state);
        }
    }

    public virtual void SetForPatrol()
    {
        settingsCatalog.SetUpdatePosition(true);
        settingsCatalog.SetUpdateRotation(false);
        settingsCatalog.SetSpeed(instance.patrolSpeed);
    }

    public void SetForFreePatrol()
    {
        settingsCatalog.SetUpdatePosition(true);
        settingsCatalog.SetUpdateRotation(false);
        settingsCatalog.SetSpeed(instance.patrolSpeed);
    }

    public virtual void SetForChase()
    {
        settingsCatalog.SetUpdatePosition(true);
        settingsCatalog.SetUpdateRotation(false);
        settingsCatalog.SetSpeed(instance.chaseSpeed);
    }
}
