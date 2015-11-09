using UnityEngine;
using System.Collections;

namespace DigitalRuby.PyroParticles
{
    public class MakeFire : MonoBehaviour
    {
        public GameObject[] Prefabs;

        private GameObject prefabObject;
        private FireBaseScript prefabScript;
        private int currentPrefabIndex;


        public void CreateFire(Vector3 pos)
        {
        
            prefabObject = GameObject.Instantiate(Prefabs[0]);
            prefabScript = prefabObject.GetComponent<FireBaseScript>();

   
            prefabObject.transform.position = pos;
            prefabObject.transform.rotation = Quaternion.identity;
            
        }


    }
}