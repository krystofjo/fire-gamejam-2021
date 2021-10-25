using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider otherColider) {
        if(otherColider.tag == "HomePointBorder") {
            Debug.Log("Border crossed");
        }
    }

}
