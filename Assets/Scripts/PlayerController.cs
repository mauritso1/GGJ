using UnityEngine;
using System.Collections;
using XboxCtrlrInput;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {
	public bool paused;
	public int playerNumber;
	public Transform target;
	private Vector3 direction;
	private bool interaction_available = false;
	private bool can_interact = true;
	private Collider interaction_object;
	private Iinteractable interaction_gameobject;
	public float turnSpeed;
	public float moveSpeed;
	public Text pausedText;
	private Transform door1;
	private Transform door2;
	private bool door_open;
	public int giveObject;
	public float jumpForce;
	public bool shoveling = false;
		
	Animator Ani;

	public float smooth = 2.0F;

	Rigidbody RB;

	private float pause_timeout;
	public GameController gc;
	private Vector3 newPosition;

	// Use this for initialization
	void Start () {
		Ani=transform.GetChild(0).transform.GetComponent<Animator>();
		Ani.SetBool("Lopend", false);
		RB = this.transform.GetComponent<Rigidbody> ();

		gc = GameObject.Find ("GameController").GetComponent<GameController> ();
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

		// Jump
		if(XCI.GetButton (XboxButton.A, playerNumber)){
			Ray ray = new Ray(transform.position + Vector3.up, Vector3.down);
			Debug.DrawRay(ray.origin, ray.direction);
			if (Physics.Raycast(ray,1f)) {
				if (transform.localPosition.y < -2.37f) {
					RB.AddForce(Vector3.up*5*jumpForce);
				} else {
					RB.AddForce(Vector3.up*jumpForce);
				}
			}

		}

		// Walk animation
		if(dirX!=0 && dirZ!=0){
			Ani.SetBool("Lopend", true);
		}else{
			Ani.SetBool("Lopend", false);
		}

		// Hold animation
		if (!can_interact && !shoveling) {
			Ani.SetBool("Dragend", true);
		}else{
			Ani.SetBool("Dragend", false);
		}

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
		interaction_object = other;
		if (other.gameObject.CompareTag("interactable")) {
			if (can_interact) {
				interaction_available = true;
				interaction_gameobject = other.GetComponent<Iinteractable>();
			}
		}
		if (other.gameObject.CompareTag("zombie")) {
			Debug.Log ("Game over");
			pausedText.text = "Game over";
		}

		if (other.gameObject.CompareTag ("door")) {
			
			door1 = other.gameObject.transform.GetChild (0);
			door2 = other.gameObject.transform.GetChild (1);
	
			if (door_open == false) {
				
				door1.GetComponent<DoorScript>().Open();
				door2.GetComponent<DoorScript>().Open();
				door_open = !door_open;
			}
		}
	}

	void OnTriggerExit(Collider other) {
			interaction_available = false;

			if (other.gameObject.CompareTag ("door")) {
			door1 = other.gameObject.transform.GetChild (0);
			door2 = other.gameObject.transform.GetChild (1);

			if (door_open == true) {
				door1.GetComponent<DoorScript>().Close();
				door2.GetComponent<DoorScript>().Close();
				door_open = !door_open;
			}

		}
	}
}

