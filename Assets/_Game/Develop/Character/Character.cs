using UnityEngine;

public abstract class Character : MonoDestroyable, IDirectionalMovable, IDirectionalRotatable, IDamagable
{
    private DirectionalMover _mover;
    private DirectionalRotator _rotator;
    private Health _health;

    public Vector3 CurrentVelocity => _mover.CurrentVelocity;
    public Quaternion CurrentRotation => _rotator.CurrentRotation;
    public Health Health => _health;
    public bool IsDied => _health.IsDied;

    private void Update()
    {
        _mover.Update(Time.deltaTime);
        _rotator.Update(Time.deltaTime);
    }

    public void Initialize(DirectionalMover mover, DirectionalRotator rotator, Health health)
    {
        _mover = mover;
        _rotator = rotator;
        _health = health;

        _health.Died += OnDied;
        Destroyed += OnDestroyed;

        foreach (IInitializable initializable in GetComponentsInChildren<IInitializable>())
            initializable.Initialize();
    }

    public void SetMoveDirection(Vector3 direction) => _mover.SetInputDirection(direction);

    public void SetRotationDirection(Vector3 direction) => _rotator.SetInputDirection(direction);

    public void TakeDamage(float damage) => _health.TakeDamage(damage);

    private void OnDied()
    {
        Destroy();
    }

    private void OnDestroyed(MonoDestroyable destroyable)
    {
        _health.Died -= OnDied;
        Destroyed -= OnDestroyed;
    }
}