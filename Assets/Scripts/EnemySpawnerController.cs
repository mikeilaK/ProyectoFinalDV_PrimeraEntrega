using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject playerPrefab;

    private LevelDifficulty levelDifficulty;
    
    private Difficulty difficulty;

    private float startDelay = 1.0f;
    private float repeatRate = 1.0f;
    private int totalZombies = 0;

    void Start()
    {
        levelDifficulty = GameManager.Instance.levelDifficulty;
        difficulty = levelDifficulty.selectedDifficulty;
        totalZombies = levelDifficulty.LevelOptions[difficulty];
        switch (difficulty)
        {
            case Difficulty.Easy:
                InvokeRepeating("SpawnEnemy", startDelay + 2f, repeatRate + 2f);
                break;

            case Difficulty.Normal:
                InvokeRepeating("SpawnEnemy", startDelay, repeatRate);
                break;

            case Difficulty.Hard:
                InvokeRepeating("SpawnEnemy", startDelay, repeatRate - 1f);
                break;
        }
    }

    public void SpawnEnemy()
    {
        float angle = Random.Range(0f, 360f);
        float distanceFromPlayer = Random.Range(20f, 25f);

        Vector3 spawnPosition = playerPrefab.transform.position + new Vector3 (Mathf.Cos(angle),0,Mathf.Sin(angle))*distanceFromPlayer;
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        totalZombies = totalZombies - 1;
    }
}

