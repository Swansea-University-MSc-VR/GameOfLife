using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTransition : MonoBehaviour
{
    [SerializeField]
    private Animator avatarAnimator;

    [SerializeField]
    private ManikinHealth _manikinHealth;

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
            avatarAnimator.Play("DeathRight");
            i++;
            Debug.Log("i value: " + i);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Fire" && _manikinHealth.manikinTotalHealthLeft == 0f)
        {
            avatarAnimator.Play("Death");
        }
        else if(_manikinHealth.manikinTotalHealthLeft == 0f)
        {
            avatarAnimator.Play("Death");
        }
    }
}
