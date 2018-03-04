using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	//public Text scoreText;
	//public Text gameOverText;
	public float fireRate;
	public GameObject shot;
	public Transform shotSpawn;

	private bool left;
	private float nextFire;

	private Rigidbody2D rb;
	private Animator animator;
	private int score;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		//score = 0;
		//gameOverText.text = "";
		//SetCountText ();
		left = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.LeftArrow)) {
			animator.SetBool("playerLeft", true);
			left = true;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			animator.SetBool ("playerLeft", false);
			left = false;
		}

		if (Input.GetKey (KeyCode.Space) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);


		rb.velocity = movement * speed;

		rb.position = new Vector2 
			(
				Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax)
			);
	}

	//void SetCountText() {
	//	scoreText.text = "Score: " + score.ToString ();
	//}

	public bool GetLeft() {
		return left;
	}
}
