using UnityEngine;
using System.Collections;

namespace DigitalRuby.PyroParticles
{
    public class MakeExplosion : MonoBehaviour
    {
        public GameObject[] Prefabs;

        private GameObject prefabObject;
        private FireBaseScript prefabScript;
        private int currentPrefabIndex;


        public void CreateExplosion(Vector3 pos)
        {
        
            prefabObject = GameObject.Instantiate(Prefabs[0]);
            prefabScript = prefabObject.GetComponent<FireBaseScript>();

   
            prefabObject.transform.position = pos;
            prefabObject.transform.rotation = Quaternion.identity;
            
        }


    }
}