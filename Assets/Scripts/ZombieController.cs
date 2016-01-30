using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {
	public bool zombie_active; 
	public float zombie_speed;

	private Transform target;

	void Start () {
	}
	
	void Update () {
		if (this.transform.parent) {
			zombie_active = this.transform.parent.GetComponent<CoffinController> ().zombie_active;	
		}
		if (zombie_active) {
			target = GameObject.Find ("Player").transform;
			Vector3 relativePos = target.position - transform.position;
			GetComponent<Rigidbody>().AddForce(relativePos);
		}
	}
}
