using UnityEngine;

public class EnemyAgroDetector : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (CheckPlayerTarget(other))
        {
            _enemy.IsAgro = true;
            _enemy.AgroTarget = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CheckPlayerTarget(other))
        {
            _enemy.IsAgro = false;
            _enemy.AgroTarget = null;
        }
    }

    private bool CheckPlayerTarget(Collider other) => other.GetComponent<PlayerMovement>();
}