using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject redPrefab;

    [SerializeField]
    SpriteInfo redSpriteInfo;

    [SerializeField]
    GameObject purpPrefab;

    [SerializeField]
    SpriteInfo purpSpriteInfo;

    [SerializeField]
    CollisionManager collisionManager;

    [SerializeField]
    List<GameObject> redEnemies = new List<GameObject>();

    [SerializeField]
    List<GameObject> purpEnemies = new List<GameObject>();

    int redSpawnNum = 3;
    int purpSpawnNum = 1;
    Vector3 redSpawn;
    Vector3 purpSpawn;

    private void Start()
    {
        redSpawn.y = 5;
        purpSpawn.x = 10.5f;
        SpawnRedEnemy();
    }

    private void Update()
    {
        if (redEnemies.Count < 3) //If there are less than 3 enemies spawn more
        {
            SpawnRedEnemy();
        }
        if (purpEnemies.Count < 2) //If there are less than 3 enemies spawn more
        {
            SpawnPurpEnemy();
        }
    }

    //Method for spawning red enemies that fly down
    private void SpawnRedEnemy()
    {
        for (int i = 0; i < redSpawnNum; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-9, 9), redSpawn.y, 0);
            GameObject newEnemy = Instantiate(redPrefab, spawnPosition, Quaternion.Euler(0,0,180));
            redEnemies.Add(newEnemy);
            SpriteInfo sprite = newEnemy.GetComponent<SpriteInfo>();
            collisionManager.AddCollidable(sprite);
        }
    }

    //Method for spawning purple enemies that fly left
    private void SpawnPurpEnemy()
    {
        for (int i = 0; i < purpSpawnNum; i++)
        {
            Vector3 spawnPosition = new Vector3(purpSpawn.x, Random.Range(-4, 4), 0);
            GameObject newEnemy = Instantiate(purpPrefab, spawnPosition, Quaternion.Euler(0, 0, 90));
            purpEnemies.Add(newEnemy);
            SpriteInfo sprite = newEnemy.GetComponent<SpriteInfo>();
            collisionManager.AddCollidable(sprite);
        }
    }


}