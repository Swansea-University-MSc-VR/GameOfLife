using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    public float helicopterSpeed;
    public GameObject helipadArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HelicopterFlyMovement();
    }

    void HelicopterFlyMovement()
    {
        transform.LookAt(helipadArea.transform);
        if(transform.position != helipadArea.transform.position)
        {
            gameObject.transform.Translate(Vector3.forward * helicopterSpeed * Time.deltaTime);

        }
        else
        {
            Debug.Log("Helicopter Reached");
        }
    }
}
