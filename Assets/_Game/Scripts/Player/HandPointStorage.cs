using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class HandPointStorage : MonoBehaviour
{
    [field: SerializeField] public GameObject HandPoint { get; private set; }
}