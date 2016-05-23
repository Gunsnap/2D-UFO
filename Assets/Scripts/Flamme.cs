using UnityEngine;
using System.Collections;

public class Flamme : MonoBehaviour {
	float endTime = 1f;

	void Start () {
		endTime += Time.time;
	}

	void Update () {
		if (Time.time > endTime)
			DestroyObject (this.gameObject);
	}
}