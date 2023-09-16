using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    public float startTime;
    public float currentTime;

    private int score;

    void Start()
    {
        startTime = Time.time;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time - startTime;
        score = Mathf.FloorToInt(currentTime);



        //P‰ivit‰ Pistem‰‰r‰ teksti
        if(scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        
    }
}
