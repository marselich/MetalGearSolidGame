using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private List<ItemsSpawnPoint> _spawnPoints;
    [SerializeField] private float _cooldown;

    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _cooldown)
        {
            List<ItemsSpawnPoint> itemsSpawnPoints = GetEmptyPoints();

            if (itemsSpawnPoints.Count == 0)
            {
                _time = 0;
                return;
            }

            ItemsSpawnPoint randomPoint = itemsSpawnPoints[Random.Range(0, itemsSpawnPoints.Count)];
            Item randomItem = _items[Random.Range(0, _items.Count)];

            Item newItem = Instantiate(randomItem, randomPoint.transform.position, Quaternion.identity, randomPoint.transform);

            randomPoint.Occupy(newItem);

            _time = 0;
        }
    }

    private List<ItemsSpawnPoint> GetEmptyPoints()
    {
        List<ItemsSpawnPoint> itemsSpawnPoints = new List<ItemsSpawnPoint>();

        foreach (ItemsSpawnPoint point in _spawnPoints)
            if (point.IsEmpty)
                itemsSpawnPoints.Add(point);

        return itemsSpawnPoints;
    }
}