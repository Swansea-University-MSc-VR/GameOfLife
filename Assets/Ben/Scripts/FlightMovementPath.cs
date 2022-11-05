using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightMovementPath : MonoBehaviour
{
    public float flightSpeed;

    void Update()
    {
        //Translating the gameobject attached with this script, along X axis
        gameObject.transform.Translate(Vector3.left * flightSpeed * Time.deltaTime);
    }
}
