using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;    // Reference to the zombie prefab
    public GameObject humanPrefab;     // Reference to the human prefab
      
    public GameObject femalePrefab;    // Reference to the female prefab
    public int gridRows = 10;          // Number of rows in the grid
    public int gridColumns = 10;       // Number of columns in the grid
    public float cellSize = 2f;        // Distance between each grid cell
    public int zombieCount = 20;       // Number of zombies to spawn
    public int humanCount = 20;        // Number of humans to spawn
    public int femaleCount = 20;



    void Start()
    {
        // Spawn zombies and humans on grid
        SpawnZombiesAndHumans();
    }

    void SpawnZombiesAndHumans()
    {
        // Spawn zombies
        for (int i = 0; i < zombieCount; i++)
        {
            // Pick a random position in the grid
            int row = Random.Range(0, gridRows);
            int column = Random.Range(0, gridColumns);

            // Calculate the position based on the grid coordinates
            Vector3 position = new Vector3(row * cellSize, 0, column * cellSize);

            // Instantiate a zombie at the calculated position
            Instantiate(zombiePrefab, position, Quaternion.identity);
        }

        // Spawn humans
        for (int i = 0; i < humanCount; i++)
        {
            // Pick a random position in the grid
            int row = Random.Range(0, gridRows);
            int column = Random.Range(0, gridColumns);

            // Calculate the position based on the grid coordinates
            Vector3 position = new Vector3(row * cellSize, 0, column * cellSize);

            // Instantiate a human at the calculated position
            Instantiate(humanPrefab, position, Quaternion.identity);
        }
    }
}
