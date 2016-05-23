using UnityEngine;
using System.Collections;


// Link til hjælp: www.youtube.com/watch?v=M_xXmpI0GYs

public class Spawner : MonoBehaviour {

	//public Transform[] spawnLocations;
	public GameObject[] whatToSpawnPrefab;
	public GameObject[] whatToSpawnClone;

	/*
	void Start() {
		SpawnSomethingAwesome ();
	}
	*/

	public void SpawnSomethingAwesome(Vector3 PlayerPos){
	//	whatToSpawnClone [0] = Instantiate (whatToSpawnPrefab[0],spawnLocations[0].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
	//	whatToSpawnClone [1] = Instantiate (whatToSpawnPrefab[1],spawnLocations[1].transform.position, Quaternion.Euler(0,0,0)) as GameObject;
		Debug.Log(PlayerPos);
		whatToSpawnClone [2] = Instantiate (whatToSpawnPrefab[2],PlayerPos, Quaternion.Euler(0,0,0)) as GameObject;
	}

}
