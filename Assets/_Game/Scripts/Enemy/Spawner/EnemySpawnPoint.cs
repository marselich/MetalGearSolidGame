using UnityEngine;

[RequireComponent(typeof(EnemySpawner))]
public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private RestingTypes _restingBehaviour;
    [SerializeField] private ReactionTypes _reactionBehaviour;

    private EnemySpawner _enemySpawner;

    private void Awake()
    {
        _enemySpawner = GetComponent<EnemySpawner>();

        IRestingBehaviour restingBehaviour = RestingFactory.Create(_restingBehaviour);
        IReactionBehaviour reactionBehaviour = ReactionFactory.Create(_reactionBehaviour);

        _enemySpawner.Initialize(restingBehaviour, reactionBehaviour);
        _enemySpawner.SpawnAt(transform);
    }
}