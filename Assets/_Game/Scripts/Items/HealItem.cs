using UnityEngine;

public class HealItem : Item
{
    [SerializeField] private float _healValue;

    public override void ActivateAbility()
    {
        base.ActivateAbility();

        _player.EffectsActivator.ActivateHeal();
        _player.Health.Add(_healValue);
        _player.Health.ShowInfo();
    }
}
