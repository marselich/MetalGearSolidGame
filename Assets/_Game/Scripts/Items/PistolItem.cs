using UnityEngine;

public class PistolItem : Item
{
    [SerializeField] Transform _barrelPoint;
    [SerializeField] float _duration;

    private GunController _gunController;
    private AnimationPicker _animationPicker;

    public Transform BarrelPoint => _barrelPoint;

    public override void InitializeTo(GameObject character)
    {
        base.InitializeTo(character);

        _gunController = character.GetComponent<GunController>();
        _animationPicker = character.GetComponent<AnimationPicker>();

        _deactivateTime = _duration;

        _animationPicker.SetPistolIdle(true);
    }

    public override void ActivateAbility()
    {
        base.ActivateAbility();

        _gunController.ShootWith(this);
    }

    protected override void DeactivateAbility()
    {
        _animationPicker.SetPistolIdle(false);
        _animationPicker.SetPistolRunning(false);

        base.DeactivateAbility();
    }
}