using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftParticleInstantiation : MonoBehaviour
{
    public ParticleSystem aircraftParticleSystem;
    public AudioSource flightEngineAudioSource;

    #region Monobehaviour Methods
    void Start()
    {
        aircraftParticleSystem.Stop();
    }

    /// <summary>
    /// While aircraft collide with different gameobjects with different tags
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ForestAreaEntry")
        {
            
            //aircraftParticleSystem.Play();
            StartCoroutine(StartParticleEffect());
            StartCoroutine(IncreaseVolumeCoroutine());
        }

        else if (collision.gameObject.tag == "ForestAreaExit")
        {
            aircraftParticleSystem.Stop();
            StartCoroutine(DecreaseVolumeCoroutine());

        }
        else if (collision.gameObject.tag == "FlightDestroyer")
        {
            Destroy(gameObject, 0.1f);
        }
    }

    #endregion

    #region IEnumerators
    
    // Particle start playing 
    IEnumerator StartParticleEffect()
    {
        yield return new WaitForSeconds(0.2f);
        aircraftParticleSystem.Play();
    }
    
    // Aircraft engine volume decrease
    IEnumerator DecreaseVolumeCoroutine()
    {
        while (flightEngineAudioSource.volume > 0f)
        {
            flightEngineAudioSource.volume -= 0.001f;
            yield return null;
        }
    }

    // Aircraft engine volume increases
    IEnumerator IncreaseVolumeCoroutine()
    {
        while (flightEngineAudioSource.volume < 1f)
        {
            flightEngineAudioSource.volume += 0.005f;
            yield return null;
        }
    }

    #endregion
}
