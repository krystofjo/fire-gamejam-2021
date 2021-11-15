using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    public bool isGrabbed = false;
    public bool isStone = false;
    public bool isStick = false;
    public bool isTinder = false;
    public string stoneName = "";
    public int stickPower = 0;

    public Vector3 grabbedPosition = new Vector3 (0, 0, 0);
    public Vector3 grabbedRotation = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
