using UnityEngine;

public class AnimationPicker : MonoBehaviour
{
    private const string WalkingKey = "IsWalking";
    private const string RunningKey = "IsRunning";
    private const string ScaryRunningKey = "IsScaryRunning";
    private const string PistolIdleKey = "IsPistolIdle";
    private const string PistolRunningKey = "IsPistolRunning";
    private const string DrinkTriggerKey = "Drink";
    private const string ScaredTriggerKey = "Scared";

    [SerializeField] Animator _animator;

    public void Idle()
    {
        if (_animator.GetBool(PistolIdleKey))
            SetPistolRunning(false);
        else
            SetRunning(false);
    }

    public void Running()
    {
        if (_animator.GetBool(PistolIdleKey))
            SetPistolRunning(true);
        else
            SetRunning(true);
    }

    public void Stay()
    {
        SetWalking(false);
        SetRunning(false);
        SetScaryRunning(false);
    }

    public void Drink() => _animator.SetTrigger(DrinkTriggerKey);

    public void Scared() => _animator.SetTrigger(ScaredTriggerKey);

    public void SetPistolIdle(bool isActive) => _animator.SetBool(PistolIdleKey, isActive);

    public void SetPistolRunning(bool isActive) => _animator.SetBool(PistolRunningKey, isActive);

    public void SetRunning(bool isActive) => _animator.SetBool(RunningKey, isActive);

    public void SetScaryRunning(bool isActive) => _animator.SetBool(ScaryRunningKey, isActive);

    public void SetWalking(bool isActive) => _animator.SetBool(WalkingKey, isActive);
}