using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {

    public GameObject missilePrefab;
    GameObject[] missileArray;

    public GameObject[] citiesArray;

	void Start () 
    {

        missileArray = new GameObject[5];

        for(int i=0;i<=4;i++)
        {
            missileArray[i] =(GameObject) Instantiate(missilePrefab, new Vector3((i * 3f)-6, 4.5f, -0.5f), Quaternion.identity);
        }

        PointToCity();

	}
	
	void Update () 
    {
        for (int i = 0; i <= 4; i++)
        {
            Vector3 forward = missileArray[i].transform.TransformDirection(Vector3.forward) * 20;
            Debug.DrawRay(missileArray[i].transform.position, forward, Color.green);
        }
	}
    
    void PointToCity()
    {


        for(int i=0;i<=4;i++)
        {
            int randomcity=Random.Range(0, 5);
            missileArray[i].transform.LookAt(citiesArray[randomcity].transform);
            Vector3 forward = missileArray[i].transform.TransformDirection(Vector3.forward) * 10;
            Debug.DrawRay(missileArray[i].transform.position, forward, Color.green);
        }

        
    }
}
