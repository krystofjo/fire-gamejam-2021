using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    
    public Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rightArrow = Input.GetAxis("Horizontal B") * mouseSensitivity * Time.deltaTime;
        float upArrow = Input.GetAxis("Vertical B") * mouseSensitivity * Time.deltaTime;

        xRotation -= upArrow;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * rightArrow);
    }
}
