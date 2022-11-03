using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightMovement : MonoBehaviour
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
        InvokeRepeating("FlightFlyingPath", 2f, 40f);
    }

    void Update()
    {
        
    }

    void FlightFlyingPath()
    {
        
        Instantiate(fightPrefab, new Vector3(xUpperLimit, Random.Range(yUpperLimit, yLowerLimit), Random.Range(zUpperLimit, zLowerLimit)), Quaternion.Euler(-90f, 0f, 0f));
        
    }


}
