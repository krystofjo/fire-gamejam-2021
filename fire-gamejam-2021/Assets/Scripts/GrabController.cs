using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{   
    public string handAnimatorName;
    public bool leftHand;
    public GrabController otherHand;
    public string input;
    public string input2;
    public bool canGrab;
    public bool isGrabbing;
    private Animator animator;
    public GameObject objectToGrab;
    public GameObject grabbedObject;
    private GameObject gameManager;
    public bool isSparking; 

    public Vector3 dropPosition = new Vector3(0f, -2.5f, 5f);
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        animator = GameObject.Find(handAnimatorName).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis(input) == 1) {
            if (grabbedObject == null && objectToGrab != null && objectToGrab.gameObject.GetComponent<GrabbableObject>().isGrabbed==false) {
                isGrabbing = true;
                canGrab = false;
                grabbedObject = objectToGrab;
                objectToGrab.transform.parent = this.gameObject.transform;
                grabbedObject.GetComponent<GrabbableObject>().isGrabbed = true;
                if(leftHand) {
                    grabbedObject.transform.localPosition = grabbedObject.GetComponent<GrabbableObject>().grabbedPosition;
                    grabbedObject.transform.localRotation = Quaternion.Euler(grabbedObject.GetComponent<GrabbableObject>().grabbedRotation);
                } else {
                    grabbedObject.transform.localPosition = grabbedObject.GetComponent<GrabbableObject>().grabbedPositionRight;
                    grabbedObject.transform.localRotation = Quaternion.Euler(grabbedObject.GetComponent<GrabbableObject>().grabbedRotationRight);
                }
                

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
        if(Input.GetAxis(input) == 0) {
            if(grabbedObject != null) {
                DropObject();
            }
        }

        if(Input.GetAxis(input2) == 1) 
        { 
            isSparking = true;
            if(leftHand)
            {
                animator.SetBool("sparkDown", true);
                if(grabbedObject!=null) {
                grabbedObject.transform.parent = GameObject.FindGameObjectWithTag("HandAnchorLeft").transform;
                }
            } else {
                animator.SetBool("sparkUp", true);
                if(grabbedObject!=null) {
                grabbedObject.transform.parent = GameObject.FindGameObjectWithTag("HandAnchorRight").transform;
                }
            }
        }
        if(Input.GetAxis(input2) == 0) 
        {
            if(leftHand)
            {
                animator.SetBool("sparkDown", false);
                if(grabbedObject!=null) {
                    grabbedObject.transform.parent = GameObject.FindGameObjectWithTag("HandLeft").transform;
                }
            } else {
                animator.SetBool("sparkUp", false);
                if(grabbedObject!=null) {
                    grabbedObject.transform.parent = GameObject.FindGameObjectWithTag("HandRight").transform;
                }
            }
            if(grabbedObject != null && isSparking) {
                DropObject();
                isSparking = false;
            }
        }
        UpdateAnimations();
    }


    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "GrabbableObject" && collider.gameObject.GetComponent<GrabbableObject>().isGrabbed==false && isGrabbing==false)
        {   
            if(collider.gameObject != otherHand.grabbedObject){
                canGrab = true;
                objectToGrab = collider.gameObject;
            }
        }

        if(collider.gameObject == otherHand.grabbedObject)
        {
            canGrab = false;
            objectToGrab = null;
        }

        if(collider.gameObject.name == "Tinder") {
            gameManager.GetComponent<SparkController>().closeToTinder = true;
            gameManager.GetComponent<SparkController>().tinder = collider.gameObject;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "GrabbableObject") { 
            canGrab = false;
            objectToGrab = null;
        }

        if(collider.gameObject.name == "Tinder") {
            gameManager.GetComponent<SparkController>().closeToTinder = false;
            gameManager.GetComponent<SparkController>().tinder = null;
        }
    }

    void UpdateAnimations() 
    {
        if(canGrab){
            animator.SetBool("canGrab", true);
        } else {animator.SetBool("canGrab", false);}

        if(isGrabbing){
            animator.SetBool("isGrabbing", true);
        } else {animator.SetBool("isGrabbing", false);}

    }

    void DropObject()
    {  
        isGrabbing = false;
        grabbedObject.transform.localPosition = dropPosition;

        if(grabbedObject.GetComponent<GrabbableObject>().stoneName == "flint") 
        {
            gameManager.GetComponent<SparkController>().flint = false;
        }
        if(grabbedObject.GetComponent<GrabbableObject>().stoneName == "pyrite") 
        {
            gameManager.GetComponent<SparkController>().pyrite = false;
        }
        grabbedObject.GetComponent<GrabbableObject>().isGrabbed = false; 
        grabbedObject.transform.parent = GameObject.Find("Grabbables").transform;
        grabbedObject.transform.rotation = Quaternion.Euler(0,Random.Range(0f, 360f),0);
        grabbedObject = null;
        objectToGrab = null;

    }
}
