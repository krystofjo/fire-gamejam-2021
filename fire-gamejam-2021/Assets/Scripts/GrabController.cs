using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{   
    public string handAnimatorName;
    public bool leftHand;
    public GrabController otherHand;
    public string input;
    public bool canGrab;
    public bool isGrabbing;
    private Animator animator;
    public GameObject objectToGrab;
    public GameObject grabbedObject;
    private GameObject gameManager;


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
        float buttonPressed = Input.GetAxis(input);
        if(buttonPressed == 1) {
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
        if(buttonPressed == 0) {
            if(grabbedObject != null) {
                isGrabbing = false;

                if(grabbedObject.GetComponent<GrabbableObject>().stoneName == "flint") 
                {
                    gameManager.GetComponent<SparkController>().flint = false;
                }
                if(grabbedObject.GetComponent<GrabbableObject>().stoneName == "pyrite") 
                {
                    gameManager.GetComponent<SparkController>().pyrite = false;
                }
                grabbedObject.GetComponent<GrabbableObject>().isGrabbed = false; 
                grabbedObject.transform.localPosition = dropPosition;
                grabbedObject.transform.parent = GameObject.Find("Grabbables").transform;
                grabbedObject.transform.rotation = Quaternion.Euler(0,Random.Range(0f, 360f),0);
                grabbedObject = null;
                objectToGrab = null;
            }
        }
        // DOCASNEEE, SMAZAT
        canGrab = true;
        isGrabbing = true;
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
}
