using UnityEngine;

public class ShooterController : Controller
{
    private IShooter _shooter;
    private float _damage;

    public ShooterController(IShooter shooter, float damage)
    {
        _shooter = shooter;
        _damage = damage;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            _shooter.Shoot(_damage);
    }
}