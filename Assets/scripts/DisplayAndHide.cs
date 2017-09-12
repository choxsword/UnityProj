using UnityEngine;
using System.Collections;

public class DisplayAndHide : MonoBehaviour {
    int x = 0;
    float moveTool = 0;
    GameObject worldFrame;
    GameObject customFrame;
    GameObject toolFrame;
    string[] transformPara;
	float[] CenterPos=new float[6];
	GameObject OriginTool;

	// Use this for initialization
	void Start () {
           worldFrame = GameObject.Find("Frame");
           customFrame = GameObject.Find("customFrame");
           toolFrame = GameObject.Find("toolFrame");
			OriginTool= Instantiate(toolFrame,toolFrame.transform.position,toolFrame.transform.rotation) as GameObject;


		OriginTool.transform.parent=GameObject.Find("help6").transform;
		OriginTool.transform.localScale=new Vector3(1,1,1);

           HideWorld();
           HideCustom();
        // HideTool();
//	HideOriginTool();


	}
	
	// Update is called once per frame
	void Update () {

        //x += 1;
        //Debug.Log(x);
        //if (x == 100)
        //{
        //TransformCustomFrame("-40 0 0 90 90 90");
        ////    TransformToolFrame(9.5f);
        //}
        //x = x + 1;
        //Debug.Log(x);
        //if (x == 400)
        //{

        //    HideWorld();
           

        //}
        //if (x == 200)
        //{
        //    DisplayWorld();
        //}


	}


	void HideOriginTool()
	{
		OriginTool.SetActive(false);


	}
	void DispOriginTool()
	{
		OriginTool.SetActive(true);

	}
    //void Hide(GameObject obj) {
       
    //    obj.SetActive(false);

    //}

    //void Display(GameObject obj)
    //{
    //   obj.SetActive(true);
    
    //}
    void HideWorld()
    {
       
        worldFrame.SetActive(false);

    }

    void DisplayWorld()
    {
       
        worldFrame.SetActive(true);

    }

    void HideTool()
    {

        toolFrame.SetActive(false);

    }

    void DisplayTool()
    {

        toolFrame.SetActive(true);

    }

    void HideCustom()
    {

        customFrame.SetActive(false);

    }

    void DisplayCustom()
    {

        customFrame.SetActive(true);

    }


    void TransformToolFrame(string val)
    {
		string[] ToolCenter=val.Split(' ');
		for(int i=0;i<3;i++)
		{CenterPos[i]=0.1f*(float)System.Convert.ToDouble(ToolCenter[i]);
		}
		for(int i=3;i<6;i++)
		{CenterPos[i]=(float)System.Convert.ToDouble(ToolCenter[i]);
		}


        toolFrame.SetActive(true);

		toolFrame.transform.localPosition=new Vector3(-0.7499981f,-0.0002732873f,-0.0001205802f);
		toolFrame.transform.localEulerAngles=new Vector3(0,180,90);

        toolFrame.transform.Translate(new Vector3(CenterPos[0],CenterPos[2], CenterPos[1]), Space.Self);
		toolFrame.transform.Rotate(Vector3.up * -CenterPos[5], Space.Self);
		toolFrame.transform.Rotate(Vector3.forward * -CenterPos[4], Space.Self);
		toolFrame.transform.Rotate(Vector3.right * -CenterPos[3], Space.Self);

    }

    void TransformCustomFrame(object val)
    {
        string s = (string)val;
        customFrame.SetActive(true);
        transformPara = s.Split(new char[] { ' ' });
        //foreach(string temp in transformPara)
        //    Debug.Log(temp);

        customFrame.transform.position = new Vector3(float.Parse(transformPara[0]) * 0.1f, float.Parse(transformPara[2]) * 0.1f, float.Parse(transformPara[1]) * 0.1f);
        //this.transform.Rotate(-90, 0, 0);
        //this.transform.Rotate(0, 0, 90);
        customFrame.transform.Rotate(Vector3.right * -float.Parse(transformPara[3]), Space.World);
        customFrame.transform.Rotate(Vector3.forward * -float.Parse(transformPara[4]), Space.World);
        customFrame.transform.Rotate(Vector3.up * -float.Parse(transformPara[5]), Space.World);


    }

	    void deleteCustom()
	    {
	
	        customFrame.transform.position = new Vector3(0, 0, 0);
	
			customFrame.transform.rotation=Quaternion.identity;
	        customFrame.SetActive(false);
	
	
	
	    }
}
