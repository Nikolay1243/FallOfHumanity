using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public void Quit () {

		Application.Quit();

	}

	
	public void StartGame () {

		Application.LoadLevel ("Game");

	}

}
