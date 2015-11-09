using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MissileController : MonoBehaviour {

    public GameObject missilePrefab;
    public List<GameObject> missileList;

    public GameObject[] targetsArray;

    public DigitalRuby.PyroParticles.MakeExplosion explosionScript;
    public DigitalRuby.PyroParticles.MakeFire fireScript;

    public RocketController rockContScript;

	void Start () 
    {

        missileList = new List<GameObject>();
        StartCoroutine(SpawnMissiles());

	}
    void CheckIfHitTarget()
    {
        foreach (GameObject curmiss in missileList)
        {
            if (curmiss != null)
            {
                
            }
        }
    }

    IEnumerator SpawnMissiles()
    {
        while (0 == 0)
        {
            int randomwait = Random.Range(3,5);//3,5

            yield return new WaitForSeconds(randomwait);
            CreateMissile();
        }
        
    }
    

    void CreateMissile()
    {
        //-8 and +8
        float randomX = Random.Range(-8f, 9.0f);
        GameObject newMissile = (GameObject)Instantiate(missilePrefab, new Vector3(randomX, 6.5f, -0.5f), Quaternion.identity);

        missileList.Add(newMissile);

        PointToTarget(newMissile);
        //CheckIfHitTarget();
       

    }
	
	void Update () 
    {
        
	}

    void DeleteMissile(GameObject theMissile)
    {
      
    }
    
    void PointToTarget(GameObject tarmiss)
    {
        int randomtarget = 0;
        if(rockContScript.OutOfRockets())
        {
            if (targetsArray[0].GetComponentInParent<PHealth>().damage == 3 && targetsArray[1].GetComponentInParent<PHealth>().damage < 3)
                randomtarget = 1;

            if (targetsArray[1].GetComponentInParent<PHealth>().damage == 3 && targetsArray[0].GetComponentInParent<PHealth>().damage < 3)
                randomtarget = 0;
        }
        else
        {
            randomtarget=Random.Range(0, targetsArray.Length);
        }
            



        tarmiss.transform.LookAt(targetsArray[randomtarget].transform);
        StartCoroutine(MoveTowardsTarget(tarmiss, tarmiss.transform.position, targetsArray[randomtarget], 20000.0f));
        
    }


    IEnumerator MoveTowardsTarget(GameObject missile, Vector3 startMarker, GameObject endMarker, float speed = 1.0F)
    {  
        float t = 0.0f;
        while (t < 1.0f&&missile!=null)
        {
            t += Time.time * (1 / speed);
            missile.transform.position = Vector3.Lerp(startMarker, endMarker.transform.position, (float)t);

            if(missile.transform.position==endMarker.transform.position)//Missile got to target
            {
                //Debug.Log(missile + " got to " + endMarker);
                missile.GetComponent<MissileHitTarget>().GotToTarget(endMarker);
                explosionScript.CreateExplosion(endMarker.transform.position);
                fireScript.CreateFire(endMarker.transform.position);

                missileList.Remove(missile);
                Destroy(missile);
            }
            yield return 0;
        }
    }
}
