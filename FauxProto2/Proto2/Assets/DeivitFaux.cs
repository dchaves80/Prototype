using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeivitFaux : MonoBehaviour {

	public List<GameObject> Objects;
	public float Gravity;
	Rigidbody MyRigidBody;
    public bool ActivarAtmosfera;
	float MASS = 0;
	// Use this for initialization
	void Start () {
		MyRigidBody = gameObject.GetComponent<Rigidbody> ();
		if (MyRigidBody != null) {
			MASS = MyRigidBody.mass;
		}



        if (Objects != null && Objects.Count > 0 && ActivarAtmosfera==true) 
        {
            Force MYFORCE = Objects[0].GetComponent<Force>();
            MYFORCE.Planet = gameObject;
        }

	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject GO in Objects) {
			if (GO.transform!=null)
			{

				Vector3 dir = transform.position - GO.transform.position;
				dir = dir.normalized;
				Rigidbody RB = GO.GetComponent<Rigidbody>();
				float Distance = Vector3.Distance(transform.position,GO.transform.position);

                

				RB.AddForce((dir * Gravity) * (RB.mass * MASS) / (Mathf.Pow(Distance,2f)),ForceMode.Force);

			}
		}
	}
}
