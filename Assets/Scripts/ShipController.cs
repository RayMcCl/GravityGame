using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	public int speed = 5;
	public int angle = 0;
	private Vector3 startPosition;

	private Rigidbody rigidbody;

	void Start () {
		startPosition = transform.position;
		rigidbody = GetComponent<Rigidbody>();
		transform.eulerAngles = new Vector3(0, angle, 0);
		rigidbody.velocity = (speed * Time.deltaTime * transform.forward);
	}

	// // Update is called once per frame
	// void FixedUpdate () {
	// }

	void OnCollisionEnter(Collision collision) {
		GameObject collisionObj = collision.collider.gameObject;

		if (collisionObj.tag == "Planet") {
			resetShip();
		} else if (collisionObj.tag == "Goal") {
			resetShip();
		}
	}

	void resetShip () {
		transform.position = startPosition;
		transform.rotation = new Quaternion(0, 0, 0, 0);
		transform.eulerAngles = new Vector3(0, angle, 0);
		rigidbody.velocity = (speed * Time.deltaTime * transform.forward);
	}
}
