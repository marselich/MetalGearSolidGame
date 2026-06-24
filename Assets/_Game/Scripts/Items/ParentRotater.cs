using UnityEngine;

public class ParentRotater : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _parent;

    private void Awake()
    {
        _parent = transform.parent;
        IsRotated = true;
    }

    public bool IsRotated { get; set; }

    private void Update()
    {
        if (IsRotated == false)
            return;

        _parent.Rotate(Vector3.up, _speed * Time.deltaTime);
    }
}