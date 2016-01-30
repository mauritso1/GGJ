using UnityEngine;
using System.Collections;
using XboxCtrlrInput;


<<<<<<< HEAD
public class PlayerController : MonoBehaviour, Iinteractable {
	private Vector3 direction;
	private bool interaction_available = false;
	private bool can_interact = true;
	private Collider interaction_object;
	private Iinteractable interaction_gameobject;
=======
public class PlayerController : MonoBehaviour {
	public bool paused;
>>>>>>> d2f1ddd661ac91607e66e6ca69eb0f01450fd5df
	public Transform target;
	public float turnSpeed;
	public float moveSpeed;
	public int playerNumber = 0;
<<<<<<< HEAD
	Rigidbody RB;
=======
	private float pause_timeout;
>>>>>>> d2f1ddd661ac91607e66e6ca69eb0f01450fd5df

	public GameController gc;
	private Vector3 newPosition;
	private bool interaction_available = false;
	private bool can_interact = true;
	private Collider interaction_object;
	private Iinteractable interaction_gameobject;

	// Use this for initialization
	void Start () {
<<<<<<< HEAD
		RB = this.transform.GetComponent<Rigidbody>();
=======
		gc = GameObject.Find("GameController").GetComponent<GameController>();
>>>>>>> d2f1ddd661ac91607e66e6ca69eb0f01450fd5df
	}
	
	// Update is called once per frame
	void Update () {
		// (un)pause game
		if (XCI.GetButton (XboxButton.B, playerNumber) && pause_timeout <= 0) {
			gc.PauseUnPause();
			pause_timeout = 1f;
		}
		if (pause_timeout > 0) {
			pause_timeout -= 0.1f;
			Debug.Log (pause_timeout);
		}
	}

	void FixedUpdate () {
		// Get left stick input
		float axisX = XCI.GetAxis(XboxAxis.LeftStickX, playerNumber);
		float axisY = XCI.GetAxis(XboxAxis.LeftStickY, playerNumber);

		// Rotate player towards movement direction
		transform.forward = Vector3.Lerp(transform.forward, Vector3.Normalize(new Vector3(axisX, 0f, axisY)), turnSpeed);

		// Calculate and set new position
		float dirX = (axisX * moveSpeed);
		float dirZ = (axisY * moveSpeed);
		direction = new Vector3(dirX, transform.position.y, dirZ);
		RB.AddForce(moveSpeed * direction);


		// Check/trigger interaction 
		if (interaction_available && can_interact && XCI.GetButton (XboxButton.X, playerNumber)) {
			can_interact = false;
			interaction_gameobject.Interact (this);
		}

		// Check/trigger the end of the interaction
		if (!can_interact && !(XCI.GetButton (XboxButton.X, playerNumber))) {
			interaction_gameobject.StopInteract (this);
			can_interact = true;
		}
			
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log(other.gameObject);
		if (other.gameObject.CompareTag("interactable") && can_interact) {
			interaction_available = true;
			interaction_gameobject = other.GetComponent<Iinteractable>();
		}
	}

	void OnTriggerExit(Collider other) {
			interaction_available = false;
	}
}

