using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class FireCollision : MonoBehaviour
{
    public ZombieKillCounter killCounter; // Reference to the kill counter script

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))   // If we collide with a zombie
        {
            Destroy(other.gameObject);    // Destroy the zombie
            killCounter.ZombieKilled();   // Add to the kill count
        }
    }
}

