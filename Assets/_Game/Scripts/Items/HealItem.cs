using UnityEngine;

public class HealItem : Item
{
    [SerializeField] private float _healValue;

    private Health _health;
    private EffectsActivator _effectsActivator;

    public override void InitializeTo(GameObject character)
    {
        base.InitializeTo(character);

        _effectsActivator = character.GetComponent<EffectsActivator>();
        _health = character.GetComponent<Health>();
    }

    public override void ActivateAbility()
    {
        base.ActivateAbility();

        _effectsActivator.ActivateHeal();
        _health.Add(_healValue);
        _health.ShowInfo();
    }
}
