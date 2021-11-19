using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePlayer : MonoBehaviour
{   
    public string startTalk = null;
    public float talkTimer = 0;
    private GameObject currentAudioObject;
    private Animator currentAnimator;
    private GameObject leftHand;
    public Animator leftHandAnimator;
    private GameObject rightHand;
    public Animator rightHandAnimator;
    public GameObject[] fireAudios;
    public string[] fireTalkCode = {"11L", "11R", "12R", "13R", "14L", "15R", "16L", "17L", "17R", "18L", "19R", "110R", "111R", "112L"};
    public GameObject[] shelterAudios;
    public string[] shelterTalkCode = {"21R", "21L", "22L", "23L", "24L", "25L", "26L", "27R"};


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
        if (startTalk==fireTalkCode[0]){
            StartTalking(fireAudios[0], true, 2.2f);
        } else if(startTalk==fireTalkCode[1]){
            StartTalking(fireAudios[1], false, 5.8f);
        } else if(startTalk==fireTalkCode[2]){
            StartTalking(fireAudios[2], false, 2.5f);
        } else if(startTalk==fireTalkCode[3]){
                StartTalking(fireAudios[3], false, 4.5f);
        } else if(startTalk==fireTalkCode[4]){
                StartTalking(fireAudios[4], true, 2.0f);
        } else if(startTalk==fireTalkCode[5]){
                StartTalking(fireAudios[5], false, 5.5f);
        } else if(startTalk==fireTalkCode[6]){
                StartTalking(fireAudios[6], true, 1.9f);
        } else if(startTalk==fireTalkCode[7]){
                StartTalking(fireAudios[7], true, 1.6f);
        } else if(startTalk==fireTalkCode[8]){
                StartTalking(fireAudios[8], false, 7.2f);
        } else if(startTalk==fireTalkCode[9]){
                StartTalking(fireAudios[9], true, 1.0f);
        } else if(startTalk==fireTalkCode[10]){
                StartTalking(fireAudios[10], false, 9.8f);
        } else if(startTalk==fireTalkCode[11]){
                StartTalking(fireAudios[11], false, 5.6f);
        } else if(startTalk==fireTalkCode[12]){
                StartTalking(fireAudios[12], false, 5.0f);
        } else if(startTalk==fireTalkCode[13]){
                StartTalking(fireAudios[13], true, 4.0f);
        } else if(startTalk==shelterTalkCode[0]){
                StartTalking(shelterAudios[0], false, 5.2f);
        } else if(startTalk==shelterTalkCode[1]){
                StartTalking(shelterAudios[1], true, 5.6f);
        } else if(startTalk==shelterTalkCode[2]){
                StartTalking(shelterAudios[2], true, 6.0f);
        } else if(startTalk==shelterTalkCode[3]){
                StartTalking(shelterAudios[3], true, 6.2f);
        } else if(startTalk==shelterTalkCode[4]){
                StartTalking(shelterAudios[4], true, 7.0f);
        } else if(startTalk==shelterTalkCode[5]){
                StartTalking(shelterAudios[5], true, 4.5f);
        } else if(startTalk==shelterTalkCode[6]){
                StartTalking(shelterAudios[6], true, 2.8f);
        } else if(startTalk==shelterTalkCode[7]){
                StartTalking(shelterAudios[7], false, 2.6f);
        }

        if(talkTimer < 0) {
            StopTalking();
        }
    }

    void StartTalking(GameObject audioObject, bool L, float seconds) {
        GameObject hand;
        if(L) {
            hand = leftHand;
            currentAnimator = leftHandAnimator;
        } else {
                hand = rightHand;
                currentAnimator = rightHandAnimator;
        }

        currentAudioObject = Instantiate(audioObject, hand.transform.position, hand.transform.rotation);
        currentAudioObject.transform.parent = hand.transform;
        currentAnimator.SetBool("isTalking", true);

        startTalk = null;
        talkTimer = seconds;
    }
    void StopTalking() {
        currentAnimator.SetBool("isTalking", false);
        Destroy(currentAudioObject);
        talkTimer = 0;
    }


}
