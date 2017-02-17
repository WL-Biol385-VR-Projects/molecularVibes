using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBalls : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Debug.Log("things are starting");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float repelForce= 100f;
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("enter");
        float x = Random.Range(-1 * repelForce, repelForce);
        float y = Random.Range(-1 * repelForce, repelForce);
        float z = Random.Range(-1 * repelForce, repelForce);

        other.GetComponent<Rigidbody>().AddForce(new Vector3(x, y, z), ForceMode.Acceleration);
    }

    public void OnTriggerStay(Collider other)
    {

        //Debug.Log("Enter:", other);
    }

    public void OnTriggerExit(Collider other)
    {
       // Debug.Log("exit");
    }
}
