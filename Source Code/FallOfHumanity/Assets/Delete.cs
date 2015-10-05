using UnityEngine;
using System.Collections;

public class Delete : MonoBehaviour 
{

	void OnCollisionExit (Collision col)
	{
		Destroy(col.gameObject);
	}

}
