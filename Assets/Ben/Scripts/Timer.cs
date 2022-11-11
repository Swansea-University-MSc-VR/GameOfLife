using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public Slider timeLeftSlider;   //Slider for remaining time
    public TextMeshProUGUI timeLeftDigital; // textmeshpro to show the time left
    public float timeLeft;

    [SerializeField]
    private float _totalTime;

    #region Private Methods
    /// <summary>
    /// Reduce the slider fill value according to the time taken.
    /// </summary>
    void TimerFill()
    {
        if(timeLeftSlider != null && timeLeftSlider.value >= 0)
        {
            timeLeftSlider.value = timeLeft;
        }
        else
        {
            timeLeftDigital.text = "LEAVE"; // display text on textmeshpro
        }
    }
    #endregion

    #region Monobehaviour Methods
    void Update()
    {

        timeLeftDigital.text = Mathf.FloorToInt(timeLeft).ToString() + " sec";
        timeLeft = _totalTime - Time.time;  // Time Calculation
        TimerFill();
    }

    #endregion
}
