using System.Collections;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private LoadingScreen _loadingScreen;
    [SerializeField] private ConfirmPopup _confirmPopup;
    [SerializeField] private ConfirmPopup _endGamePopup;
    [SerializeField] private TextDisplayer _winConditionDisplayer;
    [SerializeField] private TextDisplayer _defeatConditionDisplayer;

    private ControllersUpdateService _controllersUpdateService;

    private MainHeroFactory _mainHeroFactory;
    private EnemiesContainer _enemiesContainer;
    private GameCycle _gamePlayCycle;

    private void Awake()
    {
        StartCoroutine(StartProcess());
    }

    private IEnumerator StartProcess()
    {
        _loadingScreen.Show();

        MainHeroConfig mainHeroConfig = Resources.Load<MainHeroConfig>("Configs/MainHeroConfig");
        LevelConfig levelConfig = Resources.Load<LevelConfig>("Configs/LevelConfig");
        EnemiesConfig enemyConfig = Resources.Load<EnemiesConfig>("Configs/EnemiesConfig");
        ConditionsConfig conditionsConfig = Resources.Load<ConditionsConfig>("Configs/ConditionsConfig");

        _controllersUpdateService = new ControllersUpdateService();
        CharactersFactory charactersFactory = new CharactersFactory();
        ControllersFactory controllersFactory = new ControllersFactory();

        _enemiesContainer = new EnemiesContainer();

        EnemiesFactory enemiesFactory = new EnemiesFactory(
            _controllersUpdateService,
            controllersFactory,
            charactersFactory,
            _enemiesContainer
            );

        _mainHeroFactory = new MainHeroFactory(_controllersUpdateService, charactersFactory, controllersFactory);

        EnemiesSpawner enemySpawner = new EnemiesSpawner(this, enemiesFactory, enemyConfig, levelConfig);

        _gamePlayCycle = new GameCycle(
            _mainHeroFactory,
            mainHeroConfig,
            levelConfig,
            enemySpawner,
            this,
            conditionsConfig,
            _enemiesContainer,
            _confirmPopup,
            _endGamePopup,
            _winConditionDisplayer,
            _defeatConditionDisplayer
            );

        yield return _gamePlayCycle.Prepare();

        //Симуляция какой-то инициализации и тп.
        yield return new WaitForSeconds(1.5f);

        _loadingScreen.Hide();

        yield return _gamePlayCycle.Launch();
    }

    private void Update()
    {
        _controllersUpdateService?.Update(Time.deltaTime);
        _enemiesContainer?.Update();
        _gamePlayCycle?.Update(Time.deltaTime);
    }

    private void OnDestroy()
    {
        _mainHeroFactory.Dispose();
        _gamePlayCycle.Dispose();
    }
}