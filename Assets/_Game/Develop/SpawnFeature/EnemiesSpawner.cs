using System.Collections;
using UnityEngine;

public class EnemiesSpawner
{
    private MonoBehaviour _spawnRunner;
    private EnemiesFactory _enemiesFactory;
    private EnemiesConfig _config;
    private LevelConfig _levelConfig;

    private Coroutine _spawnProcess;

    public EnemiesSpawner(
        MonoBehaviour spawnRunner,
        EnemiesFactory enemiesFactory,
        EnemiesConfig config,
        LevelConfig levelConfig
        )
    {
        _spawnRunner = spawnRunner;
        _enemiesFactory = enemiesFactory;
        _config = config;
        _levelConfig = levelConfig;
    }

    public void StartSpawn()
    {
        _spawnProcess = _spawnRunner.StartCoroutine(SpawnProcess());
    }

    public void StopSpawn()
    {
        _spawnRunner.StopCoroutine(_spawnProcess);
    }

    private IEnumerator SpawnProcess()
    {
        while (true)
        {
            EnemyCharacter instance = _enemiesFactory.CreateEnemy(_config, GetRandomSpawnPoint());

            yield return new WaitForSeconds(_config.SpawnFrequency);
        }
    }

    private Vector3 GetRandomSpawnPoint()
        => _levelConfig.EnemiesSpawnPositions[Random.Range(0, _levelConfig.EnemiesSpawnPositions.Count)];
}