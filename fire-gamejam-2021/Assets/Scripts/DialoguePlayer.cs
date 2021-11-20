using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePlayer : MonoBehaviour
{   
    public string startTalk = null;
    public float talkTimer = 0;
    private GameObject currentAudioObject;
    private Animator currentAnimator;
    private Transform currentTransform;
    private GrabController currentGrabController;
    private GameObject leftHand;
    private GameObject rightHand;
    public Animator leftHandAnimator;
    public GrabController leftHandGrabController;
    public Transform leftHandTransform;
    public Animator rightHandAnimator;
    public GrabController rightHandGrabController;
    public Transform rightHandTransform;
    public GameObject[] fireAudios;
    public float[] fireTalkLenght = {2.2f, 5.8f, 2.5f, 4.5f, 2.0f, 5.5f, 1.9f, 1.6f, 7.2f, 1.0f, 9.8f, 5.6f, 5.0f, 4.0f, 5.2f, 5.6f, 6.0f, 6.2f, 7.0f, 4.5f, 2.8f, 2.6f};
    public bool[] fireTalkiSLeft = {true, false, false, false, true, false, true, true, false, true, false, false, false, true, false, true, true, true, true, true, true, false};


//     Start is called before the first frame update
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

        if(talkTimer < 0) {
            StopTalking();
        }
    }

    public void StartTalking(int index, bool withAnimation) {
        GameObject audioObject = fireAudios[index];
        float seconds = fireTalkLenght[index];
        bool L = fireTalkiSLeft[index];
        GameObject hand;

        if(L) {
            hand = leftHand;
            currentAnimator = leftHandAnimator;
            currentTransform = leftHandTransform;
            currentGrabController = leftHandGrabController;
        } else {
                hand = rightHand;
                currentAnimator = rightHandAnimator;
                currentTransform = rightHandTransform;
                currentGrabController = rightHandGrabController;
        }

        currentTransform.localPosition = new Vector3(currentTransform.localPosition.x, currentTransform.localPosition.y, -1.2f);
        currentAudioObject = Instantiate(audioObject, hand.transform.position, hand.transform.rotation);
        currentAudioObject.transform.parent = hand.transform;
        
        if(withAnimation) {
            currentGrabController.canGrab = false;
            currentAnimator.SetBool("isTalking", true);
        }

        // startTalk = null;
        talkTimer = seconds;
    }
    void StopTalking() {
        currentAnimator.SetBool("isTalking", false);
        currentTransform.localPosition = new Vector3(currentTransform.localPosition.x, currentTransform.localPosition.y, -1.8f);
        Destroy(currentAudioObject);
        talkTimer = 0;
    }


}
