using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Animator _animator;


    private CharacterMovement _characterMovement;
    private CharacterController _characterController;
    private AnimationPicker _animationPicker;
    private float _deadZone = 0.1f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _characterMovement = new CharacterMovement(_characterController, _moveSpeed, _rotationSpeed);
        _animationPicker = new AnimationPicker(_animator);
    }

    private void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));

        if (input.magnitude <= _deadZone)
        {
            _animationPicker.StopWalking();
            return;
        }

        _characterMovement.Move(input.normalized);

        _animationPicker.StartWalking();
    }
}
