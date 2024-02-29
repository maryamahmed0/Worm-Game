using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1); 
    }
    public void Restart()
    {
        if(Score.ScoreNum <50)
        {
            SceneManager.LoadScene(1);
        }
        else if (Score.ScoreNum < 100) 
        {
            SceneManager.LoadScene(3);
        }

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        
        SceneManager.LoadScene(3);
    }
  

}

