using UnityEngine;

public class AnimationPicker
{
    private const string WalkingKey = "IsWalking";
    private const string RunningKey = "IsRunning";

    [SerializeField] Animator _animator;

    public AnimationPicker(Animator animator)
    {
        _animator = animator;
    }

    public void StartWalking() => _animator.SetBool(WalkingKey, true);

    public void StopWalking() => _animator.SetBool(WalkingKey, false);

    public void StartRunning() => _animator.SetBool(RunningKey, true);

    public void StopRunning() => _animator.SetBool(RunningKey, false);
}
