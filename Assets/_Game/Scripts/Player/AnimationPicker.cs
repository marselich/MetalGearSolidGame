using UnityEngine;

public class AnimationPicker : MonoBehaviour
{
    private const string RunningKey = "IsRunning";
    private const string PistolIdleKey = "IsPistolIdle";
    private const string PistolRunningKey = "IsPistolRunning";
    private const string DrinkTriggerKey = "Drink";

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

    public void Drink() => _animator.SetTrigger(DrinkTriggerKey);

    public void SetPistolIdle(bool isActive) => _animator.SetBool(PistolIdleKey, isActive);

    public void SetPistolRunning(bool isActive) => _animator.SetBool(PistolRunningKey, isActive);

    private void SetRunning(bool isActive) => _animator.SetBool(RunningKey, isActive);
}
