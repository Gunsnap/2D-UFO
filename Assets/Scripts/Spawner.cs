using UnityEngine;
using System.Collections;


// Link til hjælp: www.youtube.com/watch?v=M_xXmpI0GYs

public class Spawner : MonoBehaviour {

	public GameObject[] whatToSpawnPrefab;
	public GameObject[] whatToSpawnClone;

	public void SpawnSomethingAwesome(Vector3 SpawnPos){
		Debug.Log(SpawnPos);
		whatToSpawnClone [0] = Instantiate (whatToSpawnPrefab[0],SpawnPos, Quaternion.Euler(0,0,0)) as GameObject;
	}
}
