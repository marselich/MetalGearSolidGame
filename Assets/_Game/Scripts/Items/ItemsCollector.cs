using UnityEngine;

[RequireComponent(typeof(Player))]
public class ItemsCollector : MonoBehaviour
{
    private Player _player;
    private Item _collectedItem;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_collectedItem != null)
            {
                _collectedItem.ActivateAbility();
            }
            else
            {
                Debug.Log("Нет предмета в руке");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_collectedItem)
            return;

        Item otherItem = other.GetComponent<Item>();

        if (otherItem)
        {
            otherItem.InitializeTo(_player);
            _collectedItem = otherItem;
        }
    }
}