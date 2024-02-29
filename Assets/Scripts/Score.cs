using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int ScoreNum;
    public Text ScoreText;
    
    void Start()
    {
        ScoreText = GetComponent<Text>();
    }

    void Update()
    {
        ScoreText.text = "Score: " + ScoreNum;
    }
}
