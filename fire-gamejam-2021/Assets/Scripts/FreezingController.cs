using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreezingController : MonoBehaviour
{

    public float initialTime = 100;
    public float timeLeft;
    public float freezingSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = initialTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0) {
            timeLeft -= freezingSpeed * Time.deltaTime;
            if(timeLeft > initialTime) {
                LoadWin();
            }
        } else {
            timeLeft = 0;
        }

        if(timeLeft == 0) {
            LoadFailure();
        }

    }

    public void LoadFailure() 
    {
        Debug.Log("FAILED");
        LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadWin() 
    {
        Debug.Log("Win");
        LoadNextScene(SceneManager.GetActiveScene().buildIndex + 3);
    }


    public void LoadNextScene(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }


}
