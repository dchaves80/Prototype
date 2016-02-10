using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeivitLaw : MonoBehaviour {


    
    public List<GravityObject> gravityObjects;
    public Vector3 startingVelocity;
    Vector3 dir;
    Vector3[] orbitPoints;
    public int maxCount = 10000;
    public int countPerFrame = 10;
    public int simplify = 5;
    int privateMaxCount;
    public LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public class GravityObject
    {
        Transform trans;
        float g;
        public GravityObject(Transform T, float G)
        {
            trans = T;
            g = G;

        }
    }

}
