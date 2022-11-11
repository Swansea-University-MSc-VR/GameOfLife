using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManikinHealth : MonoBehaviour
{
    public Slider manikinhealthSliderBar; // manikin slider gameobject variable
    public float manikinTotalHealthLeft; // manikin total health left variable

    private float _manikinTotalHealth; // manikin total health variable

    #region Monobehaviour Methods
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
            // slider value changes with manikin health left
            manikinhealthSliderBar.value = manikinTotalHealthLeft - 1f * Time.deltaTime;
            
        }
    }

    void Update()
    {
        // updating total health left
        manikinTotalHealthLeft = manikinhealthSliderBar.value;
        
    }
    #endregion
}
