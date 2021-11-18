using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePointsController : MonoBehaviour
{
    GameObject gameManager;
    public PlayerMoveController playerMove;
    HomePointsCounter homePointsCounter;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        homePointsCounter = gameManager.GetComponent<HomePointsCounter>();
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoveController>();
    }

    void OnTriggerExit(Collider otherColider) 
    {
        if(otherColider.tag == "Player") {
            homePointsCounter.homePoints++;
            playerMove.speed = playerMove.speed/2;
            Destroy(gameObject);
        }
    }

}
