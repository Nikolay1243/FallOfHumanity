using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	public GameObject prefab;
	float distance = 10.0f;
	float bulletLife = 6.0f;

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown(0)) {
			
			Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
			position = Camera.main.ScreenToWorldPoint(position);
			GameObject go = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
			go.transform.LookAt(position);    
			Debug.Log(position);    
			go.GetComponent<Rigidbody>().AddForce(go.transform.forward * 1000f);
		}
	
		Destroy(GameObject.Find("Sphere(Clone)"), 5);
	}

}