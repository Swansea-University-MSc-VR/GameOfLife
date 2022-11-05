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
      
        FollowThePlayer();

        ManikinDeathAnimationTransition();
    }

    #endregion

    #region Private Methods
    void FollowXRrig()
    {
        _distanceToXRrig = Vector3.Distance(objectToFollow.position, transform.position);

        if(_distanceToXRrig < 6)
        {
            
            //transform.LookAt(objectToFollow);
            isGathered = true;
        }

        if(_distanceToXRrig <= 4.5f && isGathered == true)
        {
            //gameObject.transform.position = objectToFollow.position + offset;
            //transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position + offset, _speed * Time.deltaTime);
            //transform.forward = objectToFollow.transform.position - transform.position;
        }
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
            if(targetDistance >= allowedDistance)
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

    #endregion
}

