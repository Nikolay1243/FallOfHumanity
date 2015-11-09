using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputBehaviours : MonoBehaviour {

    public ScoreManager scoreManager;
    public Text theInitials;
    public GameObject scorelistobj;
    public GameObject restartext;
	// Use this for initialization
	void Start () 
    {
        Cursor.visible = true;
        scoreManager.DEBUG_INITIAL_SETUP();
        InputOrTable();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void InputOrTable()
    {
        Debug.Log("HI " + PlayerPrefs.GetInt("HighScore") + " Low " + PlayerPrefs.GetInt("Score"));
        if(PlayerPrefs.GetInt("HighScore")==PlayerPrefs.GetInt("Score"))
        {
            //Show input
            this.gameObject.SetActive(true);
            scorelistobj.SetActive(false);
            restartext.SetActive(false);

        }
        else
        {
            //ShowTable
            this.gameObject.SetActive(false);
            scorelistobj.SetActive(true);
            restartext.SetActive(true);
        }
    }
    public void RegisterHighScore()
    {
        scoreManager.SetScore(theInitials.text, "Score", PlayerPrefs.GetInt("HighScore"));
        
        PlayerPrefs.SetInt("Score", 0);
    }
}
