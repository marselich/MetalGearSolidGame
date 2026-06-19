using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private List<Item> _items;
    [SerializeField] private List<ItemsSpawnPoint> _spawnPoints;

    private void Update()
    {
        ItemsSpawnPoint randomPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        Item randomItem = _items[Random.Range(0, _items.Count)];

        Instantiate(randomItem, randomPoint.transform.position, randomPoint.transform.rotation);
    }

    private void GetRandomPoint()
    {
        ItemsSpawnPoint randomPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }


}
