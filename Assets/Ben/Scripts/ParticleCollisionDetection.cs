using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ParticleCollisionDetection : MonoBehaviour
{
    //public GameObject[] fireGO;

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
            Debug.Log("If " + other.tag + " GO False");
        }
        else if (other.tag == "AerialFirefighter")
        {
            StartCoroutine(AerialExtinguish());
            Debug.Log("If " + other.tag + " GO False");
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








    //void findingFireGameObject()
    //{

    //    //get all the objects with the tag "myTag"
    //    fireGO = GameObject.FindGameObjectsWithTag("Fire");
    //    //loop through the returned array of game objects and set each to active false
    //    foreach (GameObject item in fireGO)
    //    {
    //        //item.SetActive(false);
    //    } 
    //}

}
