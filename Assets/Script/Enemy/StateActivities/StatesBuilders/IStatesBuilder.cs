using System.Collections.Generic;

public interface IStatesBuilder
{
    Dictionary<EnemyStates.State, IEnemyStateActivity> GetActivitiesDic(EnemyController controller);
}
