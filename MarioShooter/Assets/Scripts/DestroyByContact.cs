using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public int scoreValue;
	private GameController gameController;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Shot")
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
			gameController.AddScore (scoreValue);
		}
		if (other.tag == "Player")
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
			gameController.GameOver ();
		}

		if (other.tag == "Flower")
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
			gameController.GameOver ();
		}

	}
}
