using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Shot" || other.tag == "Enemy") {
			Destroy (other.gameObject);
		}
	}
}
