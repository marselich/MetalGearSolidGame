using UnityEngine;

public class DyingBehaviour : IBehaviour
{
    private const float Delay = 3f;

    private CharacterMovement _characterMovement;
    private AnimationPicker _animationPicker;
    private ITargetProvider _agroTarget;
    private IKillable _killableObject;
    private ParticleSystem _dieEffect;
    private float _time;

    public DyingBehaviour(
        CharacterMovement characterMovement,
        AnimationPicker animationPicker,
        ITargetProvider agroTarget,
        IKillable killableObject,
        ParticleSystem dieEffect
        )
    {
        _characterMovement = characterMovement;
        _animationPicker = animationPicker;
        _agroTarget = agroTarget;
        _killableObject = killableObject;
        _dieEffect = dieEffect;
        _time = 0;
    }

    private Transform CharacterTransform => _characterMovement.CharacterController.transform;

    public void Update()
    {
        _time += Time.deltaTime;

        _animationPicker.Scared();
        CharacterTransform.LookAt(_agroTarget.Target.transform);

        if (_time >= Delay)
        {
            _killableObject.Kill();
        }

        if (_time >= Delay - 0.5f)
        {
            _dieEffect.Play();

            CharacterTransform.localScale = Vector3.MoveTowards(CharacterTransform.localScale, Vector3.zero, Time.deltaTime);
        }
    }
}