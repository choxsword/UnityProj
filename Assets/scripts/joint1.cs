using UnityEngine;
using System.Collections;

public class joint1 : MonoBehaviour {

   
    public float J1 = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Add();
        transform.localRotation = Quaternion.Euler(J1, -90.0f, -90f);
    }

    void Add()
    {
        J1 = J1 + 0.1f;
    }

    void AddH()
    {
        J1 = J1 + 1f;
    }

    void Minus()
    {
        J1 = J1 - 0.1f;
    }

    void MinusH()
    {
        J1 = J1 - 1f;
    }


   public void SetJ(object val) {
        J1 = (float)System.Convert.ToDouble(string.Format("{0}", val));
    }
}
