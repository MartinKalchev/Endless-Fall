using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    public Text highScore;

    private float timer;
    private int score;
    private int highscore;

    void Start()
    {


        score = 0;

        highscore = PlayerPrefs.GetInt("Highscore", highscore);
        highScore.text = "Highscore: " + highscore.ToString();
    }


    void Update()
    {

        timer += Time.deltaTime;

        if (timer > 1f)
        {

            score += 1;

            //only need to update the text if the score changed.
            ScoreText.text = "Score: " + score.ToString();

            //Reset the timer to 0.
            timer = 0;

            if (score > highscore)
            {
                highscore = score;
                highScore.text = "Highscore: " + score;

                PlayerPrefs.SetInt("Highscore", highscore);
            }
        }


    }
}

