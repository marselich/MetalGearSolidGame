using System.Collections.Generic;
using UnityEngine;

public class SpotPatrollingBehaviour : IBehaviour
{
    private const float DeadZone = 0.5f;

    private CharacterMovement _characterMovement;
    private AnimationPicker _animationPicker;
    private Queue<Transform> _spotPatrolingPoints;

    private Transform _currentSpotPoint;

    public SpotPatrollingBehaviour(
        CharacterMovement characterMovement,
        AnimationPicker animationPicker,
        Queue<Transform> spotPatrolingPoints
        )
    {
        _characterMovement = characterMovement;
        _animationPicker = animationPicker;
        _spotPatrolingPoints = spotPatrolingPoints;

        GenerateNewSpotPoint();
    }

    private Transform CharacterTransform => _characterMovement.CharacterController.transform;

    public void Update()
    {
        Vector3 direction = _currentSpotPoint.position - CharacterTransform.position;

        if (direction.magnitude <= DeadZone)
            GenerateNewSpotPoint();

        direction.y = 0;

        _animationPicker.SetWalking(true);
        _characterMovement.Move(direction.normalized);
    }

    private void GenerateNewSpotPoint()
    {
        _currentSpotPoint = _spotPatrolingPoints.Dequeue();
        _spotPatrolingPoints.Enqueue(_currentSpotPoint);
    }
}