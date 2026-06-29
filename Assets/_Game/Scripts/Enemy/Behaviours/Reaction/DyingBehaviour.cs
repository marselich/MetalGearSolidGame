using UnityEngine;

public class DyingBehaviour : IReactionBehaviour
{
    private const float Delay = 3f;
    private float _time;

    public void ProcessReaction(Enemy enemy)
    {
        _time += Time.deltaTime;

        enemy.AnimationPicker.Scared();
        enemy.transform.LookAt(enemy.AgroTarget.transform);

        if (_time >= Delay)
        {
            enemy.Die();
        }

        if (_time >= Delay - 0.5f)
        {
            enemy.DieEffect.Play();

            enemy.transform.localScale = Vector3.MoveTowards(enemy.transform.localScale, Vector3.zero, Time.deltaTime);
        }
    }
}