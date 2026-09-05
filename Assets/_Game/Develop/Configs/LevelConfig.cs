using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Gameplay/LevelConfig", fileName = "LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [field: SerializeField] public Vector3 MainHeroStartPosition { get; private set; }
    [field: SerializeField] public List<Vector3> EnemiesSpawnPositions { get; private set; }
    [field: SerializeField] public float TimePassedToWin { get; private set; }
    [field: SerializeField] public int EnemiesNeedToKillCount { get; private set; }
    [field: SerializeField] public int MaxEnemiesToDefeatCount { get; private set; }


    [ContextMenu("UpdateHeroStartPosition")]
    private void UpdateHeroStartPosition()
    {
        GameObject startHeroPosition = GameObject.FindGameObjectWithTag("StartHeroPosition");

        MainHeroStartPosition = startHeroPosition.transform.position;
    }

    [ContextMenu("UpdateEnemiesSpawnPositions")]
    private void UpdateEnemiesSpawnPositions()
    {
        GameObject enemySpawnPointsParent = GameObject.FindGameObjectWithTag("EnemySpawnPoints");

        foreach (Transform enemySpawnPoint in enemySpawnPointsParent.GetComponentsInChildren<Transform>().Skip(1))
            EnemiesSpawnPositions.Add(enemySpawnPoint.position);
    }
}