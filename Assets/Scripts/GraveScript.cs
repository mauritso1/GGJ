using UnityEngine;
using System.Collections;

public class GraveScript : MonoBehaviour, Iinteractable{
	public int digging_limit = 4; 
	public bool dug_grave;
	public bool coffin_inside;

	public int digging_progress = 0;

	public GameObject zand;
	Transform mySand;

	public void Interact(PlayerController playercontroller){
		if (digging_progress != digging_limit && coffin_inside) {
			digging_progress = digging_progress + 1;
			//zand omhoog

			mySand.transform.position += new Vector3(0, (2.18f-0.09f)/(1.0f*digging_limit),0);

			if (digging_progress == digging_limit) {
				gameObject.GetComponentInParent<CoffinController>().timeLeft += 10f;
				dug_grave = true;
			}
		}
	}

	public void StopInteract(PlayerController playercontroller) {
		
	}

	// Use this for initialization
	void Start () {
		GameObject clone = Instantiate(zand) as GameObject;
		mySand = clone.transform;
		mySand.parent = transform;
		mySand.localPosition = new Vector3(0.16f, 0.09f, 2.35f);
		mySand.localRotation = Quaternion.Euler(-90,-90,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("interactable")) {
			other.transform.parent = gameObject.transform;
			other.GetComponent<Rigidbody>().isKinematic = true;
			coffin_inside = true;
			gameObject.GetComponentInChildren<CoffinController>().timeLeft += 10f;

			// activate other collider
			BoxCollider[] boxes = GetComponents<BoxCollider>();
			foreach (BoxCollider b in boxes) {
				if (!b.enabled) {b.enabled = true;}
			}
		}
	}


}
