using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManikinController : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;

    public XRRigMovement xRRigMovement;

    public bool isGathered;

    [SerializeField]
    private float _speed;
    public float targetDistance;
    public float allowedDistance;
    private float _distanceToXRrig;

    public RaycastHit Shot;

    [SerializeField]
    private Animator avatarAnimator;

    [SerializeField]
    private ManikinHealth _manikinHealth;

    public LayerMask obstacleLayer;

    public GameObject seatPosition;
    public bool enteredSafeArea;

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
        FollowXRrig();

        if(isGathered == true)
        {

            FollowThePlayer();

            ManikinDeathAnimationTransition();
        }
        
        if(enteredSafeArea == true)
        {
            UnitMethod();
        }

            
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HelicopterSaveArea")
        {
            enteredSafeArea = true;
        }
    }

    #endregion

    #region Private Methods
    void FollowXRrig()
    {
        //Calculating distance between the object to follow and gameobject attached with this script
        _distanceToXRrig = Vector3.Distance(objectToFollow.position, transform.position);

        if (_distanceToXRrig < 6)
        {

            //transform.LookAt(objectToFollow);
            isGathered = true;
        }

        //if(_distanceToXRrig <= 4.5f && isGathered == true)
        //{
        //    //gameObject.transform.position = objectToFollow.position + offset;
        //    //transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position + offset, _speed * Time.deltaTime);
        //    //transform.forward = objectToFollow.transform.position - transform.position;
        //}
    }


    void ManikinDeathAnimationTransition()
    {
        if (_manikinHealth.manikinTotalHealthLeft == 0f)
        {
            avatarAnimator.Play("DeathRight");
            Debug.Log(_manikinHealth.manikinTotalHealthLeft);
        }
    }

    void ManikinIdleRunAnimationTransition()
    {
        if (xRRigMovement.isRigMoving == true && _manikinHealth.manikinTotalHealthLeft != 0f)
        {
            avatarAnimator.Play("Walking");
        }
        else if (xRRigMovement.isRigMoving == false && _manikinHealth.manikinTotalHealthLeft != 0f)
        {

            avatarAnimator.Play("Idle");
        }
    }

    /// <summary>
    /// Method for the Manikin to follow the XR_Rig (Player) using Raycast and calculating distance between Player and Manikin.
    /// Also appropriate character animation will be player.
    /// </summary>
    void FollowThePlayer()
    {
        _distanceToXRrig = Vector3.Distance(objectToFollow.position, transform.position);

        transform.LookAt(objectToFollow);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot) && isGathered == true)
        {
            // Checking whether the raycast hit properly to thr target object, i.e Player.
            Debug.DrawRay(transform.position, transform.forward, Color.blue, 15f);


            targetDistance = Shot.distance;
            if (targetDistance >= allowedDistance)
            {
                _speed = 0.01f;
                avatarAnimator.Play("Walking");
                transform.position = Vector3.MoveTowards(transform.position, objectToFollow.transform.position, _speed);
            }
            else
            {
                _speed = 0f;
                avatarAnimator.Play("Idle");
            }
        }
    }

    public void UnitMethod()
    {
        // Checking whether the raycast hit properly to thr target object, i.e Player.
        Debug.DrawRay(transform.position, transform.forward, Color.blue, 20f);

        if (transform.position != seatPosition.transform.position && enteredSafeArea == true)
        {
            isGathered = false;
            transform.LookAt(seatPosition.transform);
            transform.position = Vector3.MoveTowards(transform.position, seatPosition.transform.position, _speed);
            avatarAnimator.Play("Walking");

        }

        if (transform.position == seatPosition.transform.position)
        {
            transform.rotation = Quaternion.Euler(0f, 5f, 0f);
            avatarAnimator.Play("StandToSit");
            transform.parent = seatPosition.transform;
        }
      
    }

    #endregion
}

