using System;
using System.Collections.Generic;

public class EnemiesContainer
{
    public event Action<int> CountChanged;
    public event Action<EnemyCharacter> Removed;
    public event Action AllRemoved;

    private List<EnemiesContainerToRemoveReason> _enemies = new();

    public int Count => _enemies.Count;

    public void Add(EnemyCharacter enemy, Func<bool> removeReason)
    {
        _enemies.Add(new EnemiesContainerToRemoveReason(enemy, removeReason));
        CountChanged?.Invoke(Count);
    }

    public void Update()
    {
        _enemies.RemoveAll((item) => CheckRemoveReason(item));
    }

    public void RemoveAll()
    {
        AllRemoved?.Invoke();

        foreach (EnemiesContainerToRemoveReason enemy in _enemies)
            enemy.Enemy.Destroy();

        _enemies.Clear();
    }

    private bool CheckRemoveReason(EnemiesContainerToRemoveReason item)
    {
        if (item.RemoveReason.Invoke())
        {
            Removed?.Invoke(item.Enemy);
            CountChanged?.Invoke(Count);
        }

        return item.RemoveReason.Invoke();
    }

    private class EnemiesContainerToRemoveReason
    {
        public EnemiesContainerToRemoveReason(EnemyCharacter enemy, Func<bool> removeReason)
        {
            Enemy = enemy;
            RemoveReason = removeReason;
        }

        public EnemyCharacter Enemy { get; }
        public Func<bool> RemoveReason { get; }
    }
}