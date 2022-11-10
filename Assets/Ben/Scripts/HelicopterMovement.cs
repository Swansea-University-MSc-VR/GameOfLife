using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    public float helicopterSpeed;
    public GameObject helipadArea;
    public GameObject[] heliTargets;

    public XRRigMovement xRRigMovementForHelicopter;

    [SerializeField]
    private bool reachedTopArea;
    [SerializeField]
    private bool helicopterLanded;
    [SerializeField]
    private bool helicopterTakeOff;

    public GameObject stepToClimb;
    


    // Start is called before the first frame update
    void Start()
    {
        reachedTopArea = false;
        xRRigMovementForHelicopter = GameObject.FindGameObjectWithTag("XRrig").GetComponent<XRRigMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        helicopterTakeOff = xRRigMovementForHelicopter.isAllSaved;
        HelicopterFlyMovement();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "HeliPad")
        {
            helicopterLanded = true;
            Debug.Log("Heli is good");
            stepToClimb.SetActive(true);
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
        if(transform.position != helipadArea.transform.position && !reachedTopArea && !helicopterLanded && !helicopterTakeOff)
        {
            foreach (GameObject target in heliTargets)
            {
                transform.LookAt(target.transform);
                gameObject.transform.Translate(Vector3.forward * helicopterSpeed * Time.deltaTime);
                
            }
            //gameObject.transform.Translate(Vector3.forward * helicopterSpeed * Time.deltaTime);
        }

        if (reachedTopArea && !helicopterLanded && !helicopterTakeOff)
        {
            gameObject.transform.Translate(Vector3.down * Time.deltaTime);
        }
        else if(reachedTopArea && helicopterLanded && !helicopterTakeOff)
        {
            Debug.Log("Helicopter is safely landed");
        }
        else if(reachedTopArea && helicopterLanded && helicopterTakeOff)
        {
            stepToClimb.SetActive(false);
            Invoke("FinalTakeOff", 3f);
        }
        
    }

    void FinalTakeOff()
    {
        
        if (gameObject.transform.position.y < 11)
        {
            gameObject.transform.Translate(Vector3.up * Time.deltaTime);
        }
        if (gameObject.transform.position.x > -10)
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime);
        }

        gameObject.transform.Translate(Vector3.forward * helicopterSpeed * Time.deltaTime);
    }
}
