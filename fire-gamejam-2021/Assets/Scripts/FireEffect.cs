﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
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

    void OnTriggerEnter(Collider otherColider) 
    {
        float fireIntensity;
        if(otherColider.tag == "Fire") {
            fireIntensity = otherColider.gameObject.GetComponent<FireController>().fireIntesity;
            freezingController.freezingSpeed -= fireIntensity;
        }
    }
    void OnTriggerExit(Collider otherColider)
    {
        float fireIntensity;
        if(otherColider.tag == "Fire") {
            fireIntensity = otherColider.gameObject.GetComponent<FireController>().fireIntesity;
            freezingController.freezingSpeed += fireIntensity;
        }
    }
}
