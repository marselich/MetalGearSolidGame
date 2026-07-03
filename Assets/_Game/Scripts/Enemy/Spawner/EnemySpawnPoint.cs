using UnityEngine;

[RequireComponent(typeof(EnemySpawner))]
public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private RestingTypes _restingBehaviour;
    [SerializeField] private ReactionTypes _reactionBehaviour;

    private void Awake()
    {
        EnemySpawner enemySpawner = GetComponent<EnemySpawner>();

        enemySpawner.Initialize(_restingBehaviour, _reactionBehaviour);
        enemySpawner.SpawnAt(transform);
    }
}