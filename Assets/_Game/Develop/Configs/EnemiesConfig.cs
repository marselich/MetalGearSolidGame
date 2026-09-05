using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Gameplay/EnemiesConfig", fileName = "EnemiesConfig")]
public class EnemiesConfig : ScriptableObject
{
    [field: SerializeField] public Character Prefab { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float RotationSpeed { get; private set; }
    [field: SerializeField] public float TimeToChangeDirection { get; private set; }
    [field: SerializeField] public float SpawnFrequency { get; private set; }
    [field: SerializeField] public float HealthValue { get; private set; }
    [field: SerializeField] public float DamageValue { get; private set; }
}