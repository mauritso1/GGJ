using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarnController : MonoBehaviour, Iinteractable {
	static Random r = new Random();

	public List<int> object_list = new List<int>();
	public void Interact(PlayerController playercontroller){
		// detach object a player might have animation code thingy
		playercontroller.giveObject = object_list[Random.Range(0,(object_list.Count - 1))];
		// attach object to player animation code thiny
	}

	public void StopInteract(PlayerController playercontroller){

	}
	// Use this for initialization
	void Start () {
		object_list.Add(1);
		object_list.Add(2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
