using UnityEngine;

public class MainCharacter : Character
{
    [SerializeField] private Transform _cameraTarget;
    [SerializeField] private Transform _shooterSpawnPoint;

    public Transform CameraTarget => _cameraTarget;
    public Transform ShooterSpawnPoint => _shooterSpawnPoint;
}