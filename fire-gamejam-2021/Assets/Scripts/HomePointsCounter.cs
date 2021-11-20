using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePointsCounter : MonoBehaviour
{

    public float homePointsNeeded = 5;
    public float homePoints = 0;
    public GameObject cottageLight;
    public DialogueManager dialogueManager;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(homePoints == 1) {
            dialogueManager.PlayTalk(17, true);
        };
        if(homePoints == 2) {
            dialogueManager.PlayTalk(18,true);
        };
        if(homePoints == 3) {
            dialogueManager.PlayTalk(19, true);
        };

        if(homePoints == homePointsNeeded-1) 
        {
            cottageLight.GetComponent<MeshRenderer>().enabled = true;
            dialogueManager.PlayTalk(21, true);
        }


        if(homePoints == homePointsNeeded)
        {
            LoadWin();
        }
    }

    public void LoadWin() 
    {
        Debug.Log("Win");
        LoadNextScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void LoadNextScene(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
