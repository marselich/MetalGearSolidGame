using System;
using System.Collections;
using UnityEngine;

public class GameCycle : IDisposable
{
    private MainHeroFactory _mainHeroFactory;
    private MainHeroConfig _mainHeroConfig;
    private LevelConfig _levelConfig;
    private EnemiesSpawner _enemiesSpawner;
    private MonoBehaviour _context;
    private ConditionsConfig _conditionsConfig;
    private EnemiesContainer _enemiesContainer;
    private ConfirmPopup _confirmPopup;
    private ConfirmPopup _endGamePopup;
    private TextDisplayer _winConditionDisplayer;
    private TextDisplayer _defeatConditionDisplayer;

    private MainCharacter _mainHero;
    private GameMode _gameMode;
    private ConditionsFactory _conditionsFactory;
    private IConditionable _winCondition;
    private IConditionable _defeatCondition;
    private ConditionsView _conditionsView;

    public GameCycle(
        MainHeroFactory mainHeroFactory,
        MainHeroConfig mainHeroConfig,
        LevelConfig levelConfig,
        EnemiesSpawner enemiesSpawner,
        MonoBehaviour context,
        ConditionsConfig conditionsConfig,
        EnemiesContainer enemiesContainer,
        ConfirmPopup confirmPopup,
        ConfirmPopup endGamePopup,
        TextDisplayer winConditionDisplayer,
        TextDisplayer defeatConditionDisplayer
        )
    {
        _mainHeroFactory = mainHeroFactory;
        _mainHeroConfig = mainHeroConfig;
        _levelConfig = levelConfig;
        _enemiesSpawner = enemiesSpawner;
        _context = context;
        _conditionsConfig = conditionsConfig;
        _enemiesContainer = enemiesContainer;
        _confirmPopup = confirmPopup;
        _endGamePopup = endGamePopup;
        _winConditionDisplayer = winConditionDisplayer;
        _defeatConditionDisplayer = defeatConditionDisplayer;
    }

    public IEnumerator Prepare()
    {
        _mainHero = _mainHeroFactory.Create(_mainHeroConfig, _levelConfig.MainHeroStartPosition);

        yield return null;
    }

    public IEnumerator Launch()
    {
        if (_mainHero.IsDestroyed)
            _mainHero = _mainHeroFactory.Create(_mainHeroConfig, _levelConfig.MainHeroStartPosition);

        _confirmPopup.Show();
        _confirmPopup.ShowMessage($"Press {KeyCode.F.ToString()} for begin");

        yield return _confirmPopup.WaitConfirm(KeyCode.F);

        _confirmPopup.Hide();

        Timer timer = new Timer(_context);
        _conditionsFactory = new ConditionsFactory(timer, _enemiesContainer, _mainHero, _levelConfig);

        _winCondition = _conditionsFactory.CreateWinCondition(_conditionsConfig.WinConditionType);
        _defeatCondition = _conditionsFactory.CreateDefeatCondition(_conditionsConfig.DefeatConditionType);

        _gameMode = new GameMode(_enemiesSpawner, _winCondition, _defeatCondition, _enemiesContainer);

        _winConditionDisplayer.Show();
        _defeatConditionDisplayer.Show();

        _conditionsView = new ConditionsView(
            _winCondition,
            _defeatCondition,
            _winConditionDisplayer,
            _defeatConditionDisplayer,
            _levelConfig);

        _conditionsView.Start();

        _gameMode.Wined += OnGameModeWin;
        _gameMode.Defeated += OnGameModeDefeat;

        _gameMode.Start();

        yield return null;
    }

    public void Update(float deltaTime)
    {
        if (_defeatCondition is CharacterDiedCondition == false && _mainHero.IsDestroyed)
            _mainHero = _mainHeroFactory.Create(_mainHeroConfig, _levelConfig.MainHeroStartPosition);

        _gameMode?.Update(deltaTime);
    }

    public void Dispose()
    {
        _gameMode.Wined -= OnGameModeWin;
        _gameMode.Defeated -= OnGameModeDefeat;

        _winCondition.Dispose();
        _defeatCondition.Dispose();
        _conditionsView.Dispose();
    }

    private void OnGameModeWin()
    {
        OnGameModeEnded("You Win");
        Debug.Log("Win");
    }

    private void OnGameModeDefeat()
    {
        OnGameModeEnded("You lose");
        Debug.Log("Defeat");
    }

    private void OnGameModeEnded(string endGameText)
    {
        if (_gameMode != null)
        {
            _gameMode.Wined -= OnGameModeWin;
            _gameMode.Defeated -= OnGameModeDefeat;

            _winConditionDisplayer.Hide();
            _defeatConditionDisplayer.Hide();

            _endGamePopup.Show();
            _endGamePopup.ShowMessage(endGameText);

            _context.StartCoroutine(EndGameProcess());
        }
    }

    private IEnumerator EndGameProcess()
    {
        yield return _endGamePopup.WaitAnyKeyConfirm();

        _endGamePopup.Hide();

        yield return Launch();
    }
}