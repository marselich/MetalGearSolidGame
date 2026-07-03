using System;
using UnityEngine;

public class DyingBehaviour : IBehaviour
{
    private const float Delay = 3f;

    private CharacterMovement _characterMovement;
    private AnimationPicker _animationPicker;
    private Transform _agroTarget;
    private Action _dieAction;
    private ParticleSystem _dieEffect;
    private float _time;

    public DyingBehaviour(
        CharacterMovement characterMovement,
        AnimationPicker animationPicker,
        Transform agroTarget,
        Action dieAction,
        ParticleSystem dieEffect
        )
    {
        _characterMovement = characterMovement;
        _animationPicker = animationPicker;
        _agroTarget = agroTarget;
        _dieAction = dieAction;
        _dieEffect = dieEffect;
        _time = 0;
    }

    private Transform CharacterTransform => _characterMovement.CharacterController.transform;

    public void Update()
    {
        _time += Time.deltaTime;

        _animationPicker.Scared();
        CharacterTransform.LookAt(_agroTarget.transform);

        if (_time >= Delay)
        {
            _dieAction.Invoke();
        }

        if (_time >= Delay - 0.5f)
        {
            _dieEffect.Play();

            CharacterTransform.localScale = Vector3.MoveTowards(CharacterTransform.localScale, Vector3.zero, Time.deltaTime);
        }
    }
}