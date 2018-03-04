using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameController : MonoBehaviour {


	public GameObject enemyRight;
	public GameObject enemyLeft;

	public Vector3 spawnValues;
	public int hazardCount;

	public float spawnWaitRight;
	public float spawnWaitLeft;

	public float startWaitRight;
	public float startWaitLeft;

	public float waveWaitRight;
	public float waveWaitLeft;

	public Text scoreText;
	public Text gameOverText;
	public Text restartText;

	private bool gameOver;
	private bool restart;
	private int score;



	// Use this for initialization
	void Start () {
		gameOver = false;
		restart = false;
		score = 0;
		gameOverText.text = "";
		restartText.text = "";
		SetCountText ();
		StartCoroutine (SpawnWavesRight ());
		StartCoroutine (SpawnWavesLeft ());

	}
	
	// Update is called once per frame
	void Update () {
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	void SetCountText() {
		scoreText.text = "Score: " + score.ToString ();
	}

	IEnumerator SpawnWavesRight() {

		yield return new WaitForSeconds(startWaitRight);

		while (true) {
			for (int i = 0; i < hazardCount; i++) {

				Vector3 spawnPosition = new Vector3 (-spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemyRight, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWaitRight);
			}
			yield return new WaitForSeconds (waveWaitRight);

			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}

	}

	IEnumerator SpawnWavesLeft() {

		yield return new WaitForSeconds (startWaitLeft);

		while (true) {
			for (int i = 0; i < hazardCount; i++) {

				Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemyLeft, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWaitLeft);
			}
			yield return new WaitForSeconds (waveWaitLeft);

			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		SetCountText ();
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
