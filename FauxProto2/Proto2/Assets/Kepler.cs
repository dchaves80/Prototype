using UnityEngine;
using System.Collections;

public class Kepler : MonoBehaviour {
    public Transform IINDICATOR;
    public Rigidbody Body;
    public Rigidbody Planet;
    public Vector3 DistanceVector;
    public float DistanceMagnitude;
    public Vector3 VelocityVector;
    public float VelocityMagnitude;
    public Vector3 AngularMomentum;
    public float ANgularMomentumMagnitude;
    readonly public Vector3 K = new Vector3(0, 0, 1);
    public Vector3 AscendingNodeVector;
    public float AscendingNodeMagnitude;
    public float StandardGravitationalParameter;
    public float Energy;
    public float SemiMajorAxis;
    public Vector3 Eccentricity;
    public float EccentricityMagnitude;
    public Vector3 DebuggerVector;
    public float DebuggerMagnitude;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        DistanceVector = Body.transform.position - Planet.transform.position;
        DistanceMagnitude = DistanceVector.magnitude;
        VelocityVector = Body.velocity;
        VelocityMagnitude = VelocityVector.magnitude;
        AngularMomentum = Vector3.Cross(DistanceVector, VelocityVector);
        ANgularMomentumMagnitude = AngularMomentum.magnitude;
        AscendingNodeVector = Vector3.Cross(K, AngularMomentum);
        AscendingNodeMagnitude = AscendingNodeVector.magnitude;
        IINDICATOR.position = AscendingNodeVector;
        StandardGravitationalParameter = 6.9f * (Planet.mass+Body.mass);
        Energy = (VelocityMagnitude * VelocityMagnitude) * 0.5f - (StandardGravitationalParameter/DistanceMagnitude);
        SemiMajorAxis = (StandardGravitationalParameter / (Energy * 2)) * -1;
        Eccentricity = (Vector3.Cross(VelocityVector, AngularMomentum) / StandardGravitationalParameter) - DistanceVector / DistanceMagnitude;
        EccentricityMagnitude = Eccentricity.magnitude;

        DebuggerVector = Vector3.Cross(new Vector3(1, 1, 1), new Vector3(1, 2, 3));

        DebuggerMagnitude = DebuggerVector.magnitude;

        


	}
}
