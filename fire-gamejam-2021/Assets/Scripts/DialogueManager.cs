using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public DialoguePlayer dialoguePlayer;
    public bool[] fireAlreadyPlayed = {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};
    
    void Start()
    {
        StartCoroutine(PlayTalkAfterTime(2, 0, true));
        StartCoroutine(PlayTalkAfterTime(4.5f, 1, true));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayTalk(int index, bool withAnimation) {
        if(!fireAlreadyPlayed[index]) {
            dialoguePlayer.StartTalking(index, withAnimation);
            fireAlreadyPlayed[index] = true;
        }

    }

    IEnumerator PlayTalkAfterTime(float time, int index, bool withAnimation)
    {
        yield return new WaitForSeconds(time);
        PlayTalk(index, withAnimation);
        fireAlreadyPlayed[index] = true;
    }

}