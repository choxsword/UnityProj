using UnityEngine;
using System.Collections;
using Netdc;
public class getPosition : MonoBehaviour {
    string logout;
    ClientSocket mSocket = new ClientSocket();
    string compareChange="hello";
	// Use this for initialization
	void Start () {
        mSocket.ConnectServer("127.0.0.1", 8088);
        mSocket.SendMessage("hello server");

	  
	}
	
	// Update is called once per frame
	void Update () {
        logout = string.Format("{0:f} {1:f} {2:f} {3:f} {4:f} {5:f}", transform.position.x, transform.position.z, transform.position.y, transform.eulerAngles.x, transform.eulerAngles.z, transform.eulerAngles.y);
        if (!compareChange.Equals(logout))
        {
            mSocket.SendMessage(logout);
            compareChange = logout;
            
        } 
        
        //mSocket.SendMessage(logout);

        //Debug.Log(logout);
            //transform.position.x.ToString;
        //Debug.Log(transform.position);
        //Debug.Log(transform.rotation);
        //Debug.Log(transform.eulerAngles);
	}
}
