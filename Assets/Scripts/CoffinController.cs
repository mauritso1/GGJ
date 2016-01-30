using UnityEngine;
using System.Collections;

public class CoffinController : MonoBehaviour, Iinteractable {
	public int time_variance;
	public float time_delay;

	private float timeLeft;
	private float count_down; 
	public bool zombie_active = false;

	private int nrCarriers = 0;
	private Rigidbody RB;

	public void Interact(PlayerController playercontroller){
		if (nrCarriers == 0) {
			//send a message to the player to start animation or something
			RB.isKinematic = true;

			// put in correct position
			Vector3 rightCoffin = new Vector3(transform.right.x, 0, transform.right.z).normalized;
			Vector3 forwardCoffin = new Vector3(-rightCoffin.z, 0, rightCoffin.x).normalized;
			Vector3 playerForward = new Vector3(playercontroller.transform.forward.x, 0, playercontroller.transform.forward.z).normalized;
			Vector3 carrier2coffin = new Vector3(transform.position.x - playercontroller.transform.position.x,
			                                     0,
			                                     transform.position.z - playercontroller.transform.position.z).normalized;

			float side = Vector3.Dot (carrier2coffin, rightCoffin);

			float angle = 0f;
			if (side > 0) {
				Vector3 help = new Vector3(0.7f, -1.56f, -1.1f);
				help = Quaternion.AngleAxis(180f, Vector3.up) * help;
				playercontroller.transform.position = transform.position + help;

				angle = Vector3.Angle(rightCoffin, playerForward);
				Vector3 rotDir = playerForward - rightCoffin;
				if (Vector3.Dot (rotDir, forwardCoffin) > 0) {
					angle = -angle;
				}
			} else {
				playercontroller.transform.position = transform.position + new Vector3(0.7f, -1.56f, -1.1f);
				angle = Vector3.Angle(-rightCoffin, playerForward);
				Vector3 rotDir = playerForward - rightCoffin;
				if (Vector3.Dot (rotDir, forwardCoffin) < 0) {
					angle = -angle;
				}
			}
			playercontroller.transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up) * playercontroller.transform.rotation;


			transform.parent = playercontroller.transform;
			transform.localPosition = new Vector3(0, 1f, 1.3f);
			transform.localRotation = new Quaternion(0.3f, -0.7f, -0.3f, 0.7f);
			nrCarriers++;

		} else if (nrCarriers == 1) {

		}


	}

	public void StopInteract(PlayerController playercontroller) {
		transform.parent = null;
		RB.isKinematic = false;
		nrCarriers--;

	}


	// Use this for initialization
	void Start () {
		RB = GetComponent<Rigidbody> ();
		timeLeft = time_delay + (float)Random.Range (-time_variance, time_variance);
		Debug.Log (timeLeft);
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< Updated upstream
		if (timeLeft <= 0) {
			zombie_active = true;
		} else {
			timeLeft -= Time.deltaTime;
		}
=======
>>>>>>> Stashed changes
	}
}
