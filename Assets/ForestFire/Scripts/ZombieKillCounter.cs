using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieKillCounter : MonoBehaviour
{
    public int zombiesKilled = 0;           // Count of zombies killed
   
    public TMP_Text killCountText;          // Text UI element to show kills

    // This function updates the UI whenever a zombie is killed
    public void ZombieKilled()
    {
        zombiesKilled += 1;                 // Add 1 to the kill count
        killCountText.text = "Zombies Killed: " + zombiesKilled;  // Update the UI text
        Debug.Log("Zombies killed: " + zombiesKilled);            // Log the kill count

        
    }
}


