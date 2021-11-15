using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkController : MonoBehaviour
{   

    public string inputA;
    public string inputB;
    public bool pyrite = false;
    public bool flint = false;
    public bool closeToTinder = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(pyrite==true && flint==true)
        {
            Debug.Log("can spark");

            if(closeToTinder == true)
            {
                Debug.Log("CAN MAKE FIRE");
            }
        }
    }

    void canSpark()
    {

    }
}


