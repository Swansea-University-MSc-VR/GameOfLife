using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightSpawn : MonoBehaviour
{
    public float xUpperLimit; // maximum value in x axis
   
    public float yUpperLimit; // maximum value in y axis
    public float yLowerLimit; // minimum value in y axis

    public float zUpperLimit; // maximum value in z axis
    public float zLowerLimit; // minimum value in z axis

    public GameObject fightPrefab;

    #region Monobehaviour Methods
    private void Start()
    {
        //Invoking the FlightFlyingPath method at regular intervals, 40 sec, with a delay of 2 sec initially
        InvokeRepeating("FlightFlyingPath", 2f, 40f);
    }

    #endregion

    #region Private Method
    /// <summary>
    /// Instantiating the prefab for Flight within a certain range along y axis and z axis and with a rotation along x axis  
    /// </summary>
    void FlightFlyingPath()
    {
        Instantiate(fightPrefab, new Vector3(xUpperLimit, Random.Range(yUpperLimit, yLowerLimit), Random.Range(zUpperLimit, zLowerLimit)), Quaternion.Euler(-90f, 0f, 0f));
    }

    #endregion
}
