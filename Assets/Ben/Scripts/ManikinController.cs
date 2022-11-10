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

    //public LayerMask obstacleLayer;

    public GameObject seatPosition;
    public bool enteredSafeArea;
    public AudioSource walkingAudioClip;

    #region Monobehaviour Methods
    void Start()
    {
        objectToFollow = GameObject.FindGameObjectWithTag("XRrig").GetComponent<Transform>();
        //objectToFollow = GameObject.FindGameObjectWithTag("GameController").GetComponent<Transform>();
        xRRigMovement = GameObject.FindGameObjectWithTag("XRrig").GetComponent<XRRigMovement>();
        avatarAnimator = gameObject.GetComponent<Animator>();
        isGathered = false;
    }

    void Update()
    {
        CheckingGatheredOrNot();

        // Checking whether the player gathered all the NPC and they have not entered the helicopter area
        if(isGathered == true && !enteredSafeArea)
        {
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
            avatarAnimator.Play("DeathRight");
            Debug.Log(_manikinHealth.manikinTotalHealthLeft);
        }
    }

    /// <summary>
    /// Method for the Manikin to follow the XR_Rig (Player) using Raycast and calculating distance between Player and Manikin.
    /// Also appropriate character animation will be player.
    /// </summary>
    void FollowThePlayer()
    {
        _distanceToXRrig = Vector3.Distance(objectToFollow.position, transform.position);
        //Debug.Log(_distanceToXRrig);
        transform.LookAt(objectToFollow);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot) && isGathered == true && enteredSafeArea == false)
        {
            // Checking whether the raycast hit properly to thr target object, i.e Player.
            Debug.DrawRay(transform.position, transform.forward, Color.blue, 15f);


            targetDistance = Shot.distance;
            Debug.Log(targetDistance);
            if (targetDistance >= allowedDistance)
            {
                _speed = 0.02f;
                avatarAnimator.Play("Walking");
                transform.position = Vector3.MoveTowards(transform.position, objectToFollow.transform.position, _speed);
                //isWalkingTo = true;
                //PlayWakingAudio();
            }
            else
            {
                _speed = 0f;
                avatarAnimator.Play("Idle");
                //walkingAudioClip.Stop();
                isWalkingTo = false;
            }
        }
    }

    public bool isWalkingTo;
    void PlayWakingAudio()
    {
        if (isWalkingTo)
        {
            walkingAudioClip.Play();
        }
        else
        {
            walkingAudioClip.Stop();
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

