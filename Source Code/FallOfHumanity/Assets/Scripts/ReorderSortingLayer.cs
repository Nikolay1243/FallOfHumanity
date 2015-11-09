using UnityEngine;
using System.Collections;

public class ReorderSortingLayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<TrailRenderer>().sortingLayerName = "Particle";
        GetComponent<TrailRenderer>().sortingOrder = 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
