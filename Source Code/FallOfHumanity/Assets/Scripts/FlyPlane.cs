using UnityEngine;
using System.Collections;

public class FlyPlane : MonoBehaviour {
	Vector3 newPos;
	Vector3 thisPos;
	float newX;
	float moveSpeed=5.0f;

	IEnumerator FlyThePlane()
	{
		thisPos=this.transform.position;
		if(thisPos.x<=-10)//reset plane position
		{
			newX=10;
			newPos=new Vector3(newX,thisPos.y,thisPos.z);

			yield return new WaitForSeconds(5);
		}
		else
		{
			newX=thisPos.x-(moveSpeed*Time.deltaTime);
			newPos=new Vector3(newX,thisPos.y,thisPos.z);
		}
		
		this.transform.position=newPos;
	}

	void Update () 
	{
		StartCoroutine (FlyThePlane ());
	}
}
