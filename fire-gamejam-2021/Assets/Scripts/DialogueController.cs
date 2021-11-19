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
        if (startTalk==fireText[0]){
            StartTalking(fireAudios[0], true, 2.2f);
        } else if(startTalk==fireText[1]){
            StartTalking(fireAudios[1], false, 5.8f);
        } else if(startTalk==fireText[2]){
            StartTalking(fireAudios[2], true, 2.5f);
        } else if(startTalk==fireText[3]){
                StartTalking(fireAudios[3], false, 5.8f);
        } else if(startTalk==fireText[4]){
                StartTalking(fireAudios[4], true, 2.2f);
        } else if(startTalk==fireText[5]){
                StartTalking(fireAudios[5], false, 5.8f);
        } else if(startTalk==fireText[6]){
                StartTalking(fireAudios[6], true, 2.2f);
        } else if(startTalk==fireText[7]){
                StartTalking(fireAudios[7], false, 5.8f);
        } else if(startTalk==fireText[8]){
                StartTalking(fireAudios[8], true, 2.2f);
        } else if(startTalk==fireText[9]){
                StartTalking(fireAudios[9], false, 5.8f);
        } else if(startTalk==fireText[10]){
                StartTalking(fireAudios[10], false, 5.8f);
        } else if(startTalk==fireText[11]){
                StartTalking(fireAudios[11], false, 5.8f);
        } else if(startTalk==fireText[12]){
                StartTalking(fireAudios[12], false, 5.8f);
        } else if(startTalk==fireText[13]){
                StartTalking(fireAudios[13], false, 5.8f);
        } else if(startTalk==shelterText[0]){
                StartTalking(shelterAudios[0], false, 5.8f);
        } else if(startTalk==shelterText[1]){
                StartTalking(shelterAudios[1], false, 5.8f);
        } else if(startTalk==shelterText[2]){
                StartTalking(shelterAudios[2], false, 5.8f);
        } else if(startTalk==shelterText[3]){
                StartTalking(shelterAudios[3], false, 5.8f);
        } else if(startTalk==shelterText[4]){
                StartTalking(shelterAudios[4], false, 5.8f);
        } else if(startTalk==shelterText[5]){
                StartTalking(shelterAudios[5], false, 5.8f);
        } else if(startTalk==shelterText[6]){
                StartTalking(shelterAudios[6], false, 5.8f);
        } else if(startTalk==shelterText[7]){
                StartTalking(shelterAudios[7], false, 5.8f);
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
