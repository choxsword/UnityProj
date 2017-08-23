using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    Vector3 from = new Vector3(0, 0, 0);
    Vector3 to = new Vector3(0, 10, 0);
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(from, to);
    }

  
}
