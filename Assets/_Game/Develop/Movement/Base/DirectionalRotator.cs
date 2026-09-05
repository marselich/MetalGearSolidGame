using UnityEngine;

public abstract class DirectionalRotator
{
    private float _rotationSpeed;

    private Vector3 _currentDirection;
    private float _deadZone = 0.5f;

    protected DirectionalRotator(float rotationSpeed)
    {
        _rotationSpeed = rotationSpeed;
    }

    public abstract Quaternion CurrentRotation { get; }

    public void SetInputDirection(Vector3 direction) => _currentDirection = direction;

    public void Update(float deltaTime)
    {
        if (_currentDirection.magnitude <= _deadZone)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(_currentDirection);

        float step = _rotationSpeed * deltaTime;

        ApplyRotation(Quaternion.RotateTowards(CurrentRotation, lookRotation, step));
    }

    public abstract void ApplyRotation(Quaternion rotation);
}