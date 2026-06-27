using UnityEngine;

public class RunAwayBehaviour : IReactionBehaviour
{
    public void ProcessReaction(Enemy enemy)
    {
        Vector3 direction = enemy.transform.position - enemy.AgroTarget.transform.position;

        direction.y = 0;

        enemy.CharacterMovement.Move(direction.normalized);
    }
}
