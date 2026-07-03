using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Enemy : MonoBehaviour
{
    private const float MoveSpeed = 1;
    private const float RotationSpeed = 800;

    private IBehaviour _restingBehaviour;
    private IBehaviour _reactionBehaviour;

    private CharacterMovement _characterMovement;

    public CharacterMovement CharacterMovement => _characterMovement;
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

    public void Initialize(IBehaviour restingBehaviour, IBehaviour reactionBehaviour)
    {
        _restingBehaviour = restingBehaviour;
        _reactionBehaviour = reactionBehaviour;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    private void ProcessResting() => _restingBehaviour.Update();

    private void ProcessReaction() => _reactionBehaviour.Update();
}