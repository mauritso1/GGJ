using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {
	public bool zombie_active; 
	public float zombie_speed;

	private Transform target;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (zombie_active) {
			target = GameObject.Find ("Player").transform;
			Vector3 relativePos = target.position - transform.position;
			GetComponent<Rigidbody>().AddForce(relativePos);
		}
	}
}
