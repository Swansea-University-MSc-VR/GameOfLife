using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSliderBar; // slider gameobject for player health

    private float _totalHealth;
    private float _totalHealthLeft;

    #region Monobehaviour
    void Start()
    {
        _totalHealth = 100f;
        _totalHealthLeft = _totalHealth;
    }

    /// <summary>
    /// When the fire hits the player then the player health will reduce and the health indicator bar will shows the health status
    /// </summary>
    /// <param name="fire"></param>
    void OnCollisionStay(Collision fire)
    {

        if (fire.gameObject.tag == "Fire")
        {
            
            healthSliderBar.value = _totalHealthLeft - 1f * Time.deltaTime;
            
        }

    }

    void Update()
    {
        // total health left for player
        _totalHealthLeft = healthSliderBar.value;
    }
    #endregion
}
