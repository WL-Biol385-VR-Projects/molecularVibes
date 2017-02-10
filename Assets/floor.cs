using UnityEngine;
using System.Collections;

public class floor : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Debug.Log("things are starting");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float floorForce = 100f;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
    }

    public void OnTriggerStay(Collider other)    {
        other.GetComponent<Rigidbody>().AddForce(Vector3.up * floorForce, ForceMode.Acceleration);
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
    }

}
