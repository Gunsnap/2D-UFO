using UnityEngine;
using System.Collections;

public class hero : MonoBehaviour {

	public float heroSpeed = 1f;

	public bool Run;
	public bool PutBomb;
	public float BombRate = 0.5f;
	private bool AllowBomb;

	private Vector3 movement;
	private float nextBomb = 0.0f;

	static int SekTidGemt;

	private Rigidbody rb;
	Animator am;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		am = GetComponent<Animator> ();
		SekTidGemt = 5;
	}

	void Update(){

		float Tid = Time.fixedTime;
		int SekTid = (int)Tid;

		float movementHorisontal = -Input.GetAxis ("Horizontal");
		float movementVertical = Input.GetAxis ("Vertical");

		movement = new Vector3 (movementVertical * heroSpeed, 0F, movementHorisontal * heroSpeed);
		/*
		if (Input.GetKey (KeyCode.Space) && Time.time > nextBomb) {
			nextBomb = Time.time + BombRate;
			//GameObject clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
			Debug.Log ("Space trykkes");
			PutBomb = true;
		} else if (SekTid != SekTidGemt) {
			SekTidGemt = SekTid;
			Debug.Log (SekTid.ToString());
		}
		*/

		if (SekTidGemt < SekTid) {
			AllowBomb = true;
			SekTidGemt = SekTid;
		} else {
			//AllowBomb = false;
		}

		if (AllowBomb) {
			if (Input.GetKeyDown (KeyCode.Space) && Tid > nextBomb) {
				nextBomb = Tid + BombRate;
				PutBomb = true;
				Debug.Log ("Smid en bombe");
				AllowBomb = false;
			} else {
				// Der er ikke trykket
				PutBomb = false;
				Debug.Log("Der må smides - Men der er ikke trykket");
			}
		} else {
			//PutBomb = false;
			Debug.Log("Du må IKKE smide en bombe");
		}
			

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// Movement
		if (movement != Vector3.zero) {
			Run = true;
			rb.AddForce (movement, ForceMode.Acceleration);
		} else {
			Run = false;
			rb.velocity = Vector3.zero;
		}

		am.SetBool ("Run", Run);
		am.SetBool ("PutBomb", PutBomb);
	}
}