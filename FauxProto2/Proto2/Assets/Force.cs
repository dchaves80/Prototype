using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour {

	// Use this for initialization

    Rect MyWindow = new Rect(0f, 0f, 200f, 200f);
    string StringForce = "0";
    bool LanzamientoON = false;
    public float FORCE;
    bool showGUI = true;
    Rigidbody thisrigidbody;
    void OnGUI() 
    {
        if (showGUI)
        {
            MyWindow = GUI.Window(0, MyWindow, DoMyWindow, "Fuerza");
            Rect TextField = new Rect(MyWindow.x + 10f, MyWindow.y + 30f, 100f, 30f);
            StringForce = GUI.TextField(TextField, StringForce);
            if (GUI.Button(new Rect(MyWindow.x + 100, MyWindow.y + 30, 100f, 30f), "Lanzar!"))
            {
                LanzamientoON = true;
                FORCE = float.Parse(StringForce);
            }
        }
            
    }

    void DoMyWindow(int WindowID) 
    {

    }

	void Start () {
        thisrigidbody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
       
        

        if (LanzamientoON == true) 
        {
            if (FORCE < 0.1f) { FORCE = 0f; }
            showGUI = false;
            FORCE = Mathf.Lerp(FORCE, 0F, Time.deltaTime/10f);
            thisrigidbody.AddRelativeForce(FORCE*Vector3.up);

        }



        if (Input.GetKey(KeyCode.A))
        {
            thisrigidbody.AddRelativeTorque(20f * Vector3.left);

        }
             if (Input.GetKey(KeyCode.D)) 
        {
            thisrigidbody.AddRelativeTorque(20f*Vector3.right);
        }
	}
}
