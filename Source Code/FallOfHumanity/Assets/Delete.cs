using UnityEngine;
using System.Collections;

public class Delete : MonoBehaviour {

		void OnCollisionEnter (Collision col)
		{
		
				Destroy(col.gameObject);
			
		}

}
