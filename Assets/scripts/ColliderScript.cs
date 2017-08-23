using UnityEngine;
using System.Collections;

public class ColliderScript : MonoBehaviour {


    void OnTriggerEnter(Collider other)
    {
		Application.ExternalCall("crash", "");  
        this.GetComponent<Renderer>().material.color = Color.red;


	
    }

    void OnTriggerExit(Collider other) {
		Application.ExternalCall("NOcrash", "");  
        this.GetComponent<Renderer>().material.color = Color.white;


	
    }
   
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
