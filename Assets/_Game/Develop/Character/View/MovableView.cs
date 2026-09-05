using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MovableView : MonoBehaviour, IInitializable
{
    private readonly int VelocityKey = Animator.StringToHash("Velocity");
    private const float DeadZone = 0.5f;
    private const float RunningValue = 1f;
    private const float IdleValue = 0f;

    private IMovable _movable;
    private Animator _animator;
    private bool _isInit;

    public void Initialize()
    {
        _animator = GetComponent<Animator>();

        _movable = GetComponentInParent<IMovable>();

        _isInit = true;
    }

    private void Update()
    {
        if (_isInit == false)
            return;

        if (_movable.CurrentVelocity.magnitude > DeadZone)
            StartRunning();
        else
            StopRunning();
    }

    private void StartRunning()
    {
        _animator.SetFloat(VelocityKey, RunningValue);
    }

    private void StopRunning()
    {
        _animator.SetFloat(VelocityKey, IdleValue);
    }
}