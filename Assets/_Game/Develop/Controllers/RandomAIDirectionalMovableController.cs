using UnityEngine;

public class RandomAIDirectionalMovableController : Controller
{
    private IDirectionalMovable _movable;
    private float _timeToChangeDirection;

    private Vector3 _inputDirection;
    private float _time;

    public RandomAIDirectionalMovableController(IDirectionalMovable movable, float timeToChangeDirection)
    {
        _movable = movable;
        _timeToChangeDirection = timeToChangeDirection;

        GenerateRandomDirection();
    }

    protected override void UpdateLogic(float deltaTime)
    {
        _time += deltaTime;

        if (_time > _timeToChangeDirection)
        {
            GenerateRandomDirection();
            _time = 0;
        }

        _movable.SetMoveDirection(_inputDirection);
    }

    private void GenerateRandomDirection()
    {
        Vector2 randomDirection = Random.insideUnitCircle;

        _inputDirection = new Vector3(randomDirection.x, 0, randomDirection.y);
    }
}