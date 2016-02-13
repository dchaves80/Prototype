using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeivitFaux : MonoBehaviour {

	public List<GameObject> Objects;
	public float Gravity;
	Rigidbody MyRigidBody;
    public bool ActivarAtmosfera;
	float MASS = 0f;
    public float DistanceFromCenter;
    public float SurfaceDistance;
    public Vector3 GravityForce;
    
    public float RealGravity;
	// Use this for initialization
	void Start () {
		MyRigidBody = gameObject.GetComponent<Rigidbody> ();
		if (MyRigidBody != null) {
			MASS = MyRigidBody.mass;
		}

        if (Objects != null && Objects.Count > 0)
        {
            SurfaceDistance = Vector3.Distance(gameObject.transform.position, Objects[0].transform.position)-10f;
        }

        if (Objects != null && Objects.Count > 0 && ActivarAtmosfera==true) 
        {
            Force MYFORCE = Objects[0].GetComponent<Force>();

            MYFORCE.Planet = gameObject;
        }
        

	}


    void FixedUpdate() 
    {
        foreach (GameObject GO in Objects)
        {
            if (GO.transform != null)
            {

                Vector3 dir = transform.position - GO.transform.position;
                dir.Normalize();
                Rigidbody RB = GO.GetComponent<Rigidbody>();
                DistanceFromCenter = Vector3.Distance(transform.position, GO.transform.position);
                float Distance = Vector3.Distance(transform.position, GO.transform.position);
                RealGravity = ((Gravity) * (RB.mass * MASS)) / (Distance*Distance);
                RB.AddForce((dir) * RealGravity, ForceMode.Force);
                GravityForce = ((dir));

            }
        }
    }


	// Update is called once per frame
	void Update () {
		
	}
}
