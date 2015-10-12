using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour 
{
	
	public GameObject bulletprefab;
    public Camera theCamera;
    public GameObject[] rocketHills;

    void Start()
    {
        
    }

	void Update () 
    {
		if (Input.GetMouseButtonDown(0)) 
		{

            //rotation x=13
            //position y=2.5
            theCamera.transform.position = new Vector3( 0.0f,0.0f,-10.0f);
            theCamera.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f,0.0f);

			Vector3 position = theCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,-0.5f));
            position.z = -0.5f;
            Debug.Log("mouse x and y: " + position);

            if (Input.mousePosition.y >= 100)
            {
                StartCoroutine(FireRocket(rocketHills[0], rocketHills[0].transform, position, 1.0f));
               
            }
            theCamera.transform.position = new Vector3(0.0f, 2.5f, -10.0f);
            theCamera.transform.rotation = Quaternion.AngleAxis(13.0f, new Vector3(1.0f, 0.0f, 0.0f));
		}

	}

    IEnumerator FireRocket(GameObject rocketHill, Transform startMarker, Vector3 endMarker, float speed = 1.0F)
    {

        GameObject bullet = Instantiate(bulletprefab, new Vector3(0.0f, 0.0f, -0.5f), Quaternion.identity) as GameObject;

        float totalDistance;
        float t = 0.0f;

        totalDistance = Vector3.Distance(startMarker.position, endMarker);        

        while (t <= 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / speed);
            bullet.transform.position = Vector3.Lerp(startMarker.transform.position, endMarker, (float)t);
            Debug.Log(bullet.transform.position);
            Debug.Log("t: " + t);
            yield return 0;
        }

        

    }

}