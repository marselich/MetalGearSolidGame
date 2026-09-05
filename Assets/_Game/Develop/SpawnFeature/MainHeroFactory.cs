using Cinemachine;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class MainHeroFactory : IDisposable
{
    private ControllersUpdateService _controllersUpdateService;
    private CharactersFactory _charactersFactory;
    private ControllersFactory _controllersFactory;

    private ShooterView _shooterView;

    public MainHeroFactory(
        ControllersUpdateService controllersUpdateService,
        CharactersFactory charactersFactory,
        ControllersFactory controllersFactory
        )
    {
        _controllersUpdateService = controllersUpdateService;
        _charactersFactory = charactersFactory;
        _controllersFactory = controllersFactory;
    }

    public MainCharacter Create(MainHeroConfig config, Vector3 spawnPosition)
    {
        MainCharacter instance = _charactersFactory.CreateCharacter(
            config.Prefab,
            spawnPosition,
            config.MoveSpeed,
            config.RotationSpeed,
            config.HealthValue) as MainCharacter;

        CinemachineVirtualCamera followCameraPrefab = Resources.Load<CinemachineVirtualCamera>("FollowCamera");
        CinemachineVirtualCamera followCamera = Object.Instantiate(followCameraPrefab);

        followCamera.Follow = instance.CameraTarget;

        BulletConfig bulletConfig = Resources.Load<BulletConfig>("Configs/BulletConfig");
        IShooter shooter = new Shooter(bulletConfig, instance.ShooterSpawnPoint);
        _shooterView = new ShooterView(shooter, bulletConfig.ShootEffectPrefab);

        Controller controller = _controllersFactory.CreateMainHeroCompositeController(instance, shooter, config.DamageValue);
        controller.Enable();

        _controllersUpdateService.Add(controller, () => instance.IsDestroyed);

        return instance;
    }

    public void Dispose()
    {
        _shooterView.Dispose();
    }
}