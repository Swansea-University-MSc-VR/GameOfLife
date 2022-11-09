using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    public float helicopterSpeed;
    public GameObject helipadArea;
    public GameObject[] heliTargets;

    [SerializeField]
    private bool reachedTopArea;
    [SerializeField]
    private bool helicopterLanded;


    // Start is called before the first frame update
    void Start()
    {
        reachedTopArea = false;
    }

    // Update is called once per frame
    void Update()
    {
        HelicopterFlyMovement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "HeliPad")
        {
            helicopterLanded = true;
            Debug.Log("Heli is good");
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {

            StartCoroutine(WaitForLanding());
        }
    }
    
    IEnumerator WaitForLanding()
    {
        yield return new WaitForSeconds(3.5f);
        reachedTopArea = true;
        Debug.Log("Heli is good");
    }

    void HelicopterFlyMovement()
    {
        //transform.LookAt(helipadArea.transform);
        if(transform.position != helipadArea.transform.position && !reachedTopArea && !helicopterLanded)
        {
            foreach (GameObject target in heliTargets)
            {
                transform.LookAt(target.transform);
                gameObject.transform.Translate(Vector3.forward * helicopterSpeed * Time.deltaTime);
                
            }
            //gameObject.transform.Translate(Vector3.forward * helicopterSpeed * Time.deltaTime);
        }

        if (reachedTopArea && !helicopterLanded)
        {
            gameObject.transform.Translate(Vector3.down * Time.deltaTime);
        }
        else if(reachedTopArea && helicopterLanded)
        {
            Debug.Log("Helicopter is safely landed");
        }
        
    }
}
