using UnityEngine;

public class EffectsActivator : MonoBehaviour
{
    [SerializeField] private ParticleSystem _healEffect;
    [SerializeField] private ParticleSystem _speedUpEffect;

    public void ActivateHeal() => _healEffect.Play();

    public void ActivateSpeedUp() => _speedUpEffect.Play();
}
