using UnityEngine;

public class CharacterMovement
{
    private CharacterController _characterController;
    private float _moveSpeed;
    private float _rotationSpeed;

    private Quaternion Rotation
    {
        get => _characterController.transform.rotation;
        set => _characterController.transform.rotation = value;
    }

    public CharacterMovement(CharacterController characterController, float speed, float rotationSpeed)
    {
        _characterController = characterController;
        _moveSpeed = speed;
        _rotationSpeed = rotationSpeed;
    }

    public void Move(Vector3 direction)
    {
        if (direction == Vector3.zero)
            return;

        _characterController.Move(direction * _moveSpeed * Time.deltaTime);
        ProcessRotateTo(direction);
    }

    private void ProcessRotateTo(Vector3 direction)
    {
        if (direction == Vector3.zero) return;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        float step = _rotationSpeed * Time.deltaTime;

        Rotation = Quaternion.RotateTowards(Rotation, lookRotation, step);
    }
}
