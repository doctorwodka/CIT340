using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTime : MonoBehaviour
{
    float score = 0;
    public Text scoreText;
    float pointIncreasePerSecond;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Time Alive: 0 seconds";
        pointIncreasePerSecond = 1;
    }

    // Update is called once per frame
    void Update()
    {
        score += pointIncreasePerSecond * Time.deltaTime;
        scoreText.text = "Time Alive: " + (Mathf.Round(score * 100) / 100.0) + " seconds";
    }
}