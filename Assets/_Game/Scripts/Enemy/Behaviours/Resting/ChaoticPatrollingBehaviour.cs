using UnityEngine;

public class ChaoticPatrollingBehaviour : IBehaviour
{
    private const float Delay = 1f;

    private CharacterMovement _characterMovement;
    private AnimationPicker _animationPicker;

    private float _time;
    private Vector3 _currentDirection;

    public ChaoticPatrollingBehaviour(CharacterMovement characterMovement, AnimationPicker animationPicker)
    {
        _characterMovement = characterMovement;
        _animationPicker = animationPicker;
        _time = 0;
        _currentDirection = Vector3.forward;
    }

    public void Update()
    {
        _time += Time.deltaTime;

        if (_time >= Delay)
        {
            GenerateRandomDirection();
            _time = 0;
        }

        _animationPicker.SetWalking(true);
        _characterMovement.Move(_currentDirection.normalized);
    }

    private void GenerateRandomDirection()
    {
        _currentDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
    }
}