using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DestroyCollision : MonoBehaviour 
{
    Score scoreScript;
    SpecialFlyingEnemy flyerScript;

    void Start()
    {
        scoreScript = GameObject.FindGameObjectWithTag("Scripts").GetComponent<Score>();
        flyerScript = GameObject.FindGameObjectWithTag("Flyer").GetComponent<SpecialFlyingEnemy>();
   
    }
    void OnTriggerEnter(Collider other)
    {
        Camera.main.gameObject.GetComponent<CameraShake>().shake = 1;

        if (other.tag == "Missile")
            scoreScript.ChangeScore(10);

        if (other.tag == "Plane" || other.tag == "Satellite")
        {
            if (other.tag == "Plane")
                scoreScript.ChangeScore(50);
            if (other.tag == "Satellite")
                scoreScript.ChangeScore(100);

            flyerScript.isEnemyFlying = false;

        }

        Destroy(other.gameObject);

    }
}
