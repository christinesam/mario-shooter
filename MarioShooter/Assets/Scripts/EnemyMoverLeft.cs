﻿using UnityEngine;
using System.Collections;

public class EnemyMoverLeft : MonoBehaviour {

	public int speed;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = (- transform.right) * speed;
	}

	// Update is called once per frame
	void Update () {

	}
}
