using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class StartScript : MonoBehaviour {
	
	public Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText.text = "Protect your growing plant by destroying the flying goombas! Use the arrow keys to move and the space bar to shoot. \n\n" +
			"Press 'space' to start";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Application.LoadLevel (1);
		}

	}
}
