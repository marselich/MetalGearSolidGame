using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Gameplay/MainHeroConfig", fileName = "MainHeroConfig")]
public class MainHeroConfig : ScriptableObject
{
    [field: SerializeField] public Character Prefab { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float RotationSpeed { get; private set; }
    [field: SerializeField] public float HealthValue { get; private set; }
    [field: SerializeField] public float DamageValue { get; private set; }
}