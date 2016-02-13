using UnityEngine;
using System.Collections;

public class Kepler : MonoBehaviour {
    public Transform PIVOT1;
    public Transform PIVOT2;
    public Transform MiddlePoint;
    public Transform OtherFocalPoint;
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
    public float SemiMinorAxis;
    public Vector3 Eccentricity;
    public float EccentricityMagnitude;
    public Vector3 DebuggerVector;
    public float DebuggerMagnitude;
    public float Inclination;
    public float InclinationGrades;
    public float AscendingNodeLongitude;
    public Vector3 ArgumentOfPeriapsisVector;
    public float ArgumentOfPeriapsisMagnitude;
    public float ApoapsisDistance;
    public float PeriapsisDistance;
   
    public LineRenderer LR;
    

	// Use this for initialization
	void Start () {
        
        gameObject.AddComponent(LR.GetType());
        LR = this.GetComponent<LineRenderer>();
        LR.SetColors(Color.red, Color.red);
        LR.SetVertexCount(360);
        LR.SetWidth(1f, 1f);
        LR.enabled = true;
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
        StandardGravitationalParameter = 6.9f * (Planet.mass+Body.mass);
        
        Energy = (VelocityMagnitude * VelocityMagnitude) * 0.5f - (StandardGravitationalParameter/DistanceMagnitude);
        
        SemiMajorAxis = (StandardGravitationalParameter / (Energy * 2)) * -1;
        Eccentricity = (Vector3.Cross(VelocityVector, AngularMomentum) / StandardGravitationalParameter) - DistanceVector / DistanceMagnitude;
        EccentricityMagnitude = Eccentricity.magnitude;

        DebuggerVector = Vector3.Cross(new Vector3(1, 1, 1), new Vector3(1, 2, 3));

        DebuggerMagnitude = DebuggerVector.magnitude;
        Inclination = Mathf.Acos(AngularMomentum.z / AngularMomentum.magnitude);
        InclinationGrades = Inclination * (180f / Mathf.PI);
        AscendingNodeLongitude = Mathf.Acos(AscendingNodeVector.x / AscendingNodeMagnitude);
        ArgumentOfPeriapsisMagnitude  =  (Vector3.Dot(AscendingNodeVector,Eccentricity)/(AscendingNodeMagnitude/EccentricityMagnitude));
        ApoapsisDistance = SemiMajorAxis * (1f + EccentricityMagnitude);
        PeriapsisDistance = SemiMajorAxis * (1f - EccentricityMagnitude);
        if (EccentricityMagnitude < 0) 
        {
            ArgumentOfPeriapsisMagnitude=(2* Mathf.PI) - ArgumentOfPeriapsisMagnitude;
        }
        PIVOT1.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        PIVOT1.position = new Vector3(0, 0, 0);
        PIVOT1.LookAt(Eccentricity, Vector3.up);
        PIVOT1.Translate(Vector3.forward * PeriapsisDistance);

        PIVOT2.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        PIVOT2.position = new Vector3(0, 0, 0);
        PIVOT2.LookAt(-Eccentricity, Vector3.up);
        PIVOT2.Translate(Vector3.forward * ApoapsisDistance);

       

        OtherFocalPoint.position = PIVOT2.position;
        OtherFocalPoint.LookAt(PIVOT1.position, Vector3.up);
        OtherFocalPoint.Translate(Vector3.forward * PeriapsisDistance);

        MiddlePoint.rotation = Quaternion.Euler(new Vector3(0,0,0));
        MiddlePoint.position = Vector3.Lerp(PIVOT1.position, PIVOT2.position, 0.5f);
        Vector3 MiddlepointVector = MiddlePoint.position;
        float c = Vector3.Distance(MiddlePoint.position, Planet.position);
       
        
      
        if (!float.IsInfinity(EccentricityMagnitude))
        {
            SemiMinorAxis = (SemiMajorAxis * Mathf.Sqrt(1f - (EccentricityMagnitude*EccentricityMagnitude)));
        }



        

        if (EccentricityMagnitude > 0 && !float.IsInfinity(EccentricityMagnitude) && !float.IsNaN(SemiMajorAxis))
        {
            for (int a = 0; a < 360; a++)
            {
                MiddlePoint.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                MiddlePoint.position = MiddlepointVector;
                MiddlePoint.localPosition = MiddlepointVector;
                MiddlePoint.position = MiddlepointVector;
                MiddlePoint.rotation = PIVOT1.rotation;

                //MiddlePoint.Rotate(Vector3.up * (a+90f), Space.Self);


                //float radius =  (PeriapsisDistance * ApoapsisDistance) / Mathf.Sqrt( Mathf.Pow((ApoapsisDistance * Mathf.Cos(Mathf.Deg2Rad*(a))),2) + Mathf.Pow((PeriapsisDistance * Mathf.Sin(Mathf.Deg2Rad*(a))),2));
                MiddlePoint.Translate(Vector3.forward * (SemiMajorAxis * Mathf.Cos(Mathf.Deg2Rad * a)));
                MiddlePoint.Translate(Vector3.left * (SemiMinorAxis * Mathf.Sin(Mathf.Deg2Rad * a)));
                LR.SetPosition(a, MiddlePoint.position);
                
            }
        }
       
       

        
       








       /*
            PIVOT1.position = new Vector3(0, 0, 0);
            PIVOT1.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            PIVOT2.localPosition = new Vector3(0, 0, 0);
            PIVOT2.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            PIVOT2.position = new Vector3(0, 0, 0);
            PIVOT2.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

            PIVOT1.eulerAngles = new Vector3(0, -(ArgumentOfPeriapsisMagnitude), 0f);
            PIVOT2.localEulerAngles = new Vector3(0, 0, -InclinationGrades);

            //IINDICATOR.Rotate(Vector3.up, -ArgumentOfPeriapsisMagnitude);
            //IINDICATOR.Rotate(Vector3.right, InclinationGrades);
            PIVOT2.Translate(new Vector3(0,ApoapsisDistance,0));
       */

        


	}
}
