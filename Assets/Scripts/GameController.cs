using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public bool paused;
	public Text ScoreText;
	public Text PausedText;
	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
		PausedText.text = "";
	}

	public void PauseUnPause () {
		paused = !paused;
		if (paused) {
			Time.timeScale = 0;
			PausedText.text = "Game Paused";
		}
		if (!paused) {
			Time.timeScale = 1;
			PausedText.text = "";
		}
	}

	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		if (paused) {
			Debug.Log ("Paused");
		}
		score += 1;
		ScoreText.text = "Score: "+ score.ToString ();

	}
}
