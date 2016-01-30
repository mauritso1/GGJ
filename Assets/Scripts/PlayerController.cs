using UnityEngine;
using System.Collections;
using XboxCtrlrInput;


public class PlayerController : MonoBehaviour {

	public Transform target;
	public float turnSpeed;
	public float speed;
	public float maxMoveSpeed;
	public int playerNumber = 0;

	private Vector3 newPosition;
	private bool interaction_available = false;
	private bool can_interact = true;
	private Collider interaction_object;
	private Iinteractable interaction_gameobject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		// Get left stick input
		float axisX = XCI.GetAxis(XboxAxis.LeftStickX, playerNumber);
		float axisY = XCI.GetAxis(XboxAxis.LeftStickY, playerNumber);

		// Rotate player towards movement direction
		transform.forward = Vector3.Lerp(transform.forward, Vector3.Normalize(new Vector3(axisX, 0f, axisY)), turnSpeed);

		// Calculate and set new position
		float newPosX = newPosition.x + (axisX * maxMoveSpeed);
		float newPosZ = newPosition.z + (axisY * maxMoveSpeed);
		newPosition = new Vector3(newPosX, transform.position.y, newPosZ);
		transform.position = newPosition;

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

