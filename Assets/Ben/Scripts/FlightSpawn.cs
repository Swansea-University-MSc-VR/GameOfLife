using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightSpawn : MonoBehaviour
{
    public float xUpperLimit;
    public float xLowerLimit;
    public float yUpperLimit;
    public float yLowerLimit;
    public float zUpperLimit;
    public float zLowerLimit;

    public GameObject fightPrefab;

    private void Start()
    {
        //Invoking the FlightFlyingPath method at regular intervals, 40 sec, with a delay of 2 sec initially
        InvokeRepeating("FlightFlyingPath", 2f, 40f);
    }

    /// <summary>
    /// Instantiating the prefab for Flight within a certain range along y axis and z axis and with a rotation along x axis  
    /// </summary>
    void FlightFlyingPath()
    {
        Instantiate(fightPrefab, new Vector3(xUpperLimit, Random.Range(yUpperLimit, yLowerLimit), Random.Range(zUpperLimit, zLowerLimit)), Quaternion.Euler(-90f, 0f, 0f));
    }


}
