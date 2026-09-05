using System;
using UnityEngine;

public class CollisionReciever : MonoBehaviour
{
    public event Action<Collision> CollisionEnetered;

    private void OnCollisionEnter(Collision collision)
    {
        CollisionEnetered?.Invoke(collision);
    }
}