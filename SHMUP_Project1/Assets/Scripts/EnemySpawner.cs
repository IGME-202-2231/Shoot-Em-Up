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

    //public List<GameObject> redEnemies = new List<GameObject>();
    public List<SpriteInfo> redEnemies = new List<SpriteInfo>();
    public List<SpriteInfo> purpEnemies = new List<SpriteInfo>();

    int redSpawnNum = 5;
    int purpSpawnNum = 2;
    Vector3 redSpawn;
    Vector3 purpSpawn;

    private void Start()
    {
        redSpawn.y = 5;
        purpSpawn.x = 10.5f;
        SpawnRedEnemy();
        SpawnPurpEnemy();

        // Set the reference to the CollisionManager
        collisionManager.SetEnemySpawner(this);
    }

    private void Update()
    {
        if (redEnemies.Count < 3) //If there are less than 3 enemies spawn 5 more
        {
            SpawnRedEnemy();
        }
        if (purpEnemies.Count < 2) //If there are less than 2 enemies spawn 2 more
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
            SpriteInfo sprite = newEnemy.GetComponent<SpriteInfo>();
            redEnemies.Add(sprite);
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
            SpriteInfo sprite = newEnemy.GetComponent<SpriteInfo>();
            purpEnemies.Add(sprite);
            collisionManager.AddCollidable(sprite);
        }
    }

    //*************FIX THIS***********************************************
    //2 Methods to remove enemies from EnemySpawner lists
    public void RemoveRedEnemy(SpriteInfo sprite)
    {
        redEnemies.Remove(sprite);
    }
    public void RemovePurpEnemy(SpriteInfo sprite)
    {
        purpEnemies.Remove(sprite);
    }


}