using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRRigMovement : MonoBehaviour
{
    public Vector3 currentPosition;
    public Vector3 lastPosition;

    public bool isRigMoving;

    #region Monobehaviour Methods
    void Start()
    {
        isRigMoving = false;
        currentPosition = gameObject.transform.position; // Collecting the current position
        lastPosition = transform.position;
    }

  
    void Update()
    {
        CheckingMovementOfXRRig();
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Method to check whether the XR_Rig (Player) is moving and updating a bool accordingliy
    /// </summary>
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

    #endregion
}
