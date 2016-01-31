using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	Transform rotPoint;
	public float angle = 90f;

	void Start() {
		rotPoint = transform.FindChild("rotPoint");
	}

	// Use this for initialization
	public void Open() {
		Vector3 oldRotPoint = rotPoint.transform.position;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.up) * transform.rotation;
		Vector3 newRotPoint = rotPoint.transform.position;

		Vector3 move = oldRotPoint - newRotPoint;
		transform.position += move;
	}

	public void Close() {
		Vector3 oldRotPoint = rotPoint.transform.position;
		transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up) * transform.rotation;
		Vector3 newRotPoint = rotPoint.transform.position;

		Vector3 move = oldRotPoint - newRotPoint;
		transform.position += move;
	}
}
