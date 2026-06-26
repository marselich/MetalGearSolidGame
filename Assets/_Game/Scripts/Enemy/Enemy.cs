using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IRestingBehaviour _restingBehaviour;
    private IReactionBehaviour _reactionBehaviour;

    public void Initialize(IRestingBehaviour restingBehaviour, IReactionBehaviour reactionBehaviour)
    {
        _restingBehaviour = restingBehaviour;
        _reactionBehaviour = reactionBehaviour;
    }

    public void Rest() => _restingBehaviour.Rest();

    public void React() => _reactionBehaviour.React();
}