using UnityEngine;
using System.Collections;

public class explodeScr : MonoBehaviour {
	public float explodeSec = 2.5f;
	public float putTime;
	public float bombDelay = 3.5f;
	public float timeNow;

	private Spawner spawnFire;

	Vector3 BombPosition;

	void Start() {
		putTime = Time.time;
		var BombObject = GameObject.Find (this.gameObject);
		BombPosition = BombObject.transform.position;
	}

	void Update() {
		timeNow = Time.time;
		if(timeNow > putTime+bombDelay) {
			removeBomb ();
		}
	}

	public void removeBomb() {
		Debug.Log ("Fjern bombe");
		DestroyObject (this.gameObject);
	}

	public void blastHallWithFire() {
		spawnFire.SpawnSomethingAwesome (BombPosition);
	}

}
