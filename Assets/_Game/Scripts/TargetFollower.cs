using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 1f;

    private Vector3 _offset;

    private void Awake()
    {
        _offset = transform.position;
    }

    private void Update()
    {
        Vector3 desiredPosition = _target.position + _offset;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, _speed * Time.deltaTime);
    }
}
