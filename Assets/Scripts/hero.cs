using UnityEngine;
using System.Collections;

public class hero : MonoBehaviour {

	public float heroSpeed = 1f;

	public bool Run;
	public bool PutBomb;
	public float BombRate = 1.0f;

	private Vector3 movement;
	private float nextBomb = 0.0f;


	private Rigidbody rb;
	Animator am;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		am = GetComponent<Animator> ();
	}

	void Update(){

		float movementHorisontal = -Input.GetAxis ("Horizontal");
		float movementVertical = Input.GetAxis ("Vertical");

		movement = new Vector3 (movementVertical * heroSpeed, 0F, movementHorisontal * heroSpeed);

		// PutBomb
		if (Time.time > nextBomb) {
			if (Input.GetKey (KeyCode.Space) && Time.time > nextBomb) {
			} else if (Input.GetKey (KeyCode.Space)) {
				nextBomb = Time.time + BombRate;
				PutBomb = true;
				Debug.Log ("Der er trykket på \"Space\"");
			}
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