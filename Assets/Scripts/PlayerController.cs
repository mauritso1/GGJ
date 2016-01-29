using UnityEngine;
using System.Collections;
using XboxCtrlrInput;	

public class PlayerController : MonoBehaviour {
	private Vector3 newPosition;
	private bool interaction_available;
	private Collider interaction_object;

	public Transform target;

	public float turnSpeed;
	public float speed;
	public float maxMoveSpeed;

	public int playerNumber = 0;

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

		// Check for interaction 
		if (interaction_available && XCI.GetButton (XboxButton.X, playerNumber)) {
			interaction_object.gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("interactable")) {
			interaction_available = true;
			interaction_object = other;
		}
		else {
			interaction_available = true;
		}
	}
}

