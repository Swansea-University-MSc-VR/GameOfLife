using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    public GameObject Prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {   
        //Check tag for "Flame"
        if (other.CompareTag("Flame"))
        {
            //Destroy the Prefab
            Destroy(Prefab);
        }
    }
}
