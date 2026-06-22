using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _healthValue;
    [SerializeField] private GameObject _handPoint;
    [SerializeField] private Animator _animator;

    public Health Health { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }
    public GameObject HandPoint => _handPoint;
    public GunController GunController { get; private set; }
    public AnimationPicker AnimationPicker { get; private set; }
    public EffectsActivator EffectsActivator { get; private set; }

    private void Awake()
    {
        AnimationPicker = new AnimationPicker(_animator);
        Health = new Health(_healthValue);

        PlayerMovement = GetComponent<PlayerMovement>();
        PlayerMovement.Initialize(AnimationPicker);

        GunController = GetComponent<GunController>();
        EffectsActivator = GetComponent<EffectsActivator>();
    }
}