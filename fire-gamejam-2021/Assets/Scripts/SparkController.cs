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
    public bool sparking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(pyrite==true && flint==true)
        {
            if((Input.GetAxis(inputA)==1) && (Input.GetAxis(inputB)==1))
            {  
                sparking = true;
            } else sparking = false;

            willWork();
            if((Input.GetAxis(inputA)==1) && (Input.GetAxis(inputB)==1))
            {
                carveSpark();
                if(closeToTinder == true)
                {
                    sparkFire();
                }
            }
        }
    }

    void willWork()
    {
    }

    void carveSpark()
    {
        Debug.Log("Spark");
    }

    void sparkFire()
    {
        Debug.Log("FIRE!!!");
    }
}


