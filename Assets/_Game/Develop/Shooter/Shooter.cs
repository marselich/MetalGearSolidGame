using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Shooter : IShooter
{
    public event Action<Vector3> Shooted;

    private BulletConfig _bulletConfig;
    private Transform _startTransform;

    public Shooter(BulletConfig bulletConfig, Transform startTransform)
    {
        _bulletConfig = bulletConfig;
        _startTransform = startTransform;
    }

    public void Shoot(float damage)
    {
        Bullet bullet = Object.Instantiate(_bulletConfig.Prefab, _startTransform.position, _startTransform.rotation, null);

        bullet.Initialize(_bulletConfig.Speed, _bulletConfig.Lifetime, damage);

        Shooted?.Invoke(_startTransform.position);
    }
}