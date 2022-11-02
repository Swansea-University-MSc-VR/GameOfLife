using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManikinController : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 offset;

    [SerializeField]
    private Animator avatarAnimator;

    [SerializeField]
    private float _speed;
    void Start()
    {
        objectToFollow = GameObject.FindGameObjectWithTag("XRrig").GetComponent<Transform>();
        avatarAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //FollowXRrig();
        FollowSmoothly();
    }


    void FollowXRrig()
    {
        float distanceToXRrig = Vector3.Distance(objectToFollow.position, transform.position);

        if(distanceToXRrig < 3)
        {
            transform.LookAt(objectToFollow);
        }

        if(distanceToXRrig < 1.5)
        {
            gameObject.transform.position = objectToFollow.position + offset;
        }
    }

    void FollowSmoothly()
    {
        float distanceToXRrig = Vector3.Distance(objectToFollow.position, transform.position);

        if (distanceToXRrig < 3)
        {
            transform.LookAt(objectToFollow);
        }

        if (distanceToXRrig < 1.5)
        {
            float interpolation = _speed * Time.deltaTime;

            Vector3 position = transform.position;
            position.x = Mathf.Lerp(transform.position.x, objectToFollow.transform.position.x, interpolation);
            position.y = Mathf.Lerp(transform.position.y, objectToFollow.transform.position.y, interpolation);
            position.z = Mathf.Lerp(transform.position.z, objectToFollow.transform.position.z, interpolation);

            transform.position = position;
        }
    }
    
    void AinmationTransition()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            avatarAnimator.Play("Death");
        }
    }
}
