using UnityEngine;
using System.Collections;

public class DisplayAndHide : MonoBehaviour {
    int x = 0;
    float moveTool = 0;
    GameObject worldFrame;
    GameObject customFrame;
    GameObject toolFrame;
    string[] transformPara;
	// Use this for initialization
	void Start () {
           worldFrame = GameObject.Find("Frame");
           customFrame = GameObject.Find("customFrame");
           toolFrame = GameObject.Find("toolFrame");
           //Hide(worldFrame);
           //Hide(customFrame);
           //Hide(toolFrame);
           HideWorld();
           HideCustom();
           HideTool();
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


    void TransformToolFrame(object val)
    {
        float f = (float)System.Convert.ToDouble(string.Format("{0}", val));
        f *= 0.1f;
        toolFrame.SetActive(true);
        toolFrame.transform.Translate(Vector3.up * -moveTool, Space.Self);
        moveTool = f;
        toolFrame.transform.Translate(Vector3.up * f, Space.Self);

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
        //this.transform.Rotate(-90, 0, 0);
        //this.transform.Rotate(0, 0, 90);
        customFrame.transform.Rotate(Vector3.up * float.Parse(transformPara[5]), Space.World);
        customFrame.transform.Rotate(Vector3.forward * float.Parse(transformPara[4]), Space.World);
        customFrame.transform.Rotate(Vector3.right * float.Parse(transformPara[3]), Space.World);
        customFrame.SetActive(false);



    }
}
