using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public void Quit () {

		Application.Quit();

	}

	
	public void StartGame () {
       StartCoroutine(ChangeLevel("Game"));

	}
    public void HighScores()
    {
        StartCoroutine(ChangeLevel("Scoreboard"));

    }

    IEnumerator ChangeLevel(string levelName)
    {
        float fadeTime = GetComponent<MyFade>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.LoadLevel(levelName);
    }

}
