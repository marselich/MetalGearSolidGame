using UnityEngine;

[RequireComponent(typeof(HandPointStorage))]
public class ItemsCollector : MonoBehaviour
{
    private Item _collectedItem;

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
            otherItem.InitializeTo(gameObject);
            _collectedItem = otherItem;
        }
    }
}