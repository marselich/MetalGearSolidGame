using System;

public class EnemiesKilledCondition : IConditionable
{
    public event Action<int> Killed;

    private EnemiesContainer _enemiesContainer;
    private int _needToKillCount;

    private int _killCount;

    public EnemiesKilledCondition(EnemiesContainer container, int needToKillCount)
    {
        _enemiesContainer = container;
        _needToKillCount = needToKillCount;

        _killCount = 0;

        _enemiesContainer.Removed += OnEnemyDead;
    }

    public bool IsCompleted => _killCount >= _needToKillCount;

    private void OnEnemyDead(EnemyCharacter character)
    {
        _killCount++;
        Killed?.Invoke(_killCount);
    }

    public void Dispose()
    {
        _enemiesContainer.Removed -= OnEnemyDead;
    }
}