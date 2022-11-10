using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExtinguisherAtSpawnPoints : MonoBehaviour
{
    public GameObject[] extinguisherSpawnPoints;

    public GameObject extinguisherPrefab;

    // Start is called before the first frame update
    void Start()
    {
        ExtinguishSpawn();
    }



    void RandomizingSpawnPoints()
    {
        int x = Random.Range(-100, 100);
        
        int z = Random.Range(10, 100);

    }

    // Spawning fire extinguisher in the array of positions 
    void ExtinguishSpawn()
    {
        foreach(GameObject pos in extinguisherSpawnPoints)
        {
            Instantiate(extinguisherPrefab, pos.transform.position, Quaternion.identity);
        }
    }
}
