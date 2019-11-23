using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {

	public static float GRAVITY_CONSTANT = 9.8f;
	public float mass;
	public float density = 1;
	public bool staticPosition = true;

	public Vector3 velocity = Vector3.zero;
	private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.mass = transform.localScale.x * transform.localScale.y * transform.localScale.z * density;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (!staticPosition) {
			Vector3 position = transform.position;
			Vector3 force = Vector3.zero;
			GravityController[] controllers = getGravityControllers();

			foreach(GravityController controller in controllers) {
				Rigidbody controllerRigidbody = controller.GetComponent<Rigidbody>();

				if (controller != this) {
					force += calculateForce(position, controller.transform.position, rigidbody.mass, controllerRigidbody.mass);
				}
			}

			updateVelocity(force);
		}
	}

	private void updateVelocity (Vector3 force) {
		rigidbody.velocity += (force / rigidbody.mass) * Time.deltaTime;
	}

	static Vector3 calculateForce (Vector3 thisPosition, Vector3 otherPosition, float thisMass, float otherMass) {
		Vector3 direction = Vector3.Normalize(otherPosition - thisPosition);
		float distance = Vector3.Distance(otherPosition, thisPosition);

		return direction * GRAVITY_CONSTANT * (thisMass * otherMass) / Mathf.Pow(distance, 2);
	}

	GravityController[] getGravityControllers () {
		var gravityArray = FindObjectsOfType<GravityController>();
		return gravityArray;
	}
}
