using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	public int speed = 5;
	private Vector3 startPosition;

	private Rigidbody rigidbody;

	void Start () {
		startPosition = transform.position;
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.velocity = (speed * Time.deltaTime * Vector3.forward);
	}

	// // Update is called once per frame
	// void FixedUpdate () {
	// }

	void OnCollisionEnter(Collision collision) {
		GameObject collisionObj = collision.collider.gameObject;

		if (collisionObj.tag == "Planet") {
			transform.position = startPosition;
			transform.rotation = new Quaternion(0, 0, 0, 0);
			rigidbody.velocity = (speed * Time.deltaTime * Vector3.forward);
		} else if (collisionObj.tag == "Goal") {
			transform.position = startPosition;
			transform.rotation = new Quaternion(0, 0, 0, 0);
			rigidbody.velocity = (speed * Time.deltaTime * Vector3.forward);
		}
	}
}
