using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {

    public GameObject missilePrefab;
    GameObject[] missileArray;

    public GameObject[] citiesArray;

	void Start () 
    {

        missileArray = new GameObject[5];

        for(int i=0;i<missileArray.Length;i++)
        {
            missileArray[i] =(GameObject) Instantiate(missilePrefab, new Vector3((i * 3f)-6, 6.5f, -0.5f), Quaternion.identity);
        }

        PointToTarget();
        

	}
	
	void Update () 
    {
        for (int i = 0; i <= 4; i++)
        {
            Vector3 forward = missileArray[i].transform.TransformDirection(Vector3.forward) * 20;
            Debug.DrawRay(missileArray[i].transform.position, forward, Color.green);
        }
	}
    
    void PointToTarget()
    {


        for(int i=0;i<missileArray.Length;i++)
        {
            int randomcity=Random.Range(0, citiesArray.Length);
            missileArray[i].transform.LookAt(citiesArray[randomcity].transform);
            Vector3 forward = missileArray[i].transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(missileArray[i].transform.position, forward, Color.green);

            StartCoroutine(MoveTowardsTarget(missileArray[i], missileArray[i].transform, citiesArray[randomcity].transform.position, 10000.0f));
        }

    }

    void MoveTowardsTarget()
    {
        for (int i = 0; i < missileArray.Length; i++)
        {
            int randomcity = Random.Range(0, citiesArray.Length);
            missileArray[i].transform.LookAt(citiesArray[randomcity].transform);
            Vector3 forward = missileArray[i].transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(missileArray[i].transform.position, forward, Color.green);
        }
    }


    IEnumerator MoveTowardsTarget(GameObject missile, Transform startMarker, Vector3 endMarker, float speed = 1.0F)
    {
        float totalDistance;
        float t = 0.0f;

        totalDistance = Vector3.Distance(startMarker.position, endMarker);
        while (t <= 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / speed);
            missile.transform.position = Vector3.Lerp(startMarker.transform.position, endMarker, (float)t);
            //rocket.transform.LookAt(endMarker, new Vector3(0f, 0f, 1f));
            yield return 0;
        }
    }
}
