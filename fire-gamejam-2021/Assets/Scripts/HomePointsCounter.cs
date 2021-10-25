using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePointsCounter : MonoBehaviour
{

    public float homePointsNeeded = 3;
    public float homePoints = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
