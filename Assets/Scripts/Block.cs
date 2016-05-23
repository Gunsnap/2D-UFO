using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	private Spawner sp;

	public bool forsvind = false;

	// Use this for initialization
	void Start () {
		sp = gameObject.GetComponent<Spawner> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (forsvind) {
			var Obj = GameObject.Find (this.name);
			Vector3 ObjPos = Obj.transform.position;

			sp.SpawnSomethingAwesome (ObjPos, 1);
			DestroyObject (this.gameObject);
		}
	}
}