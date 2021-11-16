using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffectController : MonoBehaviour
{   
    public FreezingController freezingController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnTriggerStay(Collider otherColider) 
    {
        float fireIntensity;
        if(otherColider.tag == "Fire") {
            fireIntensity = otherColider.gameObject.GetComponent<FireController>().fireIntesity;
            freezingController.freezingSpeed = 1 - fireIntensity;
        }
    }
    void OnTriggerExit(Collider otherColider)
    {
        if(otherColider.tag == "Fire") {
            freezingController.freezingSpeed = 1;
        }
    }
}
