using UnityEngine;

public class EnemyAgroDetector : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (CheckPlayerTarget(other))
        {
            _enemy.IsAgro = true;
            _enemy.AnimationPicker.Stay();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CheckPlayerTarget(other))
        {
            _enemy.IsAgro = false;
            _enemy.AnimationPicker.Stay();
            _enemy.CharacterMovement.MoveSpeed = _enemy.WalkingSpeed;
        }
    }

    private bool CheckPlayerTarget(Collider other) => other.GetComponent<PlayerMovement>();
}