using UnityEngine;
using System.Collections;

public class changeView : MonoBehaviour {

    private Vector3 PreMouseMPos;
    private Vector3 PreMouseLPos;
    private float wheelSpeed = 5.0f;
	Transform m_Transform;
	GameObject Plane;
	// Use this for initialization
	void Start () {
		m_Transform =gameObject.GetComponent<Transform>();

		Plane=GameObject.Find("Plane");

	}
	
	// Update is called once per frame
	void Update () {
        //鼠标滚轮的效果
        //Camera.main.fieldOfView 摄像机的视野
        //Camera.main.orthographicSize 摄像机的正交投影
        //Zoom out
//	        if (Input.GetAxis("Mouse ScrollWheel") < 0)
//	        {
//	            if (Camera.main.fieldOfView <= 100)
//	                Camera.main.fieldOfView += 2;
//	            if (Camera.main.orthographicSize <= 20)
//	                Camera.main.orthographicSize += 0.5F;
//
//
//	        }
//	        //Zoom in
//	        if (Input.GetAxis("Mouse ScrollWheel") > 0)
//	        {
//	            if (Camera.main.fieldOfView > 2)
//	                Camera.main.fieldOfView -= 2;
//	            if (Camera.main.orthographicSize >= 1)
//	                Camera.main.orthographicSize -= 0.5F;
//	        }

//
//		if (Input.GetAxis("Mouse ScrollWheel") < 0)
//		{
//			m_Transform.Translate(Vector3.forward * 2f, Space.Self);
//		}
//		if (Input.GetAxis("Mouse ScrollWheel") > 0)
//		{
//			m_Transform.Translate(Vector3.back * 2f, Space.Self);
//		}

        //鼠标滚轴按下，移动摄像头
//        if (Input.GetMouseButton(1))
//        {
//
//            if (PreMouseMPos.x <= 0)
//            {
//                PreMouseMPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
//            }
//            else
//            {
//                Vector3 CurMouseMPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
//                Vector3 offset = CurMouseMPos - PreMouseMPos;
//                offset = -offset * 0.5f;
//                transform.Translate(offset);
//                PreMouseMPos = CurMouseMPos;
//            }
//        }
//        else
//        {
//            PreMouseMPos = new Vector3(0.0f, 0.0f, 0.0f);
//        }

        
	}

    //IEnumerator OnMouseDown()
    //{
    //    //将物体由世界坐标系转换为屏幕坐标系
    //    Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);//三维物体坐标转屏幕坐标
    //    //完成两个步骤 1.由于鼠标的坐标系是2维，需要转换成3维的世界坐标系  
    //    //    //             2.只有3维坐标情况下才能来计算鼠标位置与物理的距离，offset即是距离
    //    //将鼠标屏幕坐标转为三维坐标，再算出物体位置与鼠标之间的距离
    //    Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
    //    while (Input.GetMouseButton(0))
    //    {
    //        //得到现在鼠标的2维坐标系位置
    //        Vector3 curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
    //        //将当前鼠标的2维位置转换成3维位置，再加上鼠标的移动量
    //        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
    //        //curPosition就是物体应该的移动向量赋给transform的position属性
    //        transform.position = curPosition;
    //        yield return new WaitForFixedUpdate(); //这个很重要，循环执行
    //    }
    //}
}
