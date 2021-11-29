using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBehaviour : MonoBehaviour
{

    public Transform raycastOrigin;

    public LayerMask layerMask;
    public GameObject hitSpawnObject;



    // Update is called once per frame
    void Update()
    {
        AdvancedRaycast();

    }

    private void AdvancedRaycast()
    {
        Debug.DrawRay(transform.position, transform.forward * 6f, Color.magenta);

        RaycastHit hit;

        if (Physics.Raycast(raycastOrigin.position,transform.forward, out hit, 6f,layerMask))
        {

            hit.transform.gameObject.SetActive(false);
            
            Debug.Log("Raycast Interaction");
            //use layer mask to filter collider objects.
        }
    }
}
