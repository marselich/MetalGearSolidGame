using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _spotPatrolingPoints;

    private const float MoveSpeed = 1;
    private const float RotationSpeed = 800;

    private IRestingBehaviour _restingBehaviour;
    private IReactionBehaviour _reactionBehaviour;

    private CharacterMovement _characterMovement;

    public CharacterMovement CharacterMovement => _characterMovement;
    public List<Transform> SpotPatrolingPoints
        => new List<Transform>(_spotPatrolingPoints.GetComponentsInChildren<Transform>());
    public GameObject AgroTarget { get; set; }
    public bool IsAgro { get; set; }
    public AnimationPicker AnimationPicker { get; set; }
    public float WalkingSpeed => MoveSpeed;
    public float RunningSpeed => WalkingSpeed * 2.5f;
    public ParticleSystem DieEffect { get; private set; }

    private void Awake()
    {
        IsAgro = false;
        CharacterController characterController = GetComponent<CharacterController>();

        _characterMovement = new CharacterMovement(characterController, MoveSpeed, RotationSpeed);

        AnimationPicker = GetComponent<AnimationPicker>();
        DieEffect = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (IsAgro)
            ProcessReaction();
        else
            ProcessResting();
    }

    public void Initialize(IRestingBehaviour restingBehaviour, IReactionBehaviour reactionBehaviour)
    {
        _restingBehaviour = restingBehaviour;
        _reactionBehaviour = reactionBehaviour;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void ProcessResting() => _restingBehaviour.ProcessResting(this);

    private void ProcessReaction() => _reactionBehaviour.ProcessReaction(this);
}