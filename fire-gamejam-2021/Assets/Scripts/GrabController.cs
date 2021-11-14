using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{   
    public string input;
    public bool  canGrab;
    public GameObject objectToGrab;
    public GameObject grabbedObject;


    public Vector3 dropPosition = new Vector3(0f, -2.5f, 5f);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float buttonPressed = Input.GetAxis(input);
        if(buttonPressed == 1) {
            if (grabbedObject == null && objectToGrab != null) {
                grabbedObject = objectToGrab;
                objectToGrab.transform.parent = this.gameObject.transform;
                grabbedObject.GetComponent<GrabbableObject>().isGrabbed = true; 
                grabbedObject.transform.localPosition = grabbedObject.GetComponent<GrabbableObject>().grabbedPosition;
                grabbedObject.transform.rotation = Quaternion.Euler(grabbedObject.GetComponent<GrabbableObject>().grabbedRotation);
            }
        }
        if(buttonPressed == 0) {
            if(grabbedObject != null) {
                grabbedObject.GetComponent<GrabbableObject>().isGrabbed = false; 
                grabbedObject.transform.rotation = new Quaternion(0,0,0,0);
                grabbedObject.transform.localPosition = dropPosition;
                objectToGrab.transform.parent = GameObject.Find("Grabbables").transform;
                grabbedObject = null;
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "GrabbableObject") {
            canGrab = true;
            objectToGrab = collider.gameObject;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "GrabbableObject") {
            canGrab = false;
            objectToGrab = null;
        }
    }
}
