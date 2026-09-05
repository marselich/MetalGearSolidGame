using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Gameplay/BulletConfig", fileName = "BulletConfig")]
public class BulletConfig : ScriptableObject
{
    [field: SerializeField] public Bullet Prefab { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float Lifetime { get; private set; }
    [field: SerializeField] public ParticleSystem ShootEffectPrefab { get; private set; }
}