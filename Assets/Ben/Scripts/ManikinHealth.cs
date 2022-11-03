using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManikinHealth : MonoBehaviour
{
    public Slider manikinhealthSliderBar;
    public float manikinTotalHealthLeft;

    private float _manikinTotalHealth;

    void Start()
    {
        _manikinTotalHealth = 100f;
        manikinTotalHealthLeft = _manikinTotalHealth;
    }

    /// <summary>
    /// When the fire hits the player then the player health will reduce and the health indicator bar will shows the health status
    /// </summary>
    /// <param name="fire"></param>
    void OnCollisionStay(Collision fire)
    {

        if (fire.gameObject.tag == "Fire")
        {

            manikinhealthSliderBar.value = manikinTotalHealthLeft - 1f * Time.deltaTime;
            Debug.Log("Health is reducing");
        }

    }
    void Update()
    {
        manikinTotalHealthLeft = manikinhealthSliderBar.value;
        
    }
}
