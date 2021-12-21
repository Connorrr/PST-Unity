using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreIncrimenter : MonoBehaviour
{
    public Text scoreText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 1;
    }

    public void incrimentScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}
