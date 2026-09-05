using UnityEngine;

public class EnemiesFactory
{
    private ControllersUpdateService _controllersUpdateService;
    private ControllersFactory _controllersFactory;
    private CharactersFactory _charactersFactory;
    private EnemiesContainer _enemiesContainer;

    public EnemiesFactory(
        ControllersUpdateService controllersUpdateService,
        ControllersFactory controllersFactory,
        CharactersFactory charactersFactory,
        EnemiesContainer enemiesContainer
        )
    {
        _controllersUpdateService = controllersUpdateService;
        _controllersFactory = controllersFactory;
        _charactersFactory = charactersFactory;
        _enemiesContainer = enemiesContainer;
    }

    public EnemyCharacter CreateEnemy(EnemiesConfig config, Vector3 spawnPosition)
    {
        EnemyCharacter instance = _charactersFactory.CreateCharacter(
            config.Prefab,
            spawnPosition,
            config.MoveSpeed,
            config.RotationSpeed,
            config.HealthValue) as EnemyCharacter;

        instance.Initialize(config.DamageValue);

        Controller controller = _controllersFactory.CreateEnemyCompositeController(instance, config.TimeToChangeDirection);
        controller.Enable();

        _controllersUpdateService.Add(controller, () => instance.IsDestroyed);

        _enemiesContainer.Add(instance, () => instance.IsDestroyed);

        return instance;
    }
}