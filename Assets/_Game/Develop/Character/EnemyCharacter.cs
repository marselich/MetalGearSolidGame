using UnityEngine;

public class EnemyCharacter : Character
{
    private float _damageValue;
    private TriggerReciever _triggerReciever;

    public void Initialize(float damageValue)
    {
        _damageValue = damageValue;

        _triggerReciever = GetComponent<TriggerReciever>();

        _triggerReciever.TriggerStayed += OnHited;
        Destroyed += OnDestroyed;
    }

    private void OnHited(Collider collider)
    {
        MainCharacter mainCharacter = collider.GetComponent<MainCharacter>();
        IDamagable damagable = mainCharacter?.GetComponent<IDamagable>();

        damagable?.TakeDamage(_damageValue);
    }

    private void OnDestroyed(MonoDestroyable destroyable)
    {
        _triggerReciever.TriggerStayed -= OnHited;
        destroyable.Destroyed -= OnDestroyed;
    }
}