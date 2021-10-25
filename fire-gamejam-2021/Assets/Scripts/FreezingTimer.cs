using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreezingTimer : MonoBehaviour
{
    public Animator transition;


    public float transitionTime = 1f;

    public float timeLeft = 100;
    public float freezingSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0) {
            timeLeft -= freezingSpeed * Time.deltaTime;
        } else {
            timeLeft = 0;
        }

        if(timeLeft == 0) {
            LoadFailure();
        }

    }

    public void LoadFailure() {
        Debug.Log("FAILED");
        LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadNextScene(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
