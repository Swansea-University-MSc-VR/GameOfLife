using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineRotation : MonoBehaviour
{
    public int speed; // speed of gameobject attached with this gameobject

   
    void Update()
    {
        // Rotating the gameobject attached with this script along z axis
        gameObject.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
