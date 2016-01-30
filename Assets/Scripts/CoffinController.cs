using UnityEngine;
using System.Collections;

public class CoffinController : MonoBehaviour, Iinteractable {

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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
