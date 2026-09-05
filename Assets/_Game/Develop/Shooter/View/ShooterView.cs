using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class ShooterView : IDisposable
{
    private ParticleSystem _shootEffect;

    private IShooter _shooter;

    public ShooterView(IShooter shooter, ParticleSystem shootEffectPrefab)
    {
        _shootEffect = Object.Instantiate(shootEffectPrefab);
        _shooter = shooter;

        _shooter.Shooted += OnShooted;
    }

    public void Dispose()
    {
        _shooter.Shooted -= OnShooted;
    }

    private void OnShooted(Vector3 position)
    {
        _shootEffect.gameObject.transform.position = position;
        _shootEffect.Play();
    }
}