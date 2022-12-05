using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreTime : MonoBehaviour
{
    float score;
    public Text scoreText;
    float pointIncreasePerSecond;

    // Start is called before the first frame update
    void Awake()
    {
        if (scoreText == null)
        {
            scoreText = GetComponent<Text>();
        }

        scoreText.text = "Time Alive: ";
        pointIncreasePerSecond = 1;
    }

    // Update is called once per frame
    void Update()
    {
        score += pointIncreasePerSecond * Time.deltaTime;
        scoreText.text = "Time Alive: " + (Mathf.Round(score * 100) / 100.0) + " seconds";
    }
}