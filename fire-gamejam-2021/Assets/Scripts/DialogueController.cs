using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{   
    public string startTalk = null;
    public float talkTimer = 0;
    private GameObject currentAudioObject;
    private GameObject leftHand;
    private GameObject rightHand;
    public GameObject[] fireAudios;
    public string[] fireText;
    public GameObject[] shelterAudios;
    public string[] shelterText;


    // Start is called before the first frame update
    void Start()
    {
        leftHand = GameObject.FindGameObjectWithTag("HandLeft");
        rightHand = GameObject.FindGameObjectWithTag("HandRight");
    }

    // Update is called once per frame
    void Update()
    {
        if(talkTimer > 0) {
            talkTimer -= 1 * Time.deltaTime;
        }   
        switch (startTalk)
        {
            case "1.1.L":
                StartTalking(fireAudios[0], true, 2.2f);
                break;
            case "1.1.R":
                StartTalking(fireAudios[1], false, 5.8f);
                break;
            case null:
                break;
        }

        if(talkTimer < 0) {
            StopTalking();
        }
    }

    void StartTalking(GameObject audioObject, bool L, float seconds) {
        GameObject hand;
        if(L) {
            hand = leftHand;
        } else hand = rightHand;

        currentAudioObject = Instantiate(audioObject, hand.transform.position, hand.transform.rotation);
        currentAudioObject.transform.parent = hand.transform;

        startTalk = null;
        talkTimer = seconds;
    }
    void StopTalking() {
        Destroy(currentAudioObject);
        talkTimer = 0;
    }


}
