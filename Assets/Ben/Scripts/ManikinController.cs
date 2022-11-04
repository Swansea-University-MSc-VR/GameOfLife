using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManikinController : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;

    public XRRigMovement xRRigMovement;
    private float _distanceToXRrig;

    public bool isGathered;

    [SerializeField]
    private float _speed;
    public RaycastHit Shot;
    public float targetDistance;
    public float allowedDistance;
    //-------------------------------------------------------
    [SerializeField]
    private Animator avatarAnimator;

    [SerializeField]
    private ManikinHealth _manikinHealth;
    


    void Start()
    {
        objectToFollow = GameObject.FindGameObjectWithTag("XRrig").GetComponent<Transform>();
        xRRigMovement = GameObject.FindGameObjectWithTag("XRrig").GetComponent<XRRigMovement>();
        avatarAnimator = gameObject.GetComponent<Animator>();

        isGathered = false;
    }

    void Update()
    {
        //FollowXRrig();
        ////FollowSmoothly();

        //ManikinDeathAnimationTransition();

        //ManikinIdleRunAnimationTransition();
        FollowThePlayer();
    }


    void FollowXRrig()
    {
        _distanceToXRrig = Vector3.Distance(objectToFollow.position, transform.position);

        if(_distanceToXRrig < 5)
        {
            
            transform.LookAt(objectToFollow);
            isGathered = true;
        }

        if(_distanceToXRrig <= 4.5f && isGathered == true)
        {
            //gameObject.transform.position = objectToFollow.position + offset;
            transform.position = Vector3.MoveTowards(transform.position, objectToFollow.position + offset, _speed * Time.deltaTime);
            transform.forward = objectToFollow.transform.position - transform.position;
            

        }
    }

 
    //void FollowSmoothly()
    //{
    //    float distanceToXRrig = Vector3.Distance(objectToFollow.position, transform.position);

    //    if (distanceToXRrig < 3)
    //    {
    //        transform.LookAt(objectToFollow);
    //    }

    //    if (distanceToXRrig < 1.5)
    //    {
    //        float interpolation = _speed * Time.deltaTime;

    //        Vector3 position = transform.position;
    //        position.x = Mathf.Lerp(transform.position.x, objectToFollow.transform.position.x, interpolation);
    //        position.y = Mathf.Lerp(transform.position.y, objectToFollow.transform.position.y, interpolation);
    //        position.z = Mathf.Lerp(transform.position.z, objectToFollow.transform.position.z, interpolation);

    //        transform.position = position;
    //    }
    //}
    
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

    void FollowThePlayer()
    {
        _distanceToXRrig = Vector3.Distance(objectToFollow.position, transform.position);

        transform.LookAt(objectToFollow);
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot) && isGathered == true)
        {
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

}

