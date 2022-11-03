using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRRigMovement : MonoBehaviour
{
    public Vector3 currentPosition;
    public Vector3 lastPosition;

    public bool isRigMoving;

    void Start()
    {
        isRigMoving = false;
        currentPosition = gameObject.transform.position; // Collecting the current position
        lastPosition = transform.position;
        Debug.Log(currentPosition);
    }

    // Update is called once per frame
    void Update()
    {
        CheckingMovementOfXRRig();
    }

    void CheckingMovementOfXRRig()
    {
        currentPosition = gameObject.transform.position;
        UpdatingLastPosition();
    }

    void UpdatingLastPosition()
    {
        if (currentPosition == lastPosition)
        {
            isRigMoving = false;
            //lastPosition = currentPosition;
            Debug.Log("Rig moving: " + isRigMoving);

        }
        else if (currentPosition != lastPosition)
        {
            isRigMoving = true;
            Debug.Log("Rig moving: " + isRigMoving);
            lastPosition = transform.position;
        }
    }
}
