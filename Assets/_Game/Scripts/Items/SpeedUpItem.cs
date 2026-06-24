using UnityEngine;

public class SpeedUpItem : Item
{
    [SerializeField] private float _speedMultiply;
    [SerializeField] private float _durationTime;

    private AnimationPicker _animationPicker;
    private EffectsActivator _effectsActivator;
    private PlayerMovement _playerMovement;

    public override void InitializeTo(GameObject character)
    {
        base.InitializeTo(character);
        _deactivateTime = _durationTime;

        _animationPicker = character.GetComponent<AnimationPicker>();
        _effectsActivator = character.GetComponent<EffectsActivator>();
        _playerMovement = character.GetComponent<PlayerMovement>();
    }

    public override void ActivateAbility()
    {
        base.ActivateAbility();

        if (_isActived)
            return;

        _animationPicker.Drink();
        _effectsActivator.ActivateSpeedUp();

        _playerMovement.MoveSpeed = _playerMovement.DefaultMoveSpeed * _speedMultiply;

        _isActived = true;
    }

    protected override void DeactivateAbility()
    {
        _playerMovement.MoveSpeed = _playerMovement.DefaultMoveSpeed;

        base.DeactivateAbility();
    }
}
