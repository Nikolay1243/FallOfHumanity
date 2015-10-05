using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	public GameObject bulletprefab;
	float distance = 10.0f;
	float bulletLife = 6.0f;

	void Update () {

		if (Input.GetMouseButtonDown(0)) 
		{
			
			Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
			position = Camera.main.ScreenToWorldPoint(position);
			GameObject bullet = Instantiate(bulletprefab, this.transform.position, Quaternion.identity) as GameObject;
			this.transform.LookAt(position);    
			    
			bullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * 1000f);
		}
	}

}