using UnityEngine;

public class AggressiveBehaviour : IReactionBehaviour
{
    public void ProcessReaction(Enemy enemy)
    {
        Vector3 direction = enemy.AgroTarget.transform.position - enemy.transform.position;

        direction.y = 0;

        enemy.CharacterMovement.Move(direction.normalized);
    }
}
