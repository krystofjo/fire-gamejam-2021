using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezingTimer : MonoBehaviour
{
    public float timeLeft = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0) {
            timeLeft -= Time.deltaTime;
        } else {
            timeLeft = 0;
        }
    }
}
