using System;
using UnityEngine;

public class Health
{
    public event Action<float, float> Changed
    {
        add => _value.Changed += value;
        remove => _value.Changed -= value;
    }
    public event Action Died;

    private ReactiveVariable<float> _value;

    public Health(float value)
    {
        MaxValue = value;
        _value = new ReactiveVariable<float>(value);
    }

    public bool IsDied => _value.Value == 0;
    public float MaxValue { get; private set; }

    public float Value => _value.Value;

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        _value.Value -= damage;

        if (_value.Value - damage < 0)
            _value.Value = 0;

        if (IsDied)
            Died?.Invoke();

        Debug.Log(_value.Value.ToString());
    }
}