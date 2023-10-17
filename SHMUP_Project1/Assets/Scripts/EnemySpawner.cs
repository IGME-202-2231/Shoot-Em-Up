using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //[SerializeField]
    //GameObject enemyPrefab;
    //
    //[SerializeField]
    //float spawnInterval = 3.5f;
    //
    //private void Start()
    //{
    //    StartCoroutine(spawnEnemy(spawnInterval, enemyPrefab));
    //}
    //
    //private IEnumerator spawnEnemy(float interval, GameObject enemy)
    //{
    //    yield return new WaitForSeconds(interval);
    //    GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-6f, 6f), 0), Quaternion.identity);
    //    StartCoroutine(spawnEnemy(interval, enemy));
    //}

    //Variables
    [SerializeField]
    GameObject enemyPrefab; //Enemy    

    [SerializeField]
    float timer = 0f;   //Spawner interval

    [SerializeField]
    List<GameObject> enemies = new List<GameObject>(); //List of enemies
    bool isWaiting = false;

    //Getters and setters
    public List<GameObject> Enemies
    {
        get
        {
            return enemies;
        }
        set
        { 
            enemies = value; 
        }
    }

    //OnStart calls spawn once
    public void Start()
    {
        Spawn();
    }

    public void Update()
    {
        if (!isWaiting) //if is waiting is false
        {
            //Reset Timer
            TimerReset();
        }

        //Decreases timer
        timer -= 1 * Time.deltaTime;

        //If waiting and timer is less than 0, call spawn
        if(isWaiting && timer < 0f)
        {
            Spawn();
        }
    }

    //Spawn Method
    public void Spawn()
    {
        //Set isWaiting to false
        isWaiting = false;

        //Loop Through all old enemies and move them down
        for(int i = 0; i < enemies.Count; i++)
        {
            //Make new x,y variables
            float newY = enemies[i].transform.position.y - 2;
            enemies[i].transform.position = new Vector3(enemies[i].transform.position.x, newY, enemies[i].transform.position.z);
        }

        //Set starting x
        int x = -10;
        //Loop through 11 times
        for(int i = 0;i < 11;i++)
        {
            //Create enemy at same Y and sets X to int x then adds 2 to the value for the offset
            enemies.Add(Instantiate(enemyPrefab, new Vector3(x, 4, 0), transform.rotation));
            x += 2;
        }
    }

    //Resets timer
    public void TimerReset()
    {
        //Sets isWaiting to true and timer to 10
        isWaiting = true;
        timer = 10;
    }

}