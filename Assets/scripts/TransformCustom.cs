using UnityEngine;
using System.Collections;

public class TransformCustom : MonoBehaviour {

    GameObject obj;
    GameObject obj2;
	// Use this for initialization
	void Start () {
        obj = GameObject.Find("customFrame");
        obj2 = GameObject.Find("toolFrame");
        
	}
	
	// Update is called once per frame
	void Update () {
        //x += 1;
        //Debug.Log(x);
        //if (x == 300)
        //{
        //    TransformCustomFrame("-40 0 0 90 90 90");
        //    //TransformToolFrame(9.5f);
        //}
        //if (x == 200) deleteCustom();
        //if (x == 300)
        //{
        //    TransformCustomFrame("-40 0 0 90 90 90");
        //    TransformToolFrame(0);
        //}
       
    }

    void TransformCustomFrame(string s) {
        obj.SetActive(true);
       string[] transformPara = s.Split(' ');
        //foreach(string temp in transformPara)
        //    Debug.Log(temp);

        obj.transform.position = new Vector3(float.Parse(transformPara[0]), float.Parse(transformPara[2]), float.Parse(transformPara[1]));
        //this.transform.Rotate(-90, 0, 0);
        //this.transform.Rotate(0, 0, 90);
		obj.transform.Rotate(Vector3.up * float.Parse(transformPara[5]), Space.Self);
		obj.transform.Rotate(Vector3.forward * float.Parse(transformPara[4]), Space.Self);
        obj.transform.Rotate(Vector3.right * -float.Parse(transformPara[3]), Space.Self);


    
    }

	void deleteCustom()
    {
       
        obj.transform.position = new Vector3(0,0,0);
        //this.transform.Rotate(-90, 0, 0);
        //this.transform.Rotate(0, 0, 90);
//        obj.transform.Rotate(Vector3.up * float.Parse(transformPara[5]), Space.World);
//        obj.transform.Rotate(Vector3.forward * float.Parse(transformPara[4]), Space.World);
//        obj.transform.Rotate(Vector3.right * float.Parse(transformPara[3]), Space.World);

		obj.transform.rotation=Quaternion.identity;
        obj.SetActive(false);
		string test="world";
		Application.ExternalCall("test", test);  
       

    }


   
}
