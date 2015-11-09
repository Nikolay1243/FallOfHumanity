using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScoreManager : MonoBehaviour {

	// The map we're building is going to look like:
	//
	//	LIST OF USERS -> A User -> HighScore for that user
	//

	Dictionary< string, Dictionary<string, int> > playerScores;

	int changeCounter = 0;

	void Start() 
    {
       
        
	}

	void Init() {
		if(playerScores != null)
			return;

		playerScores = new Dictionary<string, Dictionary<string, int>>();
	}

	public void Reset() {
		changeCounter++;
		playerScores = null;
	}

	public int GetScore(string initials, string scoreType) {
		Init ();

        if (playerScores.ContainsKey(initials) == false)
        {
			// We have no score record at all for this initial
			return 0;
		}

        if (playerScores[initials].ContainsKey(scoreType) == false)
        {
			return 0;
		}

        return playerScores[initials][scoreType];
	}

    public void SetScore(string initials, string scoreType, int value)
    {
		Init ();

		changeCounter++;

        if (playerScores.ContainsKey(initials) == false)
        {
            playerScores[initials] = new Dictionary<string, int>();
		}

        playerScores[initials][scoreType] = value;
	}

    public void ChangeScore(string initials, string scoreType, int amount)
    {
		Init ();
        int currScore = GetScore(initials, scoreType);
        SetScore(initials, scoreType, currScore + amount);
	}

	public string[] GetPlayerInitials() {
		Init ();
		return playerScores.Keys.ToArray();
	}
	
	public string[] GetPlayerInitials(string sortingScoreType) {
		Init ();

		return playerScores.Keys.OrderByDescending( n => GetScore(n, sortingScoreType) ).ToArray();
	}

	public int GetChangeCounter() {
		return changeCounter;
	}

	public void DEBUG_INITIAL_SETUP() {
        SetScore("NVD", "Score", PlayerPrefs.GetInt("HighScore"));
		SetScore("HJG", "Score", 9001);
		SetScore("AAS", "Score", 1000);
		SetScore("AAA", "Score", 0003);
		SetScore("BBB", "Score", 0002);
		SetScore("CCC", "Score", 0001);
		
		
		Debug.Log (GetScore("NVD", "Score") );
	}

}
