using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetector : MonoBehaviour
{
    GameObject gameManager;
    HomePointsCounter homePointsCounter;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        homePointsCounter = gameManager.GetComponent<HomePointsCounter>();
    }

    void OnTriggerEnter(Collider otherColider) 
    {
        if(otherColider.tag == "HomePointBorder") {
            homePointsCounter.homePoints++;
        }
    }

}
