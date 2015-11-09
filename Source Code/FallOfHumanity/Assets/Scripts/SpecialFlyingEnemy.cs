using UnityEngine;
using System.Collections;

public class SpecialFlyingEnemy : MonoBehaviour {
	Vector3 newEnemyPos;
	Vector3 enemyPos;
	
	float moveSpeed=5.0f;

    public bool isEnemyFlying = false;

    public GameObject[] flyingEnemies;
    GameObject theEnemy;

    public GameObject[] prefabs;


    void Start()
    {
        MoveFlyingEnemiesToRightSide();
    }
    
    void Update()
    {
        if (isEnemyFlying == false)
        {
            RespawnFlyingEnemies();
            theEnemy = ChooseEnemy();
            StartCoroutine(FlyTheEnemy());
        }
        

    }

    void MoveFlyingEnemiesToRightSide()
    {
        foreach (GameObject curFlyer in flyingEnemies)
        {
            if (curFlyer != null)
            {
                Vector3 thepos = curFlyer.transform.position;
                curFlyer.transform.position = new Vector3(15f, thepos.y, thepos.z);
            }
        }
    }


    GameObject ChooseEnemy()
    {
        int randomEnemy;
        do
        {
            randomEnemy = Random.Range(0, 2);
            //Debug.Log("Enemy " + randomEnemy);

        } while (flyingEnemies[randomEnemy] == null);

        


        return (flyingEnemies[randomEnemy]);
    }

    void RespawnFlyingEnemies()
    {
        if(flyingEnemies[0]==null && flyingEnemies[1]==null)//Both flying enemies are destroyed
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject newFlyingEnemy = (GameObject)Instantiate(prefabs[i], Vector3.zero, prefabs[i].transform.rotation);



                newFlyingEnemy.transform.position = Vector3.zero;
                newFlyingEnemy.transform.SetParent(this.transform, false);
                

                flyingEnemies[i] = newFlyingEnemy;


            }
            MoveFlyingEnemiesToRightSide();
        }
    }

	IEnumerator FlyTheEnemy()
	{
        isEnemyFlying = true;
        float newX;
        if (theEnemy != null)
        {
            if (enemyPos.x <= -15)//reset plane position
            {
                newX = 15;
                isEnemyFlying = false;
                enemyPos = theEnemy.transform.position;
                newEnemyPos = new Vector3(newX, enemyPos.y, enemyPos.z);

                yield return new WaitForSeconds(5);
                if (theEnemy != null)
                    theEnemy.transform.position = newEnemyPos;
            }
            else
            {
                while (enemyPos.x > -15 )
                {
                    if (theEnemy != null)
                    {
                        enemyPos = theEnemy.transform.position;
                        newX = enemyPos.x - (moveSpeed * Time.deltaTime);
                        newEnemyPos = new Vector3(newX, enemyPos.y, enemyPos.z);
                        theEnemy.transform.position = newEnemyPos;
                        yield return new WaitForSeconds(0);
                    }

                }
                isEnemyFlying = false;
            }
        }

	}

	
}
