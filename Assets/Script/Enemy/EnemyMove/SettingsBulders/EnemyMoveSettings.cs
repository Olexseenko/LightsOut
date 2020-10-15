public class EnemyMoveSettings : IEnemyMoveSettings
{
    protected EnemyMoveSettingsBuilder builder;

    public EnemyMoveSettings(EnemyMoveSettingsBuilder _bulder)
    {
        builder = _bulder;
    }

    public void SetSpeed(float speed)
    {
        builder.agent.speed = speed;
    }

    public void SetUpdatePosition(bool flag)
    {
        builder.agent.updatePosition = flag;
    }

    public void SetUpdateRotation(bool flag)
    {
        builder.agent.updateRotation = flag;
    }
}
