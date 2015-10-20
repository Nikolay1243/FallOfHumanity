using UnityEngine;
using System.Collections;

public class DestroyCollision : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

    }
}
