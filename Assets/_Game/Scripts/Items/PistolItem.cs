using UnityEngine;

public class PistolItem : Item
{
    [SerializeField] Transform _barrelPoint;
    [SerializeField] float _duration;

    public Transform BarrelPoint => _barrelPoint;

    public override void InitializeTo(Player player)
    {
        base.InitializeTo(player);

        _deactivateTime = _duration;

        player.AnimationPicker.SetPistolIdle(true);
    }

    public override void ActivateAbility()
    {
        base.ActivateAbility();

        _player.GunController.ShootWith(this);
    }

    protected override void DeactivateAbility()
    {
        _player.AnimationPicker.SetPistolIdle(false);
        _player.AnimationPicker.SetPistolRunning(false);

        base.DeactivateAbility();
    }
}