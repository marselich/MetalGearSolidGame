using UnityEngine;

public class CharacterControllerDirectionMover : DirectionalMover
{
    private CharacterController _controller;

    public CharacterControllerDirectionMover(CharacterController controller, float movementSpeed) : base(movementSpeed)
    {
        _controller = controller;
    }

    public override void Update(float deltaTime)
    {
        _controller.Move(CurrentVelocity * deltaTime);
    }
}