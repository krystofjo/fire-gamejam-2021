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
            dialogueManager.PlayShelterTalk(3);
        };
        if(homePoints == 2) {
            dialogueManager.PlayShelterTalk(4);
        };
        if(homePoints == 3) {
            dialogueManager.PlayShelterTalk(5);
        };

        if(homePoints == homePointsNeeded-1) 
        {
            cottageLight.GetComponent<MeshRenderer>().enabled = true;
            dialogueManager.PlayShelterTalk(7);
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
