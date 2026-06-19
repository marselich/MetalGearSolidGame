using UnityEngine;

public class SpeedUpItem : Item
{
    [SerializeField] private float _speedMultiply;
    [SerializeField] private float _durationTime;

    private Player _player;
    private float _defaultMoveSpeed;
    private float _time;

    private void Update()
    {
        if (_player == null)
            return;

        _time += Time.deltaTime;

        if (_time >= _durationTime)
            DeactivateAbility();
    }

    public override void ActivateAbilityTo(Player player)
    {
        _player = player;
        _defaultMoveSpeed = player.PlayerMovement.MoveSpeed;

        player.PlayerMovement.MoveSpeed = _defaultMoveSpeed * _speedMultiply;
    }

    private void DeactivateAbility()
    {
        _player.PlayerMovement.MoveSpeed = _defaultMoveSpeed;
        _player = null;
    }
}
