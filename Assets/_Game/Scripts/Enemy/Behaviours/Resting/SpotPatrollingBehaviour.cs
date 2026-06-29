using System.Collections.Generic;
using UnityEngine;

public class SpotPatrollingBehaviour : IRestingBehaviour
{
    private const float DeadZone = 0.5f;

    private Queue<Transform> _spotPatrolingPoints;
    private Transform _currentSpotPoint;

    public void ProcessResting(Enemy enemy)
    {
        if (_spotPatrolingPoints == null)
            InitializeSpotPoints(enemy.SpotPatrolingPoints);

        Vector3 direction = _currentSpotPoint.position - enemy.transform.position;

        if (direction.magnitude <= DeadZone)
            GenerateNewSpotPoint();

        direction.y = 0;

        enemy.AnimationPicker.SetWalking(true);
        enemy.CharacterMovement.Move(direction.normalized);
    }

    private void InitializeSpotPoints(List<Transform> points)
    {
        _spotPatrolingPoints = new Queue<Transform>(points);
        GenerateNewSpotPoint();
    }

    private void GenerateNewSpotPoint()
    {
        _currentSpotPoint = _spotPatrolingPoints.Dequeue();
        _spotPatrolingPoints.Enqueue(_currentSpotPoint);
    }
}