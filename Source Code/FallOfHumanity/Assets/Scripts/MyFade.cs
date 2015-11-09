using UnityEngine;
using System.Collections;

public class MyFade : MonoBehaviour {

	public Texture2D fadeOutTex;
	public float fadeSpeed=0.8f;

	private int drawDepth=-10000;
	private float myAlpha=1f;
	private int fadeDir=-1; //-1 fade in,1 fade out

	void OnGUI()
	{
		myAlpha+=fadeDir*fadeSpeed*Time.deltaTime;
		myAlpha=Mathf.Clamp01(myAlpha);

		GUI.color=new Color(GUI.color.r,GUI.color.g,GUI.color.b,myAlpha);
		GUI.depth=drawDepth;
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),fadeOutTex);
	}

	public float BeginFade(int direction)
	{
		fadeDir=direction;
		return(fadeSpeed);
	}

	void OnLevelWasLoaded()
	{
		BeginFade(-1);
	}

}
