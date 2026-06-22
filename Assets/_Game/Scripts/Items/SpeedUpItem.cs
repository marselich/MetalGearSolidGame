using UnityEngine;

public class SpeedUpItem : Item
{
    [SerializeField] private float _speedMultiply;
    [SerializeField] private float _durationTime;

    public override void InitializeTo(Player player)
    {
        base.InitializeTo(player);
        _deactivateTime = _durationTime;
    }

    public override void ActivateAbility()
    {
        base.ActivateAbility();

        if (_isActived)
            return;

        _player.AnimationPicker.Drink();
        _player.EffectsActivator.ActivateSpeedUp();

        _player.PlayerMovement.MoveSpeed = _player.PlayerMovement.DefaultMoveSpeed * _speedMultiply;

        _isActived = true;
    }

    protected override void DeactivateAbility()
    {
        _player.PlayerMovement.MoveSpeed = _player.PlayerMovement.DefaultMoveSpeed;
        _player = null;

        base.DeactivateAbility();
    }
}
