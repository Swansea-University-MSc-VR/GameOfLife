using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTransition : MonoBehaviour
{
    [SerializeField]
    private Animator avatarAnimator;

    private int i;


    void Start()
    {
        avatarAnimator = gameObject.GetComponent<Animator>();
    }

    
    void Update()
    {
        ChangeAnimation();

    }

    void ChangeAnimation()
    {
        if (Input.GetKey(KeyCode.N))
        {
            avatarAnimator.Play("Waving");
            i++;
            Debug.Log("i value: " + i);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Fire")
        {
            avatarAnimator.Play("Death");
        }
    }
}
