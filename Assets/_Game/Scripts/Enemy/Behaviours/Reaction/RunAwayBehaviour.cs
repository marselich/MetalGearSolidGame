using UnityEngine;

public class RunAwayBehaviour : IBehaviour
{
    private CharacterMovement _characterMovement;
    private AnimationPicker _animationPicker;
    private ITargetProvider _agroTarget;
    private float _runningSpeed;

    public RunAwayBehaviour(
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
        Vector3 direction = CharacterTransform.position - _agroTarget.Target.position;

        direction.y = 0;

        _animationPicker.SetScaryRunning(true);
        _characterMovement.MoveSpeed = _runningSpeed;
        _characterMovement.Move(direction.normalized);
    }
}