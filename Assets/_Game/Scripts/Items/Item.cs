using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] Vector3 _inHandPosition;
    [SerializeField] Vector3 _inHandRotation;

    protected float _deactivateTime = 0;
    protected bool _isActived = false;
    protected Player _player;

    private float _time;
    private bool _isInitialized = false;
    private ParentRotater _parentRotater;
    private ParticleSystem _itemParticle;

    private void Awake()
    {
        _parentRotater = GetComponentInChildren<ParentRotater>();
        _itemParticle = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (_isInitialized == false)
            return;

        _time += Time.deltaTime;

        if (_time >= _deactivateTime)
        {
            DeactivateAbility();
            _time = 0;
        }
    }

    public virtual void InitializeTo(Player player)
    {
        _parentRotater.IsRotated = false;
        _itemParticle.Stop();
        _player = player;
        transform.SetParent(player.HandPoint.transform);
        transform.localPosition = _inHandPosition;
        transform.localRotation = Quaternion.Euler(_inHandRotation);
    }

    public virtual void ActivateAbility()
    {
        _isInitialized = true;
    }

    protected virtual void DeactivateAbility()
    {
        _isInitialized = false;
        _isActived = false;
        Destroy(gameObject);
    }
}
