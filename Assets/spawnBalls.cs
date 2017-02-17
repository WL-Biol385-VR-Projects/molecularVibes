using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// scipt components implement a single class that derives from `MonoBehavior`
public class spawnBalls : MonoBehaviour {

    // `public` variables are exposed as configurable attributes on script components
    public Transform ballPrefab;             // Transforms control the position and size of every GameObject
    public int       ballCount;              // This implementation hard codes number of balls using editor
    public float     maxVelocity;
    public Vector3   areaCenter, areaScale;  // A vector in 3D space

    //`private` variables are only accessible in methods on this object
    private List<Transform> balls;           // A List of Transform objects; lists are more efficient than arrays when you're frequently resizing.
    private float xmin,                      // Size of spawn and collision box, based on the transform on gameObject this script is attached to
                  xmax,
                  ymin,
                  ymax,
                  zmin,
                  zmax;

    private void SpawnBalls()
    {

    }

    private void SpawnColliders()
    {
        // gameObject is the GameObject that the script is attached to
        var top = gameObject.AddComponent<BoxCollider>();
        top.center = new Vector3(1, 2, xmin);
    }

	// Run at scene initialization
	void Start ()
    {

        // there is probably a more elegant c# way of doing this
        xmin = transform.localPosition.x - (transform.localScale.x / 2);
        xmax = transform.localPosition.x + (transform.localScale.x / 2);
        ymin = transform.localPosition.y - (transform.localScale.y / 2);
        ymax = transform.localPosition.y + (transform.localScale.y / 2);
        zmin = transform.localPosition.z - (transform.localScale.z / 2);
        zmax = transform.localPosition.z + (transform.localScale.z / 2);

        // simple for..loop with an integer counter; one per ball
        for (var i = 0; i < ballCount; i++)
        {
            // `Random.Range` returns a random number within the range given.  We'll
            // randomize the starting x,z position of the balls
            float x = Random.Range(xmin, xmax);
            float y = Random.Range(ymin, ymax);
            float z = Random.Range(zmin, zmax);

            // the `(Transform)` syntax on this line is a type-cast; it's a way of telling 
            // the compiler you know the actual return subclass from a call.
            Transform obj = (Transform) Instantiate(ballPrefab, new Vector3(x, y, z), Quaternion.identity);

            // Here we generate a random velocity vector to apply to each ball
            float min = -1 * maxVelocity;
            float max = maxVelocity;
            Vector3 v = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));

            // the `<Rigidbody>` syntax here is a type parameter being used with a
            // generic function `GetComponent`.  In this case it causes the generic function
            // to return a `Rigidbody` component if one is attached; null if not.
            obj.GetComponent<Rigidbody>().AddForce(v, ForceMode.VelocityChange);
        }

	}
	
	// Update is called once per frame; don't do any heavy lifting here
	void Update ()
    {
	
	}

}
