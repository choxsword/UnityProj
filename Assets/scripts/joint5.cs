using UnityEngine;
using System.Collections;

public class joint5 : MonoBehaviour {

    public float J5 = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.localRotation = Quaternion.Euler(0, 0, J5);
    }

    void Add()
    {
        J5 = J5 + 1;
    }
    void Minus()
    {
        J5 = J5 - 1;
    }

   public  void SetJ(object val)
    {
        J5 = (float)System.Convert.ToDouble(string.Format("{0}", val));
    }
}
