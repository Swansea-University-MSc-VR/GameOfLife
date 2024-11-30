using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRotation : MonoBehaviour
{
    private Transform player;  // Reference to the player's transform

    void Start()
    {
        // Find the player by tag in the scene
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            // Find the direction to the player
            Vector3 direction = player.position - transform.position;

            // Remove any vertical component to keep the rotation horizontal
            direction.y = 0;

            // Calculate the rotation needed to face the player
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Apply the rotation smoothly (you can adjust the speed)
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
}
