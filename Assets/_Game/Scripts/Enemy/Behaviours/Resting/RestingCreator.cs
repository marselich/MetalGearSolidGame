using UnityEngine;

public static class RestingCreator
{
    public static IRestingBehaviour Create(RestingTypes restingTypes)
    {
        switch (restingTypes)
        {
            case RestingTypes.Idle:
                return new IdleBehaviour();

            case RestingTypes.SpotPatrolling:
                return new SpotPatrollingBehaviour();

            case RestingTypes.ChaoticPatrolling:
                return new ChaoticPatrollingBehaviour();

            default:
                Debug.LogError($"No realization for {restingTypes.ToString()}");
                return null;
        }
    }
}