using UnityEngine;
using System.Collections;

// scipt components implement a single class that derives from `MonoBehavior`
public class spawnBalls : MonoBehaviour {

    // `public` variables are exposed as configurable attributes on script components
    public Transform ballPrefab;
    public int       ballCount;
    public float     maxVelocity;
    public Vector3   areaCenter, areaScale;

	// Run at scene initialization
	void Start () {

        // there is probably a more elegant idomatic c# way of doing this
        float xmin = areaCenter.x - (areaScale.x / 2);
        float xmax = areaCenter.x + (areaScale.x / 2);
        float ymin = areaCenter.y - (areaScale.y / 2);
        float ymax = areaCenter.y + (areaScale.y / 2);
        float zmin = areaCenter.z - (areaScale.z / 2);
        float zmax = areaCenter.z + (areaScale.z / 2);

        // simple for..loop with an integer counter; one per new ball
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
	void Update () {
	
	}

}
