using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        float randomRotation = Random.Range(0f, 360f);
        transform.eulerAngles = new Vector3(0, randomRotation, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
