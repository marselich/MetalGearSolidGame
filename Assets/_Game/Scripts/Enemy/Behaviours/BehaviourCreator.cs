using System.Collections.Generic;
using UnityEngine;

public class BehaviourCreator
{
    private CharacterMovement _characterMovement;
    private AnimationPicker _animationPicker;
    private ITargetProvider _agroTarget;
    private float _runningSpeed;
    private IKillable _killableObject;
    private ParticleSystem _dieEffect;
    private Queue<Transform> _spotPatrolingPoints;

    public BehaviourCreator(
        CharacterMovement characterMovement,
        AnimationPicker animationPicker,
        ITargetProvider agroTarget,
        float runningSpeed,
        IKillable killableObject,
        ParticleSystem dieEffect,
        Queue<Transform> spotPatrolingPoints
        )
    {
        _characterMovement = characterMovement;
        _animationPicker = animationPicker;
        _agroTarget = agroTarget;
        _runningSpeed = runningSpeed;
        _killableObject = killableObject;
        _dieEffect = dieEffect;
        _spotPatrolingPoints = spotPatrolingPoints;
    }

    public IBehaviour Create(ReactionTypes reactionTypes)
    {
        switch (reactionTypes)
        {
            case ReactionTypes.RunAway:
                return new RunAwayBehaviour(_characterMovement, _animationPicker, _agroTarget, _runningSpeed);

            case ReactionTypes.Aggressive:
                return new AggressiveBehaviour(_characterMovement, _animationPicker, _agroTarget, _runningSpeed);

            case ReactionTypes.Dying:
                return new DyingBehaviour(_characterMovement, _animationPicker, _agroTarget, _killableObject, _dieEffect);

            default:
                Debug.LogError($"No realization for {reactionTypes.ToString()}");
                return null;
        }
    }

    public IBehaviour Create(RestingTypes restingTypes)
    {
        switch (restingTypes)
        {
            case RestingTypes.Idle:
                return new IdleBehaviour();

            case RestingTypes.SpotPatrolling:
                return new SpotPatrollingBehaviour(_characterMovement, _animationPicker, _spotPatrolingPoints);

            case RestingTypes.ChaoticPatrolling:
                return new ChaoticPatrollingBehaviour(_characterMovement, _animationPicker);

            default:
                Debug.LogError($"No realization for {restingTypes.ToString()}");
                return null;
        }
    }
}