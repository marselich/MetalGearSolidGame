using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private GameObject _agroTarget;
    [SerializeField] private GameObject _spotPatrolingPoints;

    private RestingTypes _restingBehaviour;
    private ReactionTypes _reactionBehaviour;

    private List<Transform> SpotPatrolingPoints
        => new List<Transform>(_spotPatrolingPoints.GetComponentsInChildren<Transform>());

    public void Initialize(RestingTypes restingBehaviour, ReactionTypes reactionBehaviour)
    {
        _restingBehaviour = restingBehaviour;
        _reactionBehaviour = reactionBehaviour;
    }

    public void SpawnAt(Transform transform)
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform);

        InitializeEnemy(enemy);
    }

    private void InitializeEnemy(Enemy enemy)
    {
        BehaviourCreator behaviourCreator = new BehaviourCreator
            (
            enemy.CharacterMovement,
            enemy.AnimationPicker,
            _agroTarget.transform,
            enemy.RunningSpeed,
            enemy.Die,
            enemy.DieEffect,
            new Queue<Transform>(SpotPatrolingPoints)
            );

        IBehaviour restingBehaviour = behaviourCreator.Create(_restingBehaviour);
        IBehaviour reactionBehaviour = behaviourCreator.Create(_reactionBehaviour);

        enemy.Initialize(restingBehaviour, reactionBehaviour);
    }
}