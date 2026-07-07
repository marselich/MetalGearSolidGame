using UnityEngine;

public class AggressiveBehaviour : IBehaviour
{
    private CharacterMovement _characterMovement;
    private AnimationPicker _animationPicker;
    private ITargetProvider _agroTarget;
    private float _runningSpeed;

    public AggressiveBehaviour(
        CharacterMovement characterMovement,
        AnimationPicker animationPicker,
        ITargetProvider agroTarget,
        float runningSpeed
        )
    {
        _characterMovement = characterMovement;
        _animationPicker = animationPicker;
        _agroTarget = agroTarget;
        _runningSpeed = runningSpeed;
    }

    private Transform CharacterTransform => _characterMovement.CharacterController.transform;

    public void Update()
    {
        Vector3 direction = _agroTarget.Target.position - CharacterTransform.position;

        direction.y = 0;

        _animationPicker.SetRunning(true);
        _characterMovement.MoveSpeed = _runningSpeed;
        _characterMovement.Move(direction.normalized);
    }
}