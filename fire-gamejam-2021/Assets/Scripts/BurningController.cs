using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningController : MonoBehaviour
{

    public GameObject fire;
    public Material burnMaterial;

    // Start is called before the first frame update
    void Start()
    {
        fire = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Burnable") {
            Debug.Log("Burnable"); 
            fire.GetComponent<FireController>().fireTimeLeft += collider.gameObject.transform.parent.GetComponent<GrabbableObject>().stickPower;
            collider.gameObject.transform.parent.tag = "Untagged";
            collider.gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = burnMaterial;
        }
    }
}
