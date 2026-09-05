using System;

public class GameMode
{
    public event Action Wined;
    public event Action Defeated;

    private EnemiesSpawner _enemiesSpawner;
    private IConditionable _winCondition;
    private IConditionable _defeatCondition;
    private EnemiesContainer _enemiesContainer;

    private bool _isRunning;

    public GameMode(
        EnemiesSpawner enemiesSpawner,
        IConditionable winCondition,
        IConditionable defeatCondition,
        EnemiesContainer enemiesContainer
        )
    {
        _enemiesSpawner = enemiesSpawner;
        _winCondition = winCondition;
        _defeatCondition = defeatCondition;
        _enemiesContainer = enemiesContainer;
    }

    public void Start()
    {
        _enemiesSpawner.StartSpawn();

        _isRunning = true;
    }

    public void Update(float deltaTime)
    {
        if (_isRunning == false)
            return;

        if (_winCondition.IsCompleted)
            ProcessWin();

        if (_defeatCondition.IsCompleted)
            ProcessDefeat();
    }

    private void ProcessEndGame()
    {
        _enemiesSpawner.StopSpawn();
        _enemiesContainer.RemoveAll();

        _isRunning = false;
    }

    private void ProcessWin()
    {
        ProcessEndGame();
        Wined?.Invoke();
    }

    private void ProcessDefeat()
    {
        ProcessEndGame();
        Defeated?.Invoke();
    }
}