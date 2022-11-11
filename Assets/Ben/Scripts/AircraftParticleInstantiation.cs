using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftParticleInstantiation : MonoBehaviour
{
    public ParticleSystem aircraftParticleSystem; // particle system attached to aircraft
    public AudioSource flightEngineAudioSource; // audio source attached to aircraft

    #region Monobehaviour Methods
    void Start()
    {
        //stoping particle system initially incase it is playing
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
            // start the particle playing
            StartCoroutine(StartParticleEffect());

            // start increasing the volume of audio source playing the aricraft engine audio clip
            StartCoroutine(IncreaseVolumeCoroutine());
        }

        else if (collision.gameObject.tag == "ForestAreaExit")
        {
            // stop particle system
            aircraftParticleSystem.Stop();

            // start decreasing the volume of audio source playing the aricraft engine audio clip
            StartCoroutine(DecreaseVolumeCoroutine());

        }
        else if (collision.gameObject.tag == "FlightDestroyer")
        {
            // Destroying the game object after a small delay once it collide with gameobject with tag FlightDestroyer
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
