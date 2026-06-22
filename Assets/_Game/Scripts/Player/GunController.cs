using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletLifetime;

    private Queue<GameObject> _bullets;
    private float _time;

    private void Awake()
    {
        _bullets = new Queue<GameObject>();
    }

    private void Update()
    {
        if (_bullets.Count == 0)
            return;

        CheckBulletLifetime();

        foreach (GameObject bullet in _bullets)
            bullet.transform.Translate(Vector3.forward * _bulletSpeed * Time.deltaTime, Space.Self);
    }

    public void ShootWith(PistolItem pistol)
    {
        GameObject bullet = Instantiate(_bulletPrefab, pistol.BarrelPoint.position, pistol.BarrelPoint.rotation);
        _bullets.Enqueue(bullet);
    }

    private void CheckBulletLifetime()
    {
        _time += Time.deltaTime;

        if (_time >= _bulletLifetime)
        {
            Destroy(_bullets.Dequeue().gameObject);
            _time = 0;
        }
    }
}