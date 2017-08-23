using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void UpdateJoints(string MsgFromWinForm)
	
	{
		string[] JointValue=MsgFromWinForm.Split(' ');
		//Application.ExternalCall("msg",JointValue);  
		GameObject.Find("help1").GetComponent<joint1>().SetJ(JointValue[0]);
	  GameObject.Find("help2").GetComponent<joint2>().SetJ(JointValue[1]);
	  GameObject.Find("help3").GetComponent<joint3>().SetJ(JointValue[2]);
		GameObject.Find("help4").GetComponent<joint4>().SetJ(JointValue[3]);
		GameObject.Find("help5").GetComponent<joint5>().SetJ(JointValue[4]);
		GameObject.Find("help6").GetComponent<joint6>().SetJ(JointValue[5]);


	}




}

