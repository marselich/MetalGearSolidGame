using UnityEngine;

public class CharacterDirectionalMovableController : Controller
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    private IDirectionalMovable _movable;

    public CharacterDirectionalMovableController(IDirectionalMovable movable)
    {
        _movable = movable;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));

        _movable.SetMoveDirection(inputDirection);
    }
}