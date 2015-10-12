using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	int score;
	// Use this for initialization
	void Start () {

		score = 0;

	}
	
	// Update is called once per frame
	void Update () 
	{
		PlayerPrefs.SetInt("Player Score", score);

		if (score < 0) {
			score = 0;
		}



	}

	void ChangeScore(int amount)
	{
		score += amount;
	}
}
