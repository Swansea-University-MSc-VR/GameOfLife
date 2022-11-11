using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManikinController : MonoBehaviour
{
    public Transform objectToFollow; // object to follow by manikin

    public XRRigMovement xRRigMovement; // XR rigmovement script

    public bool isGathered; // bool to check whether manikin found XR Rig

    [SerializeField]
    private float _speed; // speed of walk
    public float targetDistance; // distance between XR Rig and manikin
    public float allowedDistance; // distance allowed between Manikin and XR Rig
    private float _distanceToXRrig; // current distance between XRRig and player

    public RaycastHit Shot;

    [SerializeField]
    private Animator avatarAnimator; // manikin animator

    [SerializeField]
    private ManikinHealth _manikinHealth; // manikin health script

    //public LayerMask obstacleLayer;

    public GameObject seatPosition; // position for manikin to sit
    public bool enteredSafeArea; // bool for entering helicopter area
    

    #region Monobehaviour Methods
    void Start()
    {
        objectToFollow = GameObject.FindGameObjectWithTag("XRrig").GetComponent<Transform>();
        
        xRRigMovement = GameObject.FindGameObjectWithTag("XRrig").GetComponent<XRRigMovement>();
        avatarAnimator = gameObject.GetComponent<Animator>();
        isGathered = false;
    }

    void Update()
    {
        // method to check whether the manikin is found by player
        CheckingGatheredOrNot();

        // Checking whether the player gathered all the NPC and they have not entered the helicopter area
        if(isGathered == true && !enteredSafeArea)
        {
            // method for following the XR Rig(player) 
            FollowThePlayer();

            ManikinDeathAnimationTransition();
        }
        
        // Checking NPC's entering helicopter area
        if(enteredSafeArea)
        {
            EnetredHelicopterArea();
        }   
    }

    /// <summary>
    /// Checking a bool whether the manikin has entered the 'HelicopterSaveArea'
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HelicopterSaveArea")
        {
            enteredSafeArea = true;
        }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Bool to check whether the manikins are gathered by player
    /// </summary>
    void CheckingGatheredOrNot()
    {
        //Calculating distance between the object to follow and gameobject attached with this script
        _distanceToXRrig = Vector3.Distance(objectToFollow.position, transform.position);

        if (_distanceToXRrig < 6)
        {
            isGathered = true;
        }
    }

    /// <summary>
    /// Once the health reaches the zero a death animation will play
    /// </summary>
    void ManikinDeathAnimationTransition()
    {
        if (_manikinHealth.manikinTotalHealthLeft == 0f)
        {
            // playing animation DeathRight
            avatarAnimator.Play("DeathRight");
            
        }
    }

    /// <summary>
    /// Method for the Manikin to follow the XR_Rig (Player) using Raycast and calculating distance between Player and Manikin.
    /// Also appropriate character animation will be player.
    /// </summary>
    void FollowThePlayer()
    {
        _distanceToXRrig = Vector3.Distance(objectToFollow.position, transform.position);
        
        // looking at XR Rig (player)
        transform.LookAt(objectToFollow);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot) && isGathered == true && enteredSafeArea == false)
        {
            // Checking whether the raycast hit properly to thr target object, i.e Player.
            Debug.DrawRay(transform.position, transform.forward, Color.blue, 15f);

            // target distance is equal to the ray hit distance
            targetDistance = Shot.distance;
            
            if (targetDistance >= allowedDistance)
            {
                //speed of walk
                _speed = 0.02f;
                avatarAnimator.Play("Walking");  // playing animation Walking
                // moving manikin towards player
                transform.position = Vector3.MoveTowards(transform.position, objectToFollow.transform.position, _speed);
                
            }
            else
            {
                _speed = 0f;
                avatarAnimator.Play("Idle");   // playing idle animation
                
            }
        }
    }



    /// <summary>
    /// While entering the helicopter area the manikins will walk towards the their seat 
    /// </summary>
    public void EnetredHelicopterArea()
    {
        // Checking whether the raycast hit properly to thr target object, i.e Player.
        Debug.DrawRay(transform.position, transform.forward, Color.blue, 20f);

        if (transform.position != seatPosition.transform.position && enteredSafeArea == true)
        {
            _speed = 0.01f;

            isGathered = false;
            transform.LookAt(seatPosition.transform);
            // entering helicopter 
            transform.position = Vector3.MoveTowards(transform.position, seatPosition.transform.position, _speed);
            avatarAnimator.Play("Walking"); // playing walking animation

        }

        if (transform.position == seatPosition.transform.position)
        {
            // rotating manikin at seat position
            transform.rotation = Quaternion.Euler(0f, 5f, 0f);
            avatarAnimator.Play("StandToSit"); // playing sit animation
            //making manikin as a child of seatposition
            transform.parent = seatPosition.transform;
        }


    }

    #endregion
}

