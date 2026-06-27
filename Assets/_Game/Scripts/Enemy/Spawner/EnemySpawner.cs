using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    private IRestingBehaviour _restingBehaviour;
    private IReactionBehaviour _reactionBehaviour;

    public void Initialize(IRestingBehaviour restingBehaviour, IReactionBehaviour reactionBehaviour)
    {
        _restingBehaviour = restingBehaviour;
        _reactionBehaviour = reactionBehaviour;
    }

    public void SpawnAt(Transform transform)
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform);
        enemy.Initialize(_restingBehaviour, _reactionBehaviour);
    }
}