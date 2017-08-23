using UnityEngine;
using System.Collections;

public class AxisColor : MonoBehaviour {

    private GameObject obj;
    private Renderer render;
    private GameObject[] objs;
	// Use this for initialization
	void Start () {
        ////获取游戏对象
        //obj = GameObject.Find("axisX");
        ////获取该游戏对象的渲染器
        //render = obj.GetComponent<Renderer>();
        ////改变渲染的颜色
        //render.material.color = Color.red;
        //obj = GameObject.Find("axisY");
        ////获取该游戏对象的渲染器
        //render = obj.GetComponent<Renderer>();
        ////改变渲染的颜色
        //render.material.color = Color.green;
        //obj = GameObject.Find("axisZ");
        ////获取该游戏对象的渲染器
        //render = obj.GetComponent<Renderer>();
        ////改变渲染的颜色
        //render.material.color = Color.blue;
        objs = GameObject.FindGameObjectsWithTag("AxisX");
        foreach(GameObject obj in objs)
        {
            obj.GetComponent<Renderer>().material.color = Color.red;
        }

        objs = GameObject.FindGameObjectsWithTag("AxisY");
        foreach (GameObject obj in objs)
        {
            obj.GetComponent<Renderer>().material.color = Color.green;
        }

        objs = GameObject.FindGameObjectsWithTag("AxisZ");
        foreach (GameObject obj in objs)
        {
            obj.GetComponent<Renderer>().material.color = Color.blue;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
