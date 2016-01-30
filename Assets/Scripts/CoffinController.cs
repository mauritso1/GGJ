using UnityEngine;
using System.Collections;

public class CoffinController : MonoBehaviour, Iinteractable {
	public int time_variance;
	public float time_delay;

	private float timeLeft;
	private float count_down; 
	public bool zombie_active = false;

	public void Interact(PlayerController playercontroller){
		//gameObject.transform.parent = playercontroller.transform;
		//gameObject.GetComponent<HingeJoint>();
		gameObject.AddComponent<HingeJoint>();
		gameObject.GetComponent<HingeJoint>().connectedBody = playercontroller.GetComponent<Rigidbody>();
	}

	public void StopInteract(PlayerController playercontroller) {
		gameObject.GetComponent<HingeJoint> ().connectedBody = null;
		//gameObject.transform.parent = null;
	}
	// Use this for initialization
	void Start () {
		timeLeft = time_delay + (float)Random.Range (-time_variance, time_variance);
		Debug.Log (timeLeft);
	}
	
	// Update is called once per frame
	void Update () {
		if (timeLeft <= 0) {
			zombie_active = true;
		} else {
			timeLeft -= Time.deltaTime;
		}
	}
}
