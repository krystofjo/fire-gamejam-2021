using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePointsController : MonoBehaviour
{
    GameObject gameManager;
    HomePointsCounter homePointsCounter;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        homePointsCounter = gameManager.GetComponent<HomePointsCounter>();
    }

    void OnTriggerExit(Collider otherColider) 
    {
        if(otherColider.tag == "HomePointBorder") {
            Destroy(otherColider.gameObject);
            homePointsCounter.homePoints++;
        }
    }

}
