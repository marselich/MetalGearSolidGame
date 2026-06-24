using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _value;

    public void Add(float value)
    {
        _value += value;
    }

    public void ShowInfo()
    {
        Debug.Log($"Здоровье: {_value}");
    }
}