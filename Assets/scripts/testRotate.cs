using UnityEngine;
using System.Collections;

public class testRotate : MonoBehaviour {

	public float J=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //J = J + 1;
        transform.localRotation = Quaternion.Euler(J, -90.0f, -90f);
	}

	void Add(){
		J = J + 1;
	}
}
