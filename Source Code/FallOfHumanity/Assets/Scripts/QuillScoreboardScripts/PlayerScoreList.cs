using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScoreList : MonoBehaviour {

	public GameObject playerScoreEntryPrefab;

	ScoreManager scoreManager;

	int lastChangeCounter;

	// Use this for initialization
	void Start () {
		scoreManager = GameObject.FindObjectOfType<ScoreManager>();
		lastChangeCounter = scoreManager.GetChangeCounter();
	}
	
	// Update is called once per frame
	void Update () 
    {
		if(scoreManager == null) {
			Debug.LogError("You forgot to add the score manager component to a game object!");
			return;
		}

		if(scoreManager.GetChangeCounter() == lastChangeCounter) {
			// No change since last update!
            //Debug.Log("NO CHANGE");
			return;
		}

		lastChangeCounter = scoreManager.GetChangeCounter();

        while (this.transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null);  // Become Batman
            Destroy(c.gameObject);
        }

		string[] initials = scoreManager.GetPlayerInitials("Scores");
		
		foreach(string curInitial in initials) 
        {
            int scoreLength = 6;


            Debug.Log("Creating score entry");
			GameObject go = (GameObject)Instantiate(playerScoreEntryPrefab);
			go.transform.SetParent(this.transform,false);
            go.transform.Find("Initials").GetComponent<Text>().text = curInitial;

            // score as a string
            string scoreString = scoreManager.GetScore(curInitial, "Score").ToString();
            // get number of 0s needed
            int numZeros = scoreLength - scoreString.Length;
            string newScore="";
            for(int i = 0; i < numZeros; i++){
                newScore += "0";
            }
 
            newScore += scoreString;

            go.transform.Find("Score").GetComponent<Text>().text = newScore;




		}
	}
}
