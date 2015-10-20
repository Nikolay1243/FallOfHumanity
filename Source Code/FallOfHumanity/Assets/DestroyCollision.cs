using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DestroyCollision : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        Camera.main.gameObject.GetComponent<CameraShake>().shake = 1;
        List<GameObject> missList=GameObject.FindGameObjectWithTag("Scripts").GetComponent<MissileController>().missileList;
        int i=0;

        //foreach (GameObject curmiss in missList)
        //{
        //    if(curmiss==other.gameObject)
        //        missList.RemoveAt(i);
            
        //    i++;
        //}

        Destroy(other.gameObject);
        Destroy(this.gameObject);
        
        

    }
}
