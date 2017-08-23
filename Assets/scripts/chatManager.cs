using UnityEngine;
using System.Net;
using System.Collections;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine.UI;
public class chatManager : MonoBehaviour
{

    private Socket connetSocket;
    //public UIInput textInput;
    private IPAddress address = IPAddress.Parse("127.0.0.1");
    private int point = 9476;

    //public UILabel chatLabel;
    private string willSendMessage;
    private byte[] reciveByte = new byte[1024];
    private Thread t;

    // Use this for initialization
    //打开应用程序，系统默认调用
    void Start()
    {
        ConnectServer();
        t = new Thread(reciveMessage);
        t.Start();
    }

    public void ConnectServer()
    {
        this.connetSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        this.connetSocket.Connect(address, point);
    }

    public void sendButtonDidClick()
    {

        byte[] message = Encoding.UTF8.GetBytes("hello");//textInput.value
        this.connetSocket.Send(message);
        //textInput.value = null;
    }

    private void reciveMessage()
    {
        while (true)
        {
            int length = this.connetSocket.Receive(reciveByte);
            this.willSendMessage = Encoding.UTF8.GetString(reciveByte, 0, length);
        }
    }
    //系统定时刷新
    void Update()
    {
        if (this.willSendMessage != null && this.willSendMessage != "")
        {
            //chatLabel.text += "\n" + this.willSendMessage;
            this.willSendMessage = "";
        }
    }

    // 当关闭客户端的时候会调用
    void onDestroy()
    {
        this.connetSocket.Shutdown(SocketShutdown.Both);
        this.connetSocket.Close();
    }
}