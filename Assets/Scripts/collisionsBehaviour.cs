using UnityEngine;
using System.Collections;

public class collisionsBehaviour : MonoBehaviour {
	
	void Start() {
		
	}

	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
			Debug.Log ("Collision!");
		}
		if (collision.relativeVelocity.magnitude > 2)
			Debug.Log ("Eksemplet ville afspille lyd nu");
	}
}
