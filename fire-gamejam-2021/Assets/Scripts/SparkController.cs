using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkController : MonoBehaviour
{   

    public string inputA = "Fire A2";
    public string inputB = "Fire B2";
    public bool pyrite = false;
    public bool flint = false;
    public bool closeToTinder = false;
    public GameObject tinder;
    public GameObject fire;
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
            willWork();

            if((Input.GetAxis(inputA)==1) && (Input.GetAxis(inputB)==1))
            {
                sparking = true;
                carveSpark();

                if(closeToTinder == true && tinder!=null)
                {
                    sparkFire();
                }
            } else sparking = false;
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
        Debug.Log("FIRE!");
        Instantiate(fire, tinder.transform.position, tinder.transform.rotation);
        closeToTinder = false;
        tinder = null;
    }
}


