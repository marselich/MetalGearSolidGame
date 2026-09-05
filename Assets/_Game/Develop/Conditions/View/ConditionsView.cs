using System;
using System.Collections.Generic;

public class ConditionsView : IDisposable
{
    private IConditionable _winCondition;
    private IConditionable _defeatCondition;
    private TextDisplayer _winDisplayer;
    private TextDisplayer _defeatDisplayer;
    private LevelConfig _levelConfig;

    private List<IConditionable> _conditionsToDispose = new();

    public ConditionsView(
        IConditionable winCondition,
        IConditionable defeatCondition,
        TextDisplayer winDisplayer,
        TextDisplayer defeatDisplayer,
        LevelConfig levelConfig
        )
    {
        _winCondition = winCondition;
        _defeatCondition = defeatCondition;
        _winDisplayer = winDisplayer;
        _defeatDisplayer = defeatDisplayer;
        _levelConfig = levelConfig;
    }

    public void Start()
    {
        ProcessWinCondition();
        ProcessDefeatCondition();
    }

    private void ProcessWinCondition()
    {
        switch (_winCondition)
        {
            case TimePassedCondition timePassedCondition:
                timePassedCondition.TimeChanged += OnTimerChanged;
                _conditionsToDispose.Add(timePassedCondition);
                break;

            case EnemiesKilledCondition enemiesKilledCondition:
                DisplayEnemiesKilledText(0);
                enemiesKilledCondition.Killed += OnKilled;
                _conditionsToDispose.Add(enemiesKilledCondition);
                break;
        }
    }

    private void ProcessDefeatCondition()
    {
        switch (_defeatCondition)
        {
            case EnemiesCapturedCondition enemiesCapturedCondition:
                DisplayMaxEnemiesToDefeatCountText(0);
                enemiesCapturedCondition.EnemiesCountChanged += OnEnemiesCountChanged;
                _conditionsToDispose.Add(enemiesCapturedCondition);
                break;
        }
    }

    public void Dispose()
    {
        foreach (IConditionable conditionable in _conditionsToDispose)
        {
            switch (conditionable)
            {
                case TimePassedCondition timePassedCondition:
                    timePassedCondition.TimeChanged -= OnTimerChanged;
                    break;

                case EnemiesKilledCondition enemiesKilledCondition:
                    enemiesKilledCondition.Killed -= OnKilled;
                    break;

                case EnemiesCapturedCondition enemiesCapturedCondition:
                    enemiesCapturedCondition.EnemiesCountChanged -= OnEnemiesCountChanged;
                    break;
            }
        }
    }

    private void OnEnemiesCountChanged(int count) => DisplayMaxEnemiesToDefeatCountText(count);

    private void OnKilled(int count) => DisplayEnemiesKilledText(count);

    private void OnTimerChanged(float time)
    => _winDisplayer.DisplayText((_levelConfig.TimePassedToWin - time).ToString("0.00"));


    private void DisplayEnemiesKilledText(int count)
        => _winDisplayer.DisplayText($"{count} / {_levelConfig.EnemiesNeedToKillCount}");

    private void DisplayMaxEnemiesToDefeatCountText(int count) =>
        _defeatDisplayer.DisplayText($"In Arena: {count} / {_levelConfig.MaxEnemiesToDefeatCount} enemies");
}