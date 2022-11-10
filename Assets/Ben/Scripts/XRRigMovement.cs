using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRRigMovement : MonoBehaviour
{
    public Vector3 currentPosition;
    public Vector3 lastPosition;

    public bool isRigMoving;

    public bool isAllSaved;

    public GameObject playerHelicopterPosition;

    #region Monobehaviour Methods
    void Start()
    {
        isRigMoving = false;
        currentPosition = gameObject.transform.position; // Collecting the current position information
        lastPosition = transform.position;
        playerHelicopterPosition = GameObject.FindGameObjectWithTag("PlayerPosition");
        
    }

    void Update()
    {
        CheckingMovementOfXRRig();
        Debug.DrawRay(transform.position, transform.forward, Color.blue, 15f);
    }

    /// <summary>
    /// If the XR Rig enters HelicopterSaveArea then then the playerHelicopterPosition game object will be the parent
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "HelicopterSaveArea")
        {
            transform.parent = playerHelicopterPosition.transform;
        }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Method to check whether the XR_Rig (Player) is moving and updating a bool accordingliy.
    /// </summary>
    void CheckingMovementOfXRRig()
    {
        currentPosition = gameObject.transform.position;
        UpdatingLastPosition();
    }

    /// <summary>
    /// Function to update the last position of the XR Rig.
    /// </summary>
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

    /// <summary>
    /// Function for checking all manikin entered helicopter
    /// </summary>
    public void IsAllManikinSaved()
    {
        isAllSaved = true;

        if (isAllSaved)
        {
            XRrigHelicopterPosition();
        }
    }

    /// <summary>
    /// Method for repositioning XR Rig position to playerHelicopterPosition
    /// </summary>
    public void XRrigHelicopterPosition()
    {
        //Spawning the XR Rig in the same position as the playerHelicopterPosition's position
        gameObject.transform.position = new Vector3(playerHelicopterPosition.transform.position.x, playerHelicopterPosition.transform.position.y, playerHelicopterPosition.transform.position.z);
        
        //Spawning the XR Rig with a 90 degree rotation along 'y' axis
        gameObject.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
    }

    #endregion

}
