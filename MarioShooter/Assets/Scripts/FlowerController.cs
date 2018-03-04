using UnityEngine;
using System.Collections;

public class FlowerController : MonoBehaviour {

	public Animator animator;
	public float desiredSpeed;
	private int index;
	public float waitSpan;
	private float waitTime;

	[SerializeField]
	private BoxCollider2D[] Colliders;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		animator.speed = desiredSpeed;
		index = 0;
		waitTime = waitSpan;
		Colliders [0].enabled = true;
		Colliders [1].enabled = false;
		Colliders [2].enabled = false;
		Colliders [3].enabled = false;
		Colliders [4].enabled = false;
		Colliders [5].enabled = false;
		Colliders [6].enabled = false;
		Colliders [7].enabled = false;
		Colliders [8].enabled = false;
		Colliders [9].enabled = false;
	}

	// Update is called once per frame
	void Update () {

		if (index < 9) {
			if (Time.time > waitTime) {

				Colliders [index].enabled = false;
				index++;
				Colliders [index].enabled = true;
				waitTime = Time.time + waitSpan;
			}
		}
	}
}
