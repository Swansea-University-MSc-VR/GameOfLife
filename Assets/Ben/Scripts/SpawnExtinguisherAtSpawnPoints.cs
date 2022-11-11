using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExtinguisherAtSpawnPoints : MonoBehaviour
{
    public GameObject[] extinguisherSpawnPoints; // spawn points for extinguisher to spawn

    public GameObject extinguisherPrefab; // extinguisher prefab


    #region Monobehaviour Methods
    // Start is called before the first frame update
    void Start()
    {
        // spawning extinguisher 
        ExtinguishSpawn();
    }

    #endregion

    #region Private Methods

    // Spawning fire extinguisher in the array of positions 
    void ExtinguishSpawn()
    {
        foreach(GameObject pos in extinguisherSpawnPoints)
        {
            // instantiatin extinguisher prefab
            Instantiate(extinguisherPrefab, pos.transform.position, Quaternion.identity);
        }
    }

    #endregion
}
