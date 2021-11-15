﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{   
    public string input;
    public bool  canGrab;
    public GameObject objectToGrab;
    public GameObject grabbedObject;
    private GameObject gameManager;


    public Vector3 dropPosition = new Vector3(0f, -2.5f, 5f);
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        float buttonPressed = Input.GetAxis(input);
        if(buttonPressed == 1) {
            if (grabbedObject == null && objectToGrab != null && objectToGrab.gameObject.GetComponent<GrabbableObject>().isGrabbed==false) {
                grabbedObject = objectToGrab;
                objectToGrab.transform.parent = this.gameObject.transform;
                grabbedObject.GetComponent<GrabbableObject>().isGrabbed = true; 
                grabbedObject.transform.localPosition = grabbedObject.GetComponent<GrabbableObject>().grabbedPosition;
                grabbedObject.transform.rotation = Quaternion.Euler(grabbedObject.GetComponent<GrabbableObject>().grabbedRotation);
                

                if(grabbedObject.GetComponent<GrabbableObject>().stoneName == "flint") 
                {
                    gameManager.GetComponent<SparkController>().flint = true;
                }

                if(grabbedObject.GetComponent<GrabbableObject>().stoneName == "pyrite") 
                {
                    gameManager.GetComponent<SparkController>().pyrite = true;
                }
            }
        }
        if(buttonPressed == 0) {
            if(grabbedObject != null) {
                if(grabbedObject.GetComponent<GrabbableObject>().stoneName == "flint") 
                {
                    gameManager.GetComponent<SparkController>().flint = false;
                }
                if(grabbedObject.GetComponent<GrabbableObject>().stoneName == "pyrite") 
                {
                    gameManager.GetComponent<SparkController>().pyrite = false;
                }
                grabbedObject.GetComponent<GrabbableObject>().isGrabbed = false; 
                grabbedObject.transform.rotation = new Quaternion(0,0,0,0);
                grabbedObject.transform.localPosition = dropPosition;
                grabbedObject.transform.parent = GameObject.Find("Grabbables").transform;
                grabbedObject = null;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "GrabbableObject") {
            canGrab = true;
            objectToGrab = collider.gameObject;
            if(objectToGrab.GetComponent<GrabbableObject>().isTinder == true)
            {   
                gameManager.GetComponent<SparkController>().closeToTinder = true;
                gameManager.GetComponent<SparkController>().tinder = objectToGrab;
            }
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "GrabbableObject") { 
            gameManager.GetComponent<SparkController>().closeToTinder = false;
            gameManager.GetComponent<SparkController>().tinder = null;
            canGrab = false;
            objectToGrab = null;
        }
    }
}
