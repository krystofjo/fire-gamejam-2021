using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{

    public float fireIntesity = 0.2f;
    public float fireInitialTime = 20;
    public float fireTimeLeft;
    public float burnOutSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        fireTimeLeft = fireInitialTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(fireTimeLeft > 0) {
            fireTimeLeft -= burnOutSpeed * Time.deltaTime;
        }
    }
}
