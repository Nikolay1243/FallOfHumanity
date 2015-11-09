using UnityEngine;
using System.Collections;

public class MissileHitTarget : MonoBehaviour {
    CameraShake cameraShakeScript;

	// Use this for initialization
	void Start () 
    {
        cameraShakeScript = Camera.main.GetComponent<CameraShake>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void GotToTarget(GameObject theTarget)
    {
        cameraShakeScript.shake = 1.0f;
        if(theTarget.tag=="City")
        {
            //Damage the city
            //Debug.Log("Parent: " +theTarget.gameObject.transform.parent);
            //GameObject City1 = GameObject.Find("City1");
            //Debug.Log(City1);
            theTarget.transform.parent.GetComponent<PHealth>().Hit();
            //if ()
            //{
            //    Debug.Log("Hit City1");
            //    City1.GetComponent<PHealth>().Hit();
            //}
            //else
            //{
            //    Debug.Log("Hit City2");
            //    GameObject.Find("City2").GetComponent<PHealth>().Hit();
            //}
                

        }
        else if(theTarget.tag=="Silo")
        {
            //Set the silo's counter to 0
            GameObject.FindGameObjectWithTag("RocketHills").GetComponent<RocketController>().HitSilo(theTarget);
        }

    }
}
