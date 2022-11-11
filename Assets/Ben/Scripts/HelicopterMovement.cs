using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    public float helicopterSpeed; // helicopter movement speed
    public GameObject helipadArea; // helipad area
    public GameObject[] heliTargets; // helicopter target points

    public XRRigMovement xRRigMovementForHelicopter; // XR Rigmovement script

    [SerializeField]
    private bool reachedTopArea;
    [SerializeField]
    private bool helicopterLanded;
    [SerializeField]
    private bool helicopterTakeOff;

    public GameObject stepToClimb; // game object attached to helicopter as steps


    #region Monobehaviour Methods
    // Start is called before the first frame update
    void Start()
    {
        reachedTopArea = false;
        xRRigMovementForHelicopter = GameObject.FindGameObjectWithTag("XRrig").GetComponent<XRRigMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // checking the bool for helicopter, whether it is ready for takeoff or not
        helicopterTakeOff = xRRigMovementForHelicopter.isAllSaved;

        // start helicopter movement
        HelicopterFlyMovement();
    }

    /// <summary>
    /// When the Helicopter enters Helipad collider the clibing path gameobject become active and bool variable become true.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "HeliPad")
        {
            helicopterLanded = true;
            Debug.Log("Heli is good");
            stepToClimb.SetActive(true);
        } 
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {

            StartCoroutine(WaitForLanding());
        }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Enumerator to check the helicopter position
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitForLanding()
    {
        yield return new WaitForSeconds(3.5f);
        reachedTopArea = true;
        Debug.Log("Heli is good");
    }

    /// <summary>
    /// Methods to control the helicopter movement
    /// </summary>
    void HelicopterFlyMovement()
    {
        //transform.LookAt(helipadArea.transform);
        if(transform.position != helipadArea.transform.position && !reachedTopArea && !helicopterLanded && !helicopterTakeOff)
        {
            foreach (GameObject target in heliTargets)
            {
                // looking at target, helipadarea
                transform.LookAt(target.transform);
                // moving helicopter towards target
                gameObject.transform.Translate(Vector3.forward * helicopterSpeed * Time.deltaTime);
                
            }         
        }

        if (reachedTopArea && !helicopterLanded && !helicopterTakeOff)
        {
            // helicopter moving down y-axis
            gameObject.transform.Translate(Vector3.down * Time.deltaTime);
        }
        else if(reachedTopArea && helicopterLanded && !helicopterTakeOff)
        {
            Debug.Log("Helicopter is safely landed");
        }
        else if(reachedTopArea && helicopterLanded && helicopterTakeOff)
        {
            // activate a gameobject
            stepToClimb.SetActive(false);
            // start FinalTakeOff method after a delay
            Invoke("FinalTakeOff", 3f);
        }
        
    }

    /// <summary>
    /// Method to take-off the helicopter.
    /// </summary>
    void FinalTakeOff()
    {
        
        if (gameObject.transform.position.y < 11)
        {
            // moving gameobject up, along y-axis
            gameObject.transform.Translate(Vector3.up * Time.deltaTime);
        }
        if (gameObject.transform.position.x > -10)
        {
            //moving gameobject towards left, x-axis
            gameObject.transform.Translate(Vector3.left * Time.deltaTime);
        }

        // moving gameobject forward along x-axis
        gameObject.transform.Translate(Vector3.forward * helicopterSpeed * Time.deltaTime);
    }

    #endregion
}
