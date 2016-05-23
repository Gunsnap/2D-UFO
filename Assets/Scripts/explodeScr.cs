using UnityEngine;
using System.Collections;

public class explodeScr : MonoBehaviour {
	public float putTime;
	public float bombDelay = 3.5f;
	public float timeNow;

	private Spawner spawnFire;

	Vector3 BombPosition;

	void Start () {
		putTime = Time.time;
		var BombObject = GameObject.Find (this.name);
		BombPosition = BombObject.transform.position;

		spawnFire = gameObject.GetComponent<Spawner> ();
	}

	void Update () {
		timeNow = Time.time;
		if (timeNow > putTime + bombDelay)
			removeBomb ();
	}

	public void removeBomb () {
		blastHallWithFire ();
		DestroyObject (this.gameObject);
	}

	public void blastHallWithFire (float range = 3) {
		//Center
		spawnFire.SpawnSomethingAwesome (BombPosition, Vector3.zero);

		//Mid
		for (float i = 0; i < range; i++) {
			spawnFire.SpawnSomethingAwesome (BombPosition + new Vector3 (0, 0, i), Vector3.zero, 1);//Venstre
			spawnFire.SpawnSomethingAwesome (BombPosition + new Vector3 (i, 0, 0), new Vector3 (0, 90, 0), 1);//Op
			spawnFire.SpawnSomethingAwesome (BombPosition + new Vector3 (0, 0, -i), new Vector3 (0, 180, 0), 1);//Højre
			spawnFire.SpawnSomethingAwesome (BombPosition + new Vector3 (0 - i, 0, 0), new Vector3 (0, 270, 0), 1);//Ned
		}

		//End
		spawnFire.SpawnSomethingAwesome (BombPosition + new Vector3 (0, 0, range), Vector3.zero, 2);//Venstre
		spawnFire.SpawnSomethingAwesome (BombPosition + new Vector3 (range, 0, 0), new Vector3 (0, 90, 0), 2);//Op
		spawnFire.SpawnSomethingAwesome (BombPosition + new Vector3 (0, 0, -range), new Vector3 (0, 180, 0), 2);//Højre
		spawnFire.SpawnSomethingAwesome (BombPosition + new Vector3 (0 - range, 0, 0), new Vector3 (0, 270, 0), 2);//Ned
	}

}