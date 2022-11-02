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




    void Update()
    {
        
    }

    void FlightFlyingPath()
    {
        gameObject.transform.Translate(new Vector3(Random.Range(xUpperLimit, xLowerLimit), Random.Range(yUpperLimit,yLowerLimit),Random.Range(zUpperLimit,zLowerLimit)));
    }
}
