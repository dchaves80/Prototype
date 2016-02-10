using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {


    UnityEngine.Camera CAM;
	// Use this for initialization
	void Start () {
        CAM = GetComponent<UnityEngine.Camera>();
        if (CAM != null) 
        {
            CAM.enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
