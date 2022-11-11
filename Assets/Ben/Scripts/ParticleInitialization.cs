using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleInitialization : MonoBehaviour
{
    public ParticleSystem extinguisherParticlesSystem; // particle system attached to extinguisher
    public GameObject leftHand; // left hand gameobject of XR Rig
    public AudioSource fireExtinguisherClip; // audio source of fire extinguisher 

    #region Monobehaviour Methods
    void Start()
    {
        leftHand = GameObject.FindGameObjectWithTag("LeftHand"); // Finding the LeftHand component
    }

    /// <summary>
    /// If gameobject with tag enters this objects collider area particle and sound will play.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LeftHand")
        {
            extinguisherParticlesSystem.Play();
            fireExtinguisherClip.Play();
        }
    }

    /// <summary>
    /// If gameobject with tag exits this objects collider area particle and sound will stop.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LeftHand")
        {
            extinguisherParticlesSystem.Stop();
            fireExtinguisherClip.Stop();
        }
        
    }

    #endregion
}
