using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public GameObject livesPrefab; // Assign your life icon prefab in the Inspector.
    public Transform spawnPoint; // Assign an empty GameObject as the spawn point for the lives.

    public int remainingLives = 3;

    private void Start()
    {
        SpawnLives();
    }

    // Spawn the life icons.
    void SpawnLives()
    {
        for (int i = 0; i < remainingLives; i++)
        {
            // Instantiate the life icon prefab at the spawn point.
            GameObject lifeIcon = Instantiate(livesPrefab, spawnPoint.position, Quaternion.identity);
            lifeIcon.transform.SetParent(transform); // Make the canvas the parent of the life icon.
            // Adjust the position of each life icon to avoid overlap.
            lifeIcon.transform.localPosition += new Vector3(i * 0.7f, 0, 0);
        }
    }

    // Remove a life icon when a life is lost.
    public void LoseLife()
    {
        if (remainingLives > 0)
        {
            remainingLives--;
            // Find the last spawned life icon and destroy it.
            Destroy(transform.GetChild(transform.childCount - 1).gameObject);
        }
    }
}
