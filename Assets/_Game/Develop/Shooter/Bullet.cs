using System.Collections;
using UnityEngine;

[RequireComponent(typeof(TriggerReciever))]
public class Bullet : MonoDestroyable
{
    private float _speed;
    private float _lifetime;
    private float _damageValue;

    private TriggerReciever _triggerReciever;

    public void Initialize(float speed, float lifetime, float damageValue)
    {
        _speed = speed;
        _lifetime = lifetime;
        _damageValue = damageValue;

        _triggerReciever = GetComponent<TriggerReciever>();

        _triggerReciever.TriggerEnetered += OnHited;
        Destroyed += OnDestoyed;

        StartCoroutine(ProcessBulletLifetime());
    }

    private void OnHited(Collider collider)
    {
        IDamagable damagable = collider.GetComponent<IDamagable>();

        damagable?.TakeDamage(_damageValue);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime, Space.Self);
    }

    private IEnumerator ProcessBulletLifetime()
    {
        yield return new WaitForSeconds(_lifetime);
        Destroy(gameObject);
    }

    private void OnDestoyed(MonoDestroyable destroyable)
    {
        _triggerReciever.TriggerEnetered -= OnHited;
    }
}