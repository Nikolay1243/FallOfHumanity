using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour 
{
    public GameObject inputPanel;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButtonDown(0) && inputPanel.activeInHierarchy==false) 
            StartCoroutine(ChangeLevel("Game"));
    }

    IEnumerator ChangeLevel(string levelName)
    {
        float fadeTime = GetComponent<MyFade>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.LoadLevel(levelName);
    }
}
