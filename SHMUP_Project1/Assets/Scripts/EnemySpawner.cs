using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    SpriteInfo spriteInfo;

    [SerializeField]
    CollisionManager collisionManager;

    [SerializeField]
    List<GameObject> enemies = new List<GameObject>();

    int spawnNum = 3;
    Vector3 spawn;
    SpriteInfo sprite;

    private void Start()
    {
        for (int i = 0; i < spawnNum; i++)
        {
            spawn.x = Random.Range(11, 15);
            spawn.y = Random.Range(-4, 4);
            enemyPrefab = Instantiate(enemyPrefab, spawn, Quaternion.identity);
            enemies.Add(enemyPrefab);
            sprite = enemies[i].GetComponent<SpriteInfo>();
            collisionManager.AddCollidable(sprite);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Example condition for spawning enemies
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < spawnNum; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(11, 15), Random.Range(-4, 4), 0);
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemies.Add(newEnemy);
            SpriteInfo sprite = newEnemy.GetComponent<SpriteInfo>();
            collisionManager.AddCollidable(sprite);
        }
    }
}