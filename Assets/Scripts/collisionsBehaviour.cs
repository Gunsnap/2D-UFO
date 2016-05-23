using UnityEngine;
using System.Collections;

public class collisionsBehaviour : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		Debug.Log ("DER SMADRES EN " + other);
	}

}