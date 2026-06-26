using UnityEngine;

public static class ReactionFactory
{
    public static IReactionBehaviour Create(ReactionTypes reactionTypes)
    {
        switch (reactionTypes)
        {
            case ReactionTypes.RunAway:
                return new RunAwayBehaviour();

            case ReactionTypes.Aggressive:
                return new AggressiveBehaviour();

            case ReactionTypes.Dying:
                return new DyingBehaviour();

            default:
                Debug.LogError($"No realization for {reactionTypes.ToString()}");
                return null;
        }
    }
}
