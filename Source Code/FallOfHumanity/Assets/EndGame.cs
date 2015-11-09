using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour 
{
    public GameObject City1, City2;
	// Use this for initialization
	void Start () 
    {
	
	}
	
    void CheckIfCitiesDead()
    {
        if(City1.GetComponent<PHealth>().damage==3 && City2.GetComponent<PHealth>().damage==3)
            StartCoroutine(ChangeLevel("Scoreboard"));
    }

	// Update is called once per frame
	void Update () {
        CheckIfCitiesDead();
	}

  
    IEnumerator ChangeLevel(string levelName)
    {
        float fadeTime = GetComponent<MyFade>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.LoadLevel(levelName);
    }
}
