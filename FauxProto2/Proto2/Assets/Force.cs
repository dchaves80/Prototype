using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour {

	// Use this for initialization

    Rect MyWindow = new Rect(0f, 0f, 200f, 200f);
    string StringForce = "Fuerza Motor";
    string StringFuel = "Combustible";
    bool LanzamientoON = false;
    public float FORCE;
    public float FUEL;
    bool showGUI = true;
    Rigidbody thisrigidbody;
    ParticleSystem Emitter;
    public GameObject Planet;
    public float Distance;
    public Vector3 Speed;
    public float Angle;
    public bool ReadAtmosphere;
    public float RocketTorque=0f;
    
    void OnGUI() 
    {
        if (showGUI)
        {
            MyWindow = GUI.Window(0, MyWindow, DoMyWindow, "Configuraciones");
            Rect TextField = new Rect(MyWindow.x + 50f, MyWindow.y + 30f, 100f, 30f);
            StringForce = GUI.TextField(TextField, StringForce);
            Rect TextField2 = new Rect(TextField.x, TextField.y + 50f, 100f, 30f);
            StringFuel = GUI.TextField(TextField2, StringFuel);
            if (GUI.Button(new Rect(TextField2.x, TextField2.y+50f, 100f, 30f), "Lanzar!"))
            {
                LanzamientoON = true;
                FORCE = float.Parse(StringForce);
                FUEL = float.Parse(StringFuel);
            }
        }
            
    }

    void DoMyWindow(int WindowID) 
    {

    }

	void Start () {
        thisrigidbody = gameObject.GetComponent<Rigidbody>();
        Transform TransformEmitter = this.transform.FindChild("PS");
        Emitter = TransformEmitter.gameObject.GetComponent<ParticleSystem>();
        Emitter.Stop();
        if (Planet != null) 
        {
            DeivitFaux DF = Planet.GetComponent<DeivitFaux>();
            ReadAtmosphere = DF.ActivarAtmosfera;
        }
        
	}


    void FixedUpdate() 
    {
        Speed = new Vector3(thisrigidbody.velocity.x, thisrigidbody.velocity.y, thisrigidbody.velocity.z);


        if (Planet != null && ReadAtmosphere == true)
        {
            Angle = Vector3.Angle(Planet.transform.position, thisrigidbody.position);
            Distance = Vector3.Distance(Planet.transform.position, this.transform.position);
            thisrigidbody.drag = 10f / Distance;
            if (thisrigidbody.drag < 0.001f)
            {
                Planet = null;
            }
        }


        if (LanzamientoON == true)
        {



            if (FUEL < 0.1f)
            {
                FUEL = 0f;
                if (Emitter.isPlaying)
                {
                    Emitter.Stop();
                }
                FORCE = 0f;
            }
            else
            {
                if (!Emitter.isPlaying)
                {
                    Emitter.Play();
                }

            }
            showGUI = false;
            FUEL = FUEL - Time.deltaTime;
            thisrigidbody.AddRelativeForce((FORCE) * Vector3.up);



        }



        if (Input.GetKey(KeyCode.A))
        {
            thisrigidbody.AddRelativeTorque(RocketTorque * Vector3.left);

        }
        if (Input.GetKey(KeyCode.D))
        {
            thisrigidbody.AddRelativeTorque(RocketTorque * Vector3.right);
        }

        if (Input.GetKey(KeyCode.W))
        {
            thisrigidbody.AddRelativeTorque(RocketTorque * Vector3.forward);

        }
        if (Input.GetKey(KeyCode.S))
        {
            thisrigidbody.AddRelativeTorque(RocketTorque * Vector3.back);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            thisrigidbody.AddRelativeTorque(RocketTorque * Vector3.up);

        }
        if (Input.GetKey(KeyCode.E))
        {
            thisrigidbody.AddRelativeTorque(RocketTorque * Vector3.down);
        }
    }

	// Update is called once per frame
	void Update () {
    
	}
}
