using System;
using UnityEngine;

public interface IShooter
{
    event Action<Vector3> Shooted;
    void Shoot(float damage);
}