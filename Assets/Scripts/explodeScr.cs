using UnityEngine;
using System.Collections;

public class explodeScr : MonoBehaviour {
	public float explodeSec = 2.5f;
	public float putTime;


	void Start() {
		removeBomb ();
		putTime = Time.time;
	}

	public void removeBomb() {
		Debug.Log ("Fjern bombe");
	}

}
