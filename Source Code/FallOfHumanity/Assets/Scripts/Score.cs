using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour 
{
	int score;
    int highscore;

    public Text scoreText;
    public Text highScoreText;

	void Start () 
    {

		score = 0;
        scoreText.text = score.ToString();
        highscore = PlayerPrefs.GetInt("HighScore");
	}
	
	void Update () 
	{
        UpdateScore();
	}


    void UpdateScore()
    {
        if (score > highscore)
            highscore = score;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("HighScore", highscore);

        highScoreText.text = highscore.ToString();
        scoreText.text = score.ToString();
    }

	public void ChangeScore(int amount)
	{
		score += amount;
	}
}
