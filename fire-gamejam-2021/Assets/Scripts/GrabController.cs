using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{   
    public string input;
    public GameObject grabbedObject;
    public GameObject canGrab;

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
                Debug.Log("Can Grab" + input);
            canGrab.transform.parent = this.gameObject.transform;
            if (grabbedObject == null) {
                grabbedObject = canGrab;
                grabbedObject.GetComponent<GrabbableObject>().isGrabbed = true; 
                grabbedObject.transform.position = this.gameObject.transform.position;
                grabbedObject.transform.rotation = Quaternion.Euler(grabbedObject.GetComponent<GrabbableObject>().grabbedRotation);
            }
        }
        if(buttonPressed == 0) {
            if(grabbedObject != null) {
                grabbedObject.GetComponent<GrabbableObject>().isGrabbed = false; 
                grabbedObject.transform.rotation = new Quaternion(0,0,0,0);
                grabbedObject.transform.localPosition = dropPosition;
                canGrab.transform.parent = GameObject.Find("Grabbables").transform;
                grabbedObject = null;
            }
        }
        
    }
}
