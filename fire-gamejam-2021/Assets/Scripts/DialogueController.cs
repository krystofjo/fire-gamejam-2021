using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{   
    public string startTalk = null;
    private GameObject currentAudioObject;
    private GameObject leftHand;
    private GameObject rightHand;
    public GameObject audio11L;
    public GameObject audio11R;

    // Start is called before the first frame update
    void Start()
    {
        leftHand = GameObject.FindGameObjectWithTag("HandLeft");
        rightHand = GameObject.FindGameObjectWithTag("HandRight");
    }

    // Update is called once per frame
    void Update()
    {
        if(startTalk == "1.1.R") {
            StartTalking(audio11R, false);
        }
    }

    void StartTalking(GameObject audioObject, bool L) {
        GameObject hand;
        if(L) {
            hand = leftHand;
        } else hand = rightHand;

        currentAudioObject = Instantiate(audioObject, hand.transform.position, hand.transform.rotation);
        currentAudioObject.transform.parent = hand.transform;

        startTalk = null;
    }
    void StopTalking() {

    }


}
