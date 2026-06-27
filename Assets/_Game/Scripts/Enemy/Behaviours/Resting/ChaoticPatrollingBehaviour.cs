using UnityEngine;

public class ChaoticPatrollingBehaviour : IRestingBehaviour
{
    private const float Delay = 1f;

    private float _time;
    private Vector3 _currentDirection;

    public void ProcessResting(Enemy enemy)
    {
        _time += Time.deltaTime;

        if (_time >= Delay)
        {
            GenerateRandomDirection();
            _time = 0;
        }

        enemy.CharacterMovement.Move(_currentDirection.normalized);
    }

    private void GenerateRandomDirection()
    {
        _currentDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
    }
}