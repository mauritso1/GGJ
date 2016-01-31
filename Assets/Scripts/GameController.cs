using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public bool paused;
	public Text ScoreText;
	public Text PausedText;
	private int score;

	private float time = 0f;
	private float arrivalInterval = 60f; // 60 seconden verwachtingswaarde
	private float minInterval = 30f;  // verstoort wel de verwachtingswaarde
	private float next = 0f;

	// Use this for initialization
	void Start () {
		score = 0;
		PausedText.text = "";
		time = Time.time;

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

		// check if a car should arrive
		if (time > next) {
			SpawnCoffin();
			next = Random.Range(0.001f,0.999f);
			next = - arrivalInterval * Mathf.Log(1 - next);
			next = Mathf.Max(minInterval, next);
			Debug.Log(next);
			next += time;
		}
		time += Time.fixedDeltaTime;
	}

	public void SpawnCoffin() {
		Debug.Log("spawn coffin");


	}
}
