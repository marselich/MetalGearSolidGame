using UnityEngine;

public class Health
{
    private float _health;

    public Health(float health)
    {
        _health = health;
    }

    public void Add(float value)
    {
        _health += value;
    }

    public void ShowInfo()
    {
        Debug.Log($"Здоровье: {_health}");
    }
}