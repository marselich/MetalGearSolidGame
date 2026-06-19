using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _healthValue;
    [SerializeField] private GameObject _handPoint;

    public Health Health { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }
    public PistolController PistolController { get; private set; }
    public GameObject HandPoint => _handPoint;

    private void Awake()
    {
        Health = new Health(_healthValue);
        PlayerMovement = GetComponent<PlayerMovement>();
        PistolController = GetComponent<PistolController>();
    }
}