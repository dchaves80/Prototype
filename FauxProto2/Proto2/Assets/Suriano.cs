using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Suriano : MonoBehaviour {

    public GameObject PLANET;
    public float ENERGY;
    public float L;
    Rigidbody MYRB;
    Rigidbody PlanetRB;
    Transform TransformPlanet;

    public List<float> MomentoAngular;
    public int Precision;

	// Use this for initialization
	void Start () {
        MYRB = gameObject.GetComponent<Rigidbody>();
        TransformPlanet = PLANET.GetComponent<Transform>();
        PlanetRB = PLANET.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
	float r =Vector3.Distance( this.transform.position,TransformPlanet.position); 
        ENERGY = (MYRB.mass*Mathf.Pow( MYRB.velocity.magnitude,2f))-((6.9f*PlanetRB.mass*MYRB.mass)/r );

        MomentoAngular.Clear();
        float angle = 360f / Precision;
        for (int a = 0 ;a<Precision;a++)
        {
            L = MYRB.mass * r * MYRB.velocity.magnitude * (a*angle);
            MomentoAngular.Add(L);
            
        }

        
	}
}
