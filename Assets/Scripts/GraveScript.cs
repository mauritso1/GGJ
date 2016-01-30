using UnityEngine;
using System.Collections;

public class GraveScript : MonoBehaviour, Iinteractable{
	public int digging_progress = 0;
	public int digging_limit = 4; 
	public bool dug_grave = false;

	public void Interact(PlayerController playercontroller){
		digging_progress = digging_progress + 1;
		if (digging_progress == 4) {
			dug_grave = true;
		}
	}

	public void StopInteract(PlayerController playercontroller) {
		
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
	}


}
