using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MissileController : MonoBehaviour {

    public GameObject missilePrefab;
    public List<GameObject> missileList;

    public GameObject[] citiesArray;

	void Start () 
    {

        missileList = new List<GameObject>();

        for (int i = 0; i < 5;i++ )
        {
            missileList.Add ( (GameObject)Instantiate(missilePrefab, new Vector3((i * 3f) - 6, 6.5f, -0.5f), Quaternion.identity));
        }

        PointToTarget();
        

	}
	
	void Update () 
    {
        foreach (GameObject curmiss in missileList)
        {
            Vector3 forward = curmiss.transform.TransformDirection(Vector3.forward) * 20;
            Debug.DrawRay(curmiss.transform.position, forward, Color.green);
        }
	}
    
    void PointToTarget()
    {
        foreach (GameObject curmiss in missileList)
        {
            int randomcity=Random.Range(0, citiesArray.Length);
            curmiss.transform.LookAt(citiesArray[randomcity].transform);
            Vector3 forward = curmiss.transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(curmiss.transform.position, forward, Color.green);

            StartCoroutine(MoveTowardsTarget(curmiss, curmiss.transform, citiesArray[randomcity].transform.position, 10000.0f));
        }
    }

    void MoveTowardsTarget()
    {
        foreach (GameObject curmiss in missileList)
        {
            int randomcity = Random.Range(0, citiesArray.Length);
            curmiss.transform.LookAt(citiesArray[randomcity].transform);
            Vector3 forward = curmiss.transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(curmiss.transform.position, forward, Color.green);
        }
    }


    IEnumerator MoveTowardsTarget(GameObject missile, Transform startMarker, Vector3 endMarker, float speed = 1.0F)
    {
        float totalDistance;
        float t = 0.0f;

        totalDistance = Vector3.Distance(startMarker.position, endMarker);
        while (t <= 1.0f&&missile!=null)
        {
            
            t += Time.deltaTime * (Time.timeScale / speed);
            missile.transform.position = Vector3.Lerp(startMarker.transform.position, endMarker, (float)t);
            yield return 0;
        }
    }
}
