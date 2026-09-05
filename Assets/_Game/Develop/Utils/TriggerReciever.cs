using System;
using UnityEngine;

public class TriggerReciever : MonoBehaviour
{
    public event Action<Collider> TriggerEnetered;
    public event Action<Collider> TriggerStayed;

    private void OnTriggerEnter(Collider other)
    {
        TriggerEnetered?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        TriggerStayed?.Invoke(other);
    }
}