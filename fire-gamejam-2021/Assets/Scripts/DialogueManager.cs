using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public DialoguePlayer dialoguePlayer;
    public bool[] fireAlreadyPlayed;
    public bool[] shelterAlreadyPlayed;
    public  string[] fireTalkCodes = {"11L", "11R", "12R", "13R", "14L", "15R", "16L", "17L", "17R", "18L", "19R", "110R", "111R", "112L"};
    public  string[] shelterTalkCodes = {"21R", "21L", "22L", "23L", "24L", "25L", "26L", "27R"};
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFireTalk(int index) {
        if(!fireAlreadyPlayed[index]) {
            dialoguePlayer.startTalk = fireTalkCodes[index];
            fireAlreadyPlayed[index] = true;
        }

    }
    public void PlayShelterTalk(int index) {
        if(!shelterAlreadyPlayed[index]) {
            dialoguePlayer.startTalk = shelterTalkCodes[index];
            shelterAlreadyPlayed[index] = true;
        }

    }
}
