using UnityEngine;
using System.Collections;

public class BulletMover : MonoBehaviour {

	public int speed;

	private Rigidbody2D rb;
	private PlayerController playerController;


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();

		GameObject playerControllerObject = GameObject.FindWithTag ("Player");
		if (playerControllerObject != null)
		{
			playerController = playerControllerObject.GetComponent <PlayerController>();
		}
		if (playerController == null)
		{
			Debug.Log ("Cannot find 'PlayerController' script");
		}

		if (playerController.GetLeft()) {
			rb.velocity = (- transform.right) * speed;
		}
		else rb.velocity = transform.right * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
