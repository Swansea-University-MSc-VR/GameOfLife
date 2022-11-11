using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ParticleCollisionDetection : MonoBehaviour
{
    

    /// <summary>
    /// Attach this script to the componrent that need to be disabled while particle hits
    /// </summary>
    /// <param name="other"></param>
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle Collided with " + other.tag);

        if(other.tag == "Extinguisher")
        {
            StartCoroutine(Extinguish());
            
        }
        else if (other.tag == "AerialFirefighter")
        {
            StartCoroutine(AerialExtinguish());
            
        }
    }

    /// <summary>
    /// Coroutine for Wait for few sec to disable the game object
    /// </summary>
    IEnumerator Extinguish()
    {
        yield return new WaitForSecondsRealtime(7f);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// IEnumerator for the Aerial fire extinguisher
    /// </summary>
    /// <returns></returns>
    IEnumerator AerialExtinguish()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        gameObject.SetActive(false);
    }



}
