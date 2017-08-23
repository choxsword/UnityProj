using UnityEngine;
using System.Collections;

public class joint3 : MonoBehaviour {

    public float J3 = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Add();
        transform.localRotation = Quaternion.Euler(0, 0, J3);
    }

    void Add()
    {
        J3 = J3 + 1;
    }
    void Minus()
    {
        J3 = J3 - 1;
    }

  public  void SetJ(object val)
    {
        J3 = (float)System.Convert.ToDouble(string.Format("{0}", val));
    }
}
