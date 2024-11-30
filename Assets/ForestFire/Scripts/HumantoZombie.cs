using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HumanToZombie : MonoBehaviour

{
    public GameObject zombiePrefab; // Reference to the zombie prefab

    void OnTriggerEnter(Collider other)
    {
        // Replace with zombie if the tag is "Serum"
        if (other.CompareTag("Zombie"))
        {
            // Instantiate the zombie at the same position and rotation as the human
            GameObject zombie = Instantiate(zombiePrefab, transform.position, transform.rotation);

            // Destroy the human object
            Destroy(gameObject);
        }
    }
}








