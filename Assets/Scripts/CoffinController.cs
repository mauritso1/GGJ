using UnityEngine;
using System.Collections;

public class CoffinController : MonoBehaviour, Iinteractable {
	public void Interact(PlayerController playercontroller){
		playercontroller.gameObject.transform.parent = gameObject.transform;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
