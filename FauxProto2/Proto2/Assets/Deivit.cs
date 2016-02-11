using UnityEngine;
using System.Collections;

public class Deivit : MonoBehaviour {

    public GameObject Planet;
    public float TIMER;
    public int STEPS;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody RB = this.GetComponent<Rigidbody>();
        DeivitFaux DF = Planet.GetComponent<DeivitFaux>();
        UpdateTrajectory(transform.position, RB.velocity,DF.GravityForce );
	}

    void UpdateTrajectory(Vector3 initialPosition, Vector3 initialVelocity, Vector3 gravity)
    {
        int numSteps = STEPS; // for example
        float timeDelta = TIMER / initialVelocity.magnitude; // for example

        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetVertexCount(numSteps);
        float TIMER1 = 0;
        Vector3 position = initialPosition;
        Vector3 velocity = initialVelocity;
        for (int i = 0; i < numSteps; ++i)
        {
            TIMER++;
            
            lineRenderer.SetPosition(i, position);
        /*   


            position += velocity * timeDelta + 0.5f * gravity *timeDelta * timeDelta;*/
            
            velocity += gravity  *TIMER1;
            float angle = Vector3.Angle(position, Planet.transform.position);
            float x = velocity.x * Mathf.Cos(angle) * TIMER1;
            float y = velocity.y * Mathf.Sin(angle) - 0.5f * gravity.y * TIMER1 * TIMER1;
            float z = velocity.z * Mathf.Sin(angle) * TIMER1;
            position = new Vector3(x, y, z);

           

        }
    }
}
