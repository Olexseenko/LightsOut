using UnityEngine;

[CreateAssetMenu]
public class EnemyMoveSettingsInstance : ScriptableObject
{
    [Header("Patrol stage settings")]
    public float patrolSpeed = 5f;

    [Space]
    [Header("Chase stage settings")]
    public float chaseSpeed = 10f;

    [Space]
    [Header("Shared settings")]
    public float PointReachedDistance = 1f;
}
