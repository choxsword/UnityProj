using UnityEngine;
using System.Collections;
using Netdc;
using System.Net;
using System.Net.Sockets;

public class TestSocket : MonoBehaviour
{

	int i=0;
	ClientSocket mSocket = new ClientSocket();
    //Use this for initialization  
    void Start()
    {

	
       mSocket.ConnectServer("127.0.0.1", 8088);
        mSocket.SendMessage("服务器你好！");
        
    }

    // Update is called once per frame  
    void Update()
    {
		//mSocket.SendMessage("服务器你好！");
		//Debug.Log("ohshit");
		i++;
		string send="服务器"+i;
		mSocket.SendMessage("fuckserver");
		//Debug.Log(i);
    }
}