using UnityEngine;

public class DyingBehaviour : IReactionBehaviour
{
    public void ProcessReaction(Enemy enemy)
    {
        Debug.Log("АААААА БОЮСЬ");
        enemy.Die();
    }
}