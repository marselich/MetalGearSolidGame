using System;

public class EnemiesCapturedCondition : IConditionable
{
    public event Action<int> EnemiesCountChanged
    {
        add => _container.CountChanged += value;
        remove => _container.CountChanged -= value;
    }

    private EnemiesContainer _container;
    private int _maxEnemiesCount;

    public EnemiesCapturedCondition(EnemiesContainer container, int maxEnemiesCount)
    {
        _container = container;
        _maxEnemiesCount = maxEnemiesCount;
    }

    public bool IsCompleted => _container.Count >= _maxEnemiesCount;

    public void Dispose() { }
}