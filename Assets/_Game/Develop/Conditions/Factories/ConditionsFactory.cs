using Unity.VisualScripting;

public class ConditionsFactory
{
    private Timer _timer;
    private EnemiesContainer _enemiesContainer;
    private Character _mainHero;
    private LevelConfig _levelConfig;

    public ConditionsFactory(
        Timer timer,
        EnemiesContainer enemiesContainer,
        Character mainHero,
        LevelConfig levelConfig
        )
    {
        _timer = timer;
        _enemiesContainer = enemiesContainer;
        _mainHero = mainHero;
        _levelConfig = levelConfig;
    }

    public IConditionable CreateWinCondition(WinConditionType type)
    {
        switch (type)
        {
            case WinConditionType.TimePassed:
                return new TimePassedCondition(_timer, _levelConfig.TimePassedToWin);

            case WinConditionType.EnemiesKilled:
                return new EnemiesKilledCondition(_enemiesContainer, _levelConfig.EnemiesNeedToKillCount);

            default:
                throw new InvalidImplementationException($"Not found type: {type}");
        }
    }

    public IConditionable CreateDefeatCondition(DefeatConditionType type)
    {
        switch (type)
        {
            case DefeatConditionType.MainCharacterDied:
                return new CharacterDiedCondition(_mainHero);

            case DefeatConditionType.EnemiesCaptured:
                return new EnemiesCapturedCondition(_enemiesContainer, _levelConfig.MaxEnemiesToDefeatCount);

            default:
                throw new InvalidImplementationException($"Not found type: {type}");
        }
    }
}