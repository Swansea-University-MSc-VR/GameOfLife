using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleInitialization : MonoBehaviour
{
    public ParticleSystem extinguisherParticlesSystem;
    public GameObject leftHand;

    #region Monobehaviour Methods
    void Start()
    {
        leftHand = GameObject.FindGameObjectWithTag("LeftHand"); // Finding the LeftHand component
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "LeftHand")
        {
            extinguisherParticlesSystem.Play();
            //Debug.Log(extinguisherParticlesSystem.isPlaying);
        }
        else
        {
            extinguisherParticlesSystem.Stop();
            //Debug.Log(extinguisherParticlesSystem.isPlaying);
        }
    }

    ///// <summary>
    ///// Collision detection of LeftHand for particle to play while entering and to stop while exiting
    ///// </summary>
    ///// <param name="collision"></param>
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "LeftHand")
    //    {
    //        extinguisherParticlesSystem.Play();
    //        Debug.Log(extinguisherParticlesSystem.isPlaying);
    //    }
    //    else
    //    {
    //        extinguisherParticlesSystem.Stop();
    //    }

    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "LeftHand")
    //    {
    //        extinguisherParticlesSystem.Stop();
    //        Debug.Log(extinguisherParticlesSystem.isPlaying);
    //    }

    //}
    #endregion
}
