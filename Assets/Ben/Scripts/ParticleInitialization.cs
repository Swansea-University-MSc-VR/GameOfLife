using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleInitialization : MonoBehaviour
{
    public ParticleSystem extinguisherParticlesSystem;
    public GameObject leftHand;

    void Start()
    {
        leftHand = GameObject.FindGameObjectWithTag("LeftHand");
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "LeftHand")
        {
            extinguisherParticlesSystem.Play(true);
            Debug.Log(extinguisherParticlesSystem.isPlaying);
        }
        else
        {
            extinguisherParticlesSystem.Stop(true);
        }
    }

    void Update()
    {
        
    }
}
