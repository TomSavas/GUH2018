using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyPrefabs;
    public int SpawnsPerMinute;
    public bool Enabled;

    private bool _enemySpawned;
    // TODO: Not really random, fix
    private void Update()
    {
        if (Enabled)
        {
            int spawnChance = (Mathf.RoundToInt(Time.time) % (60 / SpawnsPerMinute + 1));
            bool spawnNow = Random.Range(spawnChance, 60 / SpawnsPerMinute) == 60 / SpawnsPerMinute;

            if (spawnChance == 0)
                _enemySpawned = false;
            
            if (!_enemySpawned && spawnNow)
                SpawnEnemy();
        }
    }
    
    private void SpawnEnemy()
    {
        if (EnemyPrefabs.Count != 0)
        {
            _enemySpawned = true;
            GameObject randomEnemy = EnemyPrefabs[Random.Range(0, EnemyPrefabs.Count)];
            randomEnemy = Instantiate(randomEnemy, GenerateCoord(), Quaternion.identity);
            //randomEnemy.transform.parent = Camera.main.gameObject.transform;
        }
    }

    private Vector2 GenerateCoord()
    {
        return new Vector2(GenerateXCoord(), GenerateYCoord());
    }
    
    private float GenerateXCoord()
    {
        return Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 0, 0)).x;
    }

    private float GenerateYCoord()
    {
        var aboveScreen = Random.Range(0, 1) == 0;
        if (aboveScreen)
        {
            return Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        }
        else
        {
            return Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        }
    }
}
