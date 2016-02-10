using UnityEngine;
using System.Collections;

public class PointObject : MonoBehaviour {

	// Use this for initialization
    public GameObject TOPOINT;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (TOPOINT != null) 
        {
            transform.LookAt(TOPOINT.transform);
        }
	}
}
