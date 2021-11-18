using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkController : MonoBehaviour
{   

    public string input1 = "Button B";
    public string input2 = "Button L";
    public bool pyrite = false;
    public bool flint = false;
    public bool closeToTinder = false;
    public GameObject tinder;
    public GameObject fire;
    private GameObject spark;
    public GameObject sparks;
    public GameObject sparkEmitor;
    public bool sparking = false;
    public float sparkingTime = 0f;
    public float sparkingLimit = 5f;
    public bool alreadySparking = false;
    public Material burnMaterial;
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

            if((Input.GetAxis(input1)==1) && (Input.GetAxis(input2)==1))
            {
                sparking = true;

                if(closeToTinder == true && tinder!=null)
                {
                    sparkingTime += 1 * Time.deltaTime;

                    if(sparkingTime>sparkingLimit) {
                        sparkFire();
                    }
                }
            } else {
                sparking = false;
                alreadySparking = false;
                sparkingTime = 0f;
            }
        }
        if(sparking && !alreadySparking) {
            carveSpark();
            alreadySparking = true;
        }

        if(!sparking && sparkEmitor.gameObject.transform.childCount > 0) {
            Destroy(spark);
        }
    }

    void willWork()
    {
    }

    void carveSpark()
    {
        Debug.Log("Spark!");
        spark = Instantiate(sparks, sparkEmitor.transform.position, sparkEmitor.transform.rotation);
        spark.transform.parent = sparkEmitor.transform;
    }

    void sparkFire()
    {   
        Debug.Log("FIRE!");
        Instantiate(fire, tinder.transform.position, tinder.transform.rotation);
        closeToTinder = false;
        //Destroy(tinder);
        tinder.transform.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().material = burnMaterial;
        tinder.transform.GetChild(0).GetChild(1).gameObject.GetComponent<MeshRenderer>().material = burnMaterial;
        tinder.gameObject.transform.tag = "Untagged";
        tinder = null;
    }
}


