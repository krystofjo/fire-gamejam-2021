using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookController : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    
    public Transform playerBody;
    public Transform playerCamera;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rightArrow = Input.GetAxis("Horizontal 2") * mouseSensitivity * Time.deltaTime;
        float upArrow = Input.GetAxis("Vertical 2") * mouseSensitivity * Time.deltaTime;

        xRotation -= upArrow;
        xRotation = Mathf.Clamp(xRotation, -20f, 20f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * rightArrow);
    }
}
