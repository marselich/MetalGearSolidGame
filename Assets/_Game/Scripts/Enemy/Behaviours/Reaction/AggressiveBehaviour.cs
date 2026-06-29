using UnityEngine;

public class AggressiveBehaviour : IReactionBehaviour
{
    public void ProcessReaction(Enemy enemy)
    {
        Vector3 direction = enemy.AgroTarget.transform.position - enemy.transform.position;

        direction.y = 0;

        enemy.AnimationPicker.SetRunning(true);
        enemy.CharacterMovement.MoveSpeed = enemy.RunningSpeed;
        enemy.CharacterMovement.Move(direction.normalized);
    }
}
