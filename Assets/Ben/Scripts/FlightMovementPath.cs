using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightMovementPath : MonoBehaviour
{
    public float flightSpeed;
    void Update()
    {
        gameObject.transform.Translate(Vector3.left * flightSpeed * Time.deltaTime);
    }
}
