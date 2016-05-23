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
		var BombObject = GameObject.Find (this.name);
		BombPosition = BombObject.transform.position;

		spawnFire = gameObject.GetComponent<Spawner> ();
	}

	void Update() {
		timeNow = Time.time;
		if(timeNow > putTime+bombDelay) {
			removeBomb ();
		}
		Debug.Log (BombPosition);
	}

	public void removeBomb() {
		Debug.Log ("Fjern bombe");
		blastHallWithFire();
		DestroyObject (this.gameObject);
	}

	public void blastHallWithFire() {
		spawnFire.SpawnSomethingAwesome (BombPosition);
	}

}
